using System;
using System.Collections;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using BepInEx.Configuration;
using UnityEngine;
using System.Reflection;
namespace NoPlasmaAd {
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    [BepInProcess("Poly Bridge 2")]
    [BepInDependency(ConfigurationManager.ConfigurationManager.GUID, BepInDependency.DependencyFlags.HardDependency)]
    
    
    public class NoPlasmaAd : BaseUnityPlugin {
        
        
        public const string pluginGuid = "org.bepinex.plugins.NoPlasmaAd";
        public const string pluginName = "No Plasma Ad";
        public const string pluginVersion = "1.0.0";
        
        public static ConfigEntry<bool> mEnabled;
        
        public ConfigDefinition mEnabledDef = new ConfigDefinition(pluginVersion, "Enable/Disable Mod");
        
        
        
        public NoPlasmaAd(){
            
            mEnabled = Config.Bind(mEnabledDef, true, new ConfigDescription("Controls if the mod should be enabled or disabled", null, new ConfigurationManagerAttributes {Order = 0}));
        }
        void Awake(){
            
            Harmony.CreateAndPatchAll(typeof(NoPlasmaAd));
        }
        void Update(){
            
        }
        
        [HarmonyPatch(typeof(Panel_MainMenuNew), "MaybeDisablePlasmaBanner")]
        [HarmonyPostfix]
        private static void PanelMainMenuNewMaybeDisablePlasmaBannerPostfixPatch(ref Panel_MainMenuNew __instance){
            
            if(mEnabled.Value){
                __instance.m_PlasmaBannerButton.gameObject.SetActive(false);                
            }
            
        }
    }
}