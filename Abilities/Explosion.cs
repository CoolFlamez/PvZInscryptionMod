using System.Collections;
using System.Collections.Generic;
using System.IO;
using APIPlugin;
using DiskCardGame;
using UnityEngine;
using Pixelplacement;

namespace CardLoaderModCool
{
    public partial class Plugin 
    {
    
        private NewAbility AddExplosion()
        {
            AbilityInfo info = ScriptableObject.CreateInstance<AbilityInfo>();
            info.powerLevel = 1;
            info.rulebookName = "Explosion";
            info.rulebookDescription = "When played, a creature bearing this sigil sacrifices itself to blow up adjacent and opposing slots.";
            info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook, AbilityMetaCategory.Part1Modular };

            List<DialogueEvent.Line> lines = new List<DialogueEvent.Line>();
            DialogueEvent.Line line = new DialogueEvent.Line();
            line.text = "It seems you're packing";
            lines.Add(line);
            info.abilityLearnedDialogue = new DialogueEvent.LineSet(lines);

            byte[] imgBytes = System.IO.File.ReadAllBytes(Path.Combine(this.Info.Location.Replace("PvZMod.dll", ""), "Artwork/ability_Explosion.png"));
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);

            NewAbility ability = new NewAbility(info, typeof(Explosion), tex, AbilityIdentifier.GetAbilityIdentifier(PluginGuid, info.rulebookName));
            Explosion.ability = ability.ability;
            return ability;
        }
    }
   
	public class Explosion : CustomAbilityBehaviour<Explosion>
	{

		private void Awake()
		{
			this.bombPrefab = ResourceBank.Get<GameObject>("Prefabs/Cards/SpecificCardModels/DetonatorHoloBomb");
		}

        public override bool RespondsToResolveOnBoard()
        {
            return base.Card.OnBoard;
        }

        public override IEnumerator OnResolveOnBoard()
        {
			base.Card.Anim.LightNegationEffect();
			yield return base.PreSuccessfulTriggerSequence();
			yield return this.ExplodeFromSlot(base.Card.Slot);
			yield return base.Card.Die(false, base.Card, false);
			yield return base.LearnAbility(0.25f);
			yield break;
		}

		protected IEnumerator ExplodeFromSlot(CardSlot slot)
		{
			List<CardSlot> adjacentSlots = Singleton<BoardManager>.Instance.GetAdjacentSlots(slot);
			List<CardSlot> opposingSlots = Singleton<BoardManager>.Instance.GetAdjacentSlots(slot.opposingSlot);

			if (adjacentSlots.Count > 0 && adjacentSlots[0].Index < slot.Index)
			{
				if (adjacentSlots[0].Card != null && !adjacentSlots[0].Card.Dead)
				{
					yield return this.BombCard(adjacentSlots[0].Card, slot.Card);
				}
				adjacentSlots.RemoveAt(0);
			}
			if (opposingSlots.Count > 0 && opposingSlots[0].Index < slot.opposingSlot.Index)
			{
				if (opposingSlots[0].Card != null && !opposingSlots[0].Card.Dead)
				{
					yield return this.BombCard(opposingSlots[0].Card, slot.Card);
				}
				opposingSlots.RemoveAt(0);
			}
			if (slot.opposingSlot.Card != null && !slot.opposingSlot.Card.Dead)
			{
				yield return this.BombCard(slot.opposingSlot.Card, slot.Card);
			}
			if (opposingSlots.Count > 0 && opposingSlots[0].Card != null && !opposingSlots[0].Card.Dead)
			{
				yield return this.BombCard(opposingSlots[0].Card, slot.Card);
			}
			if (adjacentSlots.Count > 0 && adjacentSlots[0].Card != null && !adjacentSlots[0].Card.Dead)
			{
				yield return this.BombCard(adjacentSlots[0].Card, slot.Card);
			}
			yield break;
		}

		private IEnumerator BombCard(PlayableCard target, PlayableCard attacker)
		{
			GameObject bomb = Object.Instantiate<GameObject>(this.bombPrefab);
			bomb.transform.position = attacker.transform.position + Vector3.up * 0.1f;
			Tween.Position(bomb.transform, target.transform.position + Vector3.up * 0.1f, 0.5f, 0f, Tween.EaseLinear, Tween.LoopType.None, null, null, true);
			yield return new WaitForSeconds(0.5f);
			target.Anim.PlayHitAnimation();
			Object.Destroy(bomb);
			yield return target.TakeDamage(10, attacker);
			yield break;
		}

		private const string BOMB_PREFAB_PATH = "Prefabs/Cards/SpecificCardModels/DetonatorHoloBomb";
		private GameObject bombPrefab;
	}
}
