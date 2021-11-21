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
        private NewAbility AddDoubleStrike()
        {
            AbilityInfo info = ScriptableObject.CreateInstance<AbilityInfo>();
            info.powerLevel = 1;
            info.rulebookName = "Double Strike";
            info.rulebookDescription = "A creature bearing this sigil can attack twice per turn. However, this does not function when the creature has bifurcated or trifurcated strike.";
            info.metaCategories = new List<AbilityMetaCategory> { AbilityMetaCategory.Part1Rulebook, AbilityMetaCategory.Part1Modular };

            List<DialogueEvent.Line> lines = new List<DialogueEvent.Line>();
            DialogueEvent.Line line = new DialogueEvent.Line();
            line.text = "This card of yours is getting rather troublesome.";
            lines.Add(line);
            info.abilityLearnedDialogue = new DialogueEvent.LineSet(lines);

            byte[] imgBytes = System.IO.File.ReadAllBytes(Path.Combine(this.Info.Location.Replace("PvZMod.dll", ""), "Artwork/ability_doublestrike.png"));
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);

            NewAbility ability = new NewAbility(info, typeof(DoubleStrike), tex, AbilityIdentifier.GetAbilityIdentifier(PluginGuid, info.rulebookName));
            DoubleStrike.ability = ability.ability;
            return ability;
        }
    }

    public class DoubleStrike : CustomAbilityBehaviour<DoubleStrike>
    {
        public bool conAttack;
        public override bool RespondsToUpkeep(bool playerUpkeep)
        {
            return base.Card.OpponentCard != playerUpkeep;
        }
        public override bool RespondsToResolveOnBoard()
        {
            return base.RespondsToResolveOnBoard();
        }
        public override bool RespondsToDealDamage(int amount, PlayableCard target)
        {

            return conAttack == false && (!base.Card.HasAbility(Ability.SplitStrike) || !base.Card.HasAbility(Ability.TriStrike));
        }
        public override bool RespondsToDealDamageDirectly(int amount)
        {
            return conAttack == false && (!base.Card.HasAbility(Ability.SplitStrike) || !base.Card.HasAbility(Ability.TriStrike));
        }
        public override IEnumerator OnUpkeep(bool playerUpkeep)
        {
            conAttack = false;
            return base.OnUpkeep(playerUpkeep);
        }
        public override IEnumerator OnResolveOnBoard()
        {
            conAttack = false;
            return base.OnResolveOnBoard();
        }
        public override IEnumerator OnDealDamage(int amount, PlayableCard target)
        {
            yield return base.PreSuccessfulTriggerSequence();
            conAttack = true;
            yield return Singleton<CombatPhaseManager>.Instance.SlotAttackSequence(Card.Slot);
            yield return base.LearnAbility(0.25f);
            yield break;
        }
        public override IEnumerator OnDealDamageDirectly(int amount)
        {
            yield return base.PreSuccessfulTriggerSequence();
            conAttack = true;
            yield return Singleton<CombatPhaseManager>.Instance.SlotAttackSequence(Card.Slot);
            yield return base.LearnAbility(0.25f);
            yield break;
        }
    }
}
