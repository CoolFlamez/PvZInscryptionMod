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
        public void AddSunflower()
        {
            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
            List<Texture> decals = new List<Texture>();
            List<Ability> abilities = new List<Ability>();
            EvolveIdentifier evolve = new EvolveIdentifier("TwinSunflower", 1);
            metaCategories.Add(CardMetaCategory.ChoiceNode);
            metaCategories.Add(CardMetaCategory.TraderOffer);
            abilities.Add(SunProducer.ability);
            List<CardAppearanceBehaviour.Appearance> appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance>();
            byte[] imgBytes = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/Sunflower.png");
            byte[] imgBytes2 = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/energy1decal.png");
            Texture2D tex = new Texture2D(2, 2);
            Texture2D tex2 = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);
            tex2.LoadImage(imgBytes2);
            decals.Add(tex2);
            NewCard.Add("Sunflower", metaCategories, CardComplexity.Vanilla, CardTemple.Nature, "Sunflower", 0, 1, description: "One of the necessities to have at your lawn, the sunflower. It requires 1 energy!", cost: 0, energyCost: 1, appearanceBehaviour: appearanceBehaviour, abilities: abilities, evolveId: evolve, tex: tex, decals: decals);
        }
    }
}
