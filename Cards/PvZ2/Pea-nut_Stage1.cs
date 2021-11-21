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
        public void AddPeanut_Stage1()
        {
            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
            List<Ability> abilities = new List<Ability>();
            List<Texture> decals = new List<Texture>();
            IceCubeIdentifier icecube = new IceCubeIdentifier("Peanut_Stage2");
            metaCategories.Add(CardMetaCategory.ChoiceNode);
            metaCategories.Add(CardMetaCategory.TraderOffer);
            abilities.Add(Ability.SplitStrike);
            abilities.Add(Ability.IceCube);
            List<CardAppearanceBehaviour.Appearance> appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance>();
            byte[] imgBytes = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/wip.png");
            byte[] imgBytes2 = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/energy4decal.png");
            Texture2D tex = new Texture2D(2, 2);
            Texture2D tex2 = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);
            tex2.LoadImage(imgBytes2);
            decals.Add(tex2);
            NewCard.Add("Peanut_Stage1", metaCategories, CardComplexity.Intermediate, CardTemple.Nature, "Pea-nut", 1, 4, description: "A Pea-nut's impeccable defense and offensive capabilities make it a threat on the board. It requires 4 energy!", cost: 0, energyCost: 4, appearanceBehaviour: appearanceBehaviour, abilities: abilities, iceCubeId: icecube, tex: tex, decals: decals);
        }
    }
}
