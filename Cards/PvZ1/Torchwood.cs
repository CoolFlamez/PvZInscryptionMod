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
        public void AddTorchwood()
        {
            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
            List<Ability> abilities = new List<Ability>();
            List<Trait> traits = new List<Trait>();
            List<Texture> decals = new List<Texture>();
            metaCategories.Add(CardMetaCategory.ChoiceNode);
            metaCategories.Add(CardMetaCategory.TraderOffer);
            traits.Add(Trait.Terrain);
            abilities.Add(Ability.BuffGems);
            List<CardAppearanceBehaviour.Appearance> appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance>();
            appearanceBehaviour.Add(CardAppearanceBehaviour.Appearance.TerrainBackground);
            byte[] imgBytes = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/Torchwood.png");
            byte[] imgBytes2 = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/energy2decal.png");
            Texture2D tex = new Texture2D(2, 2);
            Texture2D tex2 = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);
            tex2.LoadImage(imgBytes2);
            decals.Add(tex2);
            NewCard.Add("Torchwood", metaCategories, CardComplexity.Intermediate, CardTemple.Nature, "Torchwood", 0, 3, description: "The mysterious torchwood. It boosts your pea plants by 1 ATK. It requires 2 energy!", cost: 0, energyCost: 2, appearanceBehaviour: appearanceBehaviour, abilities: abilities, traits: traits, tex: tex, decals: decals);
        }
    }
}
