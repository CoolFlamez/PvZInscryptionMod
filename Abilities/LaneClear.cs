using System.Collections;
using System.Collections.Generic;
using System.IO;
using APIPlugin;
using DiskCardGame;
using UnityEngine;

namespace CardLoaderModCool
{
    public partial class Plugin 
    {
    
        private NewAbility AddLaneClear()
        {
            AbilityInfo info = ScriptableObject.CreateInstance<AbilityInfo>();
            info.powerLevel = 3;
            info.rulebookName = "Lane Clear";
            info.rulebookDescription = "When a creature bearing this sigil is played, kill all the creatures in its lane.";
            info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook, AbilityMetaCategory.Part1Modular };

            List<DialogueEvent.Line> lines = new List<DialogueEvent.Line>();
            DialogueEvent.Line line = new DialogueEvent.Line();
            line.text = "Another explosive card? Sure, why not.";
            lines.Add(line);
            info.abilityLearnedDialogue = new DialogueEvent.LineSet(lines);

            byte[] imgBytes = System.IO.File.ReadAllBytes(Path.Combine(this.Info.Location.Replace("PvZMod.dll", ""), "Artwork/ability_wip.png"));
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);

            NewAbility ability = new NewAbility(info, typeof(LaneClear), tex, AbilityIdentifier.GetAbilityIdentifier(PluginGuid, info.rulebookName));
            LaneClear.ability = ability.ability;
            return ability;
        }
    }
    
    public class LaneClear : CustomAbilityBehaviour<LaneClear>
    {
        public override bool RespondsToResolveOnBoard()
        {
            return base.Card != null && base.Card.slot.opposingSlot.Card != null;
        }
        public override IEnumerator OnResolveOnBoard()
        {
            bool impactFrameReached = false;
            yield return base.PreSuccessfulTriggerSequence();
            base.Card.Anim.PlayAttackAnimation(false, base.Card.Slot.opposingSlot, delegate ()
            {
                impactFrameReached = true;
            });
            yield return new WaitUntil(() => impactFrameReached);
            yield return base.Card.Slot.opposingSlot.Card.TakeDamage(10, base.Card);
            yield return Singleton<CombatPhaseManager>.Instance.DealOverkillDamage(10, Card.slot, Card.slot.opposingSlot);
            yield return base.Card.Die(false, base.Card, false);
            yield return new WaitForSeconds(0.25f);
            yield break;
        }
    }
}
