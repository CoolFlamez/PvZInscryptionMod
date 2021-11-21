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
    
        private NewAbility AddSunProducer()
        {
            AbilityInfo info = ScriptableObject.CreateInstance<AbilityInfo>();
            info.powerLevel = 1;
            info.rulebookName = "Sun Producer";
            info.rulebookDescription = "At the start of turn, a creature bearing this sigil produces 1 energy.";
            info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook, AbilityMetaCategory.Part1Modular };

            List<DialogueEvent.Line> lines = new List<DialogueEvent.Line>();
            DialogueEvent.Line line = new DialogueEvent.Line();
            line.text = "Your plant has made some energy, good for you.";
            lines.Add(line);
            info.abilityLearnedDialogue = new DialogueEvent.LineSet(lines);

            byte[] imgBytes = System.IO.File.ReadAllBytes(Path.Combine(this.Info.Location.Replace("PvZMod.dll", ""), "Artwork/ability_sunproducer.png"));
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);

            NewAbility ability = new NewAbility(info, typeof(SunProducer), tex, AbilityIdentifier.GetAbilityIdentifier(PluginGuid, info.rulebookName));
            SunProducer.ability = ability.ability;
            return ability;
        }
    }
    
    public class SunProducer : CustomAbilityBehaviour<SunProducer>
    {
        public override bool RespondsToUpkeep(bool playerUpkeep)
        {
            return base.Card.OpponentCard != playerUpkeep;
        }
        public override IEnumerator OnUpkeep(bool playerUpkeep)
        {
            yield return base.PreSuccessfulTriggerSequence();
            yield return Singleton<Part1ResourcesManager>.Instance.AddMaxEnergy(1);
            yield return base.LearnAbility(0.25f);
            yield break;
        }
    }
}
