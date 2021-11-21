using System;
using System.Collections.Generic;
using System.Text;
using APIPlugin;
using DiskCardGame;
using UnityEngine;

namespace CardLoaderModCool
{
    public partial class Plugin
    {
        public void AddPotatoMine_Stage1()
        {
            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
            List<Ability> abilities = new List<Ability>();
            metaCategories.Add(CardMetaCategory.ChoiceNode);
            metaCategories.Add(CardMetaCategory.TraderOffer);
            EvolveIdentifier evolve = new EvolveIdentifier("PotatoMine_Stage2", 1);
            abilities.Add(Ability.Evolve);
            List<CardAppearanceBehaviour.Appearance> appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance>();
            byte[] imgBytes = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/PotatoMine_Stage1.png");
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);
            NewCard.Add("PotatoMine_Stage1", metaCategories, CardComplexity.Simple, CardTemple.Nature, "Potato Sprout", 0, 1, description: "Set the potato mine, wait a turn, it sprouts to explode upon being touched! It requires no cost!", cost: 0, energyCost: 0, appearanceBehaviour: appearanceBehaviour, abilities: abilities, evolveId: evolve, tex: tex);
        }
    }
}
