using BepInEx;
using BepInEx.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.IO;
using DiskCardGame;
using HarmonyLib;
using UnityEngine;
using APIPlugin;

namespace CardLoaderModCool
{
    [BepInPlugin("CardLoaderMod_Cool", "CardLoaderMod_Cool", "1.0.0")]
    [BepInDependency("cyantist.inscryption.api", BepInDependency.DependencyFlags.HardDependency)]
    public partial class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;

        public string PluginGuid { get; private set; }

        private void Awake()
        {
            Plugin.Log = base.Logger;

            //Custom Sigils
            AddSunProducer();
            AddSunProducer2();
            AddDoubleStrike();
            AddWingPopper();
            AddExplosion();
            AddLaneClear();
            AddTangled();

            //Custom Cards
            AddSunflower();
            AddTwinSunflower();
            AddPeashooter();
            AddRepeater();
            AddRepeater2();
            AddGatlingPea();
            AddThreepeater();
            AddWallnut_Stage1();
            AddWallnut_Stage2();
            AddWallnut_Stage3();
            AddTallnut();
            AddCactus();
            AddCactus2();
            AddPeanut_Stage1();
            AddPeanut_Stage2();
            AddPotatoMine_Stage1();
            AddPotatoMine_Stage2();
            AddCherryBomb();
            AddTorchwood();
            AddTangleKelp();
            AddJalapeno();

            Harmony harmony = new Harmony("CardLoaderMod_Cool");
            harmony.PatchAll();

            //Cards to Add (PVZ2: FirePeashooter, Citron, Goo Peashooter, 
        }
    }
}
