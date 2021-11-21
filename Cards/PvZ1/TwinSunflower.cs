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
        public void AddTwinSunflower()
        {
            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
            List<Texture> decals = new List<Texture>();
            List<Ability> abilities = new List<Ability>();
            metaCategories.Add(CardMetaCategory.ChoiceNode);
            metaCategories.Add(CardMetaCategory.TraderOffer);
            abilities.Add(SunProducer2.ability);
            List<CardAppearanceBehaviour.Appearance> appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance>();
            byte[] imgBytes = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/wip.png");
            byte[] imgBytes2 = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/energy2decal.png");
            Texture2D tex = new Texture2D(2, 2);
            Texture2D tex2 = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);
            tex2.LoadImage(imgBytes2);
            decals.Add(tex2);
            NewCard.Add("TwinSunflower", metaCategories, CardComplexity.Intermediate, CardTemple.Nature, "Twin Sunflower", 0, 2, description: "Was this the work of the mycologist? Whatever, take this twin sunflower. It requires 2 energy!", cost: 0, energyCost: 2, appearanceBehaviour: appearanceBehaviour, abilities: abilities, tex: tex, decals: decals);
        }
    }
}
