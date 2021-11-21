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
    
        private NewAbility AddWingPopper()
        {
            AbilityInfo info = ScriptableObject.CreateInstance<AbilityInfo>();
            info.powerLevel = 3;
            info.rulebookName = "Wing Popper";
            info.rulebookDescription = "When a creature bearing this sigil strikes a creature with the flying sigil, it kills instantly.";
            info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook, AbilityMetaCategory.Part1Modular };

            List<DialogueEvent.Line> lines = new List<DialogueEvent.Line>();
            DialogueEvent.Line line = new DialogueEvent.Line();
            line.text = "I'm sure you're sad I didn't bring any balloons.";
            lines.Add(line);
            info.abilityLearnedDialogue = new DialogueEvent.LineSet(lines);

            byte[] imgBytes = System.IO.File.ReadAllBytes(Path.Combine(this.Info.Location.Replace("PvZMod.dll", ""), "Artwork/ability_WingPopper.png"));
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);

            NewAbility ability = new NewAbility(info, typeof(WingPopper), tex, AbilityIdentifier.GetAbilityIdentifier(PluginGuid, info.rulebookName));
            WingPopper.ability = ability.ability;
            return ability;
        }
    }
    
    public class WingPopper : CustomAbilityBehaviour<WingPopper>
    {
        public override bool RespondsToDealDamage(int amount, PlayableCard target)
        {
            return target.HasAbility(Ability.Flying);
        }
        public override IEnumerator OnDealDamage(int amount, PlayableCard target)
        {
            yield return base.PreSuccessfulTriggerSequence();
            yield return target.Die(false, base.Card, true);
            yield return base.LearnAbility(0.25f);
            yield break;
        }
    }
}
