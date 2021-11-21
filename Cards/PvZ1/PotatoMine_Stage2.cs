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
        public void AddPotatoMine_Stage2()
        {
            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
            List<Ability> abilities = new List<Ability>();
            abilities.Add(Ability.SteelTrap);
            List<CardAppearanceBehaviour.Appearance> appearanceBehaviour = new List<CardAppearanceBehaviour.Appearance>();
            byte[] imgBytes = System.IO.File.ReadAllBytes("BepInEx/plugins/CardLoader/Artwork/PotatoMine_Stage2.png");
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(imgBytes);
            NewCard.Add("PotatoMine_Stage2", metaCategories, CardComplexity.Simple, CardTemple.Nature, "Potato Mine", 0, 1, cost: 0, energyCost: 0, appearanceBehaviour: appearanceBehaviour, abilities: abilities, tex: tex);
        }
    }
}
