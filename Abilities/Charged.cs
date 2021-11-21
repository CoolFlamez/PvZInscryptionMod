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
    
        private NewAbility AddCharged()
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

            byte[] imgBytes = System.IO.File.ReadAllBytes(Path.Combine(this.Info.Location.Replace("PvZMod.dll", ""), "Artwork/ability_wip.png"));
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);

            NewAbility ability = new NewAbility(info, typeof(Charged), tex, AbilityIdentifier.GetAbilityIdentifier(PluginGuid, info.rulebookName));
            Charged.ability = ability.ability;
            return ability;
        }
    }
   
	public class Charged : CustomAbilityBehaviour<Charged>
	{
        private void Start()
        {
            this.mod = new CardModificationInfo();
            this.mod.attackAdjustment = 4;
        }
        public override bool RespondsToUpkeep(bool playerUpkeep)
        {
            return base.Card.OpponentCard != playerUpkeep;
        }
        public override IEnumerator OnUpkeep(bool playerUpkeep)
        {
            this.turnCount++;
            if (this.turnCount >= 2)
            {
                base.Card.Anim.LightNegationEffect();
                yield return base.PreSuccessfulTriggerSequence();
                base.Card.AddTemporaryMod(this.mod);
                base.Card.OnStatsChanged();
                yield return base.LearnAbility(0.25f);
            }
			yield break;
		}
        public override bool RespondsToAttackEnded()
        {
            return base.Card != null;
        }
        public override IEnumerator OnAttackEnded()
        {
            if (this.turnCount >= 2)
            {
                base.Card.Anim.StrongNegationEffect();
                base.Card.RemoveTemporaryMod(this.mod);
                base.Card.OnStatsChanged();
                turnCount = 0;
            }
            yield break;
        }
        private int turnCount;
        private CardModificationInfo mod;
	}
}
