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
        public void AddGatlingPea()
        {
            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
            List<Ability> abilities = new List<Ability>();
            List<Trait> traits = new List<Trait>();
            List<Texture> decals = new List<Texture>();
            metaCategories.Add(CardMetaCategory.Rare);
            traits.Add(Trait.Gem);
            List<CardAppearanceBehaviour.Appearance> appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance>();
            appearanceBehaviour.Add(CardAppearanceBehaviour.Appearance.RareCardBackground);
            byte[] imgBytes = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/GatlingPea.png");
            byte[] imgBytes2 = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/energy5decal.png");
            Texture2D tex = new Texture2D(2, 2);
            Texture2D tex2 = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);
            tex2.LoadImage(imgBytes2);
            decals.Add(tex2);
            NewCard.Add("GatlingPea", metaCategories, CardComplexity.Advanced, CardTemple.Nature, "Gatling Pea", 4, 2, description: "Mow down hordes of creatures with immense firepower from the Gatling Pea! It requires 5 energy!", cost: 0, energyCost: 5, appearanceBehaviour: appearanceBehaviour, abilities: abilities, traits: traits, tex: tex);
        }
    }
}
