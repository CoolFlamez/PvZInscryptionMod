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
    
        private NewAbility AddTangled()
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

            NewAbility ability = new NewAbility(info, typeof(Tangled), tex, AbilityIdentifier.GetAbilityIdentifier(PluginGuid, info.rulebookName));
            Tangled.ability = ability.ability;
            return ability;
        }
    }
    
    public class Tangled : CustomAbilityBehaviour<Tangled>
    {
        public override bool RespondsToResolveOnBoard()
        {
            return base.Card != null && base.Card.slot.opposingSlot.Card != null && base.Card.slot.opposingSlot.Card.HasAbility(Ability.Submerge);
        }
        public override IEnumerator OnResolveOnBoard()
        {
            yield return base.Card.Slot.opposingSlot.Card.Die(false, base.Card, false);
            yield return base.Card.Die(false, base.Card, false);
            yield return new WaitForSeconds(0.25f);
            yield break;
        }
    }
}
