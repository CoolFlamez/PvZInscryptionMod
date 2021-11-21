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
        private NewAbility AddSunProducer2()
        {
            AbilityInfo info = ScriptableObject.CreateInstance<AbilityInfo>();
            info.powerLevel = 1;
            info.rulebookName = "Sun Producer 2";
            info.rulebookDescription = "At the start of turn, a creature bearing this sigil produces 2 energy.";
            info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook, AbilityMetaCategory.Part1Modular };

            List<DialogueEvent.Line> lines = new List<DialogueEvent.Line>();
            DialogueEvent.Line line = new DialogueEvent.Line();
            line.text = "Quite the amount of energy made, good for you.";
            lines.Add(line);
            info.abilityLearnedDialogue = new DialogueEvent.LineSet(lines);

            byte[] imgBytes = System.IO.File.ReadAllBytes(Path.Combine(this.Info.Location.Replace("PvZMod.dll", ""), "Artwork/ability_sunproducer2.png"));
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);

            NewAbility ability = new NewAbility(info, typeof(SunProducer2), tex, AbilityIdentifier.GetAbilityIdentifier(PluginGuid, info.rulebookName));
            SunProducer2.ability = ability.ability;
            return ability;
        }

        public class SunProducer2 : CustomAbilityBehaviour<SunProducer2>
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
}