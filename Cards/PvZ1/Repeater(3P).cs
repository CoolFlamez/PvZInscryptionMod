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
        public void AddRepeater2() //Evolves into Threepeater
        {
            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
            List<Trait> traits = new List<Trait>();
            List<Texture> decals = new List<Texture>();
            List<Ability> abilities = new List<Ability>();
            EvolveIdentifier evolve = new EvolveIdentifier("Threepeater", 1);
            metaCategories.Add(CardMetaCategory.ChoiceNode);
            metaCategories.Add(CardMetaCategory.TraderOffer);
            abilities.Add(DoubleStrike.ability);
            traits.Add(Trait.Gem);
            List<CardAppearanceBehaviour.Appearance> appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance>();
            byte[] imgBytes = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/wip.png");
            byte[] imgBytes2 = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/energy4decal.png");
            Texture2D tex = new Texture2D(2, 2);
            Texture2D tex2 = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);
            tex2.LoadImage(imgBytes2);
            decals.Add(tex2);
            NewCard.Add("Repeater2", metaCategories, CardComplexity.Intermediate, CardTemple.Nature, "Repeater", 2, 1, description: "Repeater, the stronger sibling of a peashooter. It requires 4 energy!", cost: 0, energyCost: 4, appearanceBehaviour: appearanceBehaviour, abilities: abilities, evolveId: evolve, traits: traits, tex: tex, decals: decals);
        }
    }
}
