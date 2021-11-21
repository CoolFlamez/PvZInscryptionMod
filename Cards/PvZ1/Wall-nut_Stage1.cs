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
        public void AddWallnut_Stage1()
        {
            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
            List<Ability> abilities = new List<Ability>();
            List<Texture> decals = new List<Texture>();
            IceCubeIdentifier icecube = new IceCubeIdentifier("Wallnut_Stage2");
            metaCategories.Add(CardMetaCategory.ChoiceNode);
            metaCategories.Add(CardMetaCategory.TraderOffer);
            abilities.Add(Ability.IceCube);
            List<CardAppearanceBehaviour.Appearance> appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance>();
            byte[] imgBytes = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/Wallnut_Stage1.png");
            byte[] imgBytes2 = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/energy2decal.png");
            Texture2D tex = new Texture2D(2, 2);
            Texture2D tex2 = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);
            tex2.LoadImage(imgBytes2);
            decals.Add(tex2);
            NewCard.Add("Wallnut_Stage1", metaCategories, CardComplexity.Vanilla, CardTemple.Nature, "Wall-nut", 0, 4, description: "Ah, the wallnut. It blocks incoming attacks. It requires 2 energy!", cost: 0, energyCost: 2, appearanceBehaviour: appearanceBehaviour, abilities: abilities, iceCubeId: icecube, tex: tex, decals: decals);
        }
    }
}
