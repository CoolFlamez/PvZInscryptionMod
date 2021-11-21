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
        public void AddCherryBomb()
        {
            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
            List<Ability> abilities = new List<Ability>();
            List<Texture> decals = new List<Texture>();
            metaCategories.Add(CardMetaCategory.ChoiceNode);
            metaCategories.Add(CardMetaCategory.TraderOffer);
            abilities.Add(Explosion.ability);
            List<CardAppearanceBehaviour.Appearance> appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance>();
            byte[] imgBytes = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/CherryBomb.png");
            byte[] imgBytes2 = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/energy5decal.png");
            Texture2D tex = new Texture2D(2, 2);
            Texture2D tex2 = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);
            tex2.LoadImage(imgBytes2);
            decals.Add(tex2);
            NewCard.Add("Cherry Bomb", metaCategories, CardComplexity.Intermediate, CardTemple.Nature, "Cherry Bomb", 0, 1, description: "Blow up hordes of creatures with the Cherry Bomb, it's a one time use though! It requires 5 energy!", hideAttackAndHealth: true, cost: 0, energyCost: 5, appearanceBehaviour: appearanceBehaviour, abilities: abilities, tex: tex, decals: decals);
        }
    }
}
