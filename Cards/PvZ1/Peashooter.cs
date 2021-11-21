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
        public void AddPeashooter()
        {
            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
            List<Trait> traits = new List<Trait>();
            List<Texture> decals = new List<Texture>();
            EvolveIdentifier evolve = new EvolveIdentifier("Repeater", 1);
            metaCategories.Add(CardMetaCategory.ChoiceNode);
            metaCategories.Add(CardMetaCategory.TraderOffer);
            traits.Add(Trait.Gem);
            List<CardAppearanceBehaviour.Appearance> appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance>();
            byte[] imgBytes = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/Peashooter.png");
            byte[] imgBytes2 = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/energy3decal.png");
            Texture2D tex = new Texture2D(2, 2);
            Texture2D tex2 = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);
            tex2.LoadImage(imgBytes2);
            decals.Add(tex2);
            NewCard.Add("Peashooter", metaCategories, CardComplexity.Vanilla, CardTemple.Nature, "Peashoter", 1, 1, description: "The humble peashooter, a simple yet effective defender. It requires 3 energy!", cost: 0, energyCost: 3, appearanceBehaviour: appearanceBehaviour, evolveId: evolve, traits: traits, tex: tex, decals: decals);
        }
    }
}
