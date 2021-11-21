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
        public void AddThreepeater()
        {
            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
            List<Ability> abilities = new List<Ability>();
            List<Trait> traits = new List<Trait>();
            List<Texture> decals = new List<Texture>();
            metaCategories.Add(CardMetaCategory.ChoiceNode);
            metaCategories.Add(CardMetaCategory.TraderOffer);
            abilities.Add(Ability.TriStrike);
            traits.Add(Trait.Gem);
            List<CardAppearanceBehaviour.Appearance> appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance>();
            byte[] imgBytes = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/Threepeater.png");
            byte[] imgBytes2 = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/energy5decal.png");
            Texture2D tex = new Texture2D(2, 2);
            Texture2D tex2 = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);
            tex2.LoadImage(imgBytes2);
            decals.Add(tex2);
            NewCard.Add("Threepeater", metaCategories, CardComplexity.Intermediate, CardTemple.Nature, "Threepeater", 2, 3, description: "The Threepeater, capable of shooting in 3 directions! It requires 5 energy!", cost: 0, energyCost: 5, appearanceBehaviour: appearanceBehaviour, abilities: abilities, traits: traits, tex: tex, decals: decals);
        }
    }
}
