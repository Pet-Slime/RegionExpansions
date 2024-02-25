using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using RegionExpansions.cards;
using InscryptionAPI.Card;
using UnityEngine;
using System.IO;
using System.Reflection;
using RegionExpansions.Encounter.Normal;
using System;
using DiskCardGame;

namespace RegionExpansions
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
	[BepInDependency(APIGUID, BepInDependency.DependencyFlags.HardDependency)]
	[BepInDependency(SigilGUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(TotemGUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(NeverGUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(PackManagerGUID, BepInDependency.DependencyFlags.SoftDependency)]

    public partial class Plugin : BaseUnityPlugin
	{
		public const string APIGUID = "cyantist.inscryption.api";
		public const string SigilGUID = "extraVoid.inscryption.voidSigils";
        public const string TotemGUID = "Lily.BOT";
        public const string NeverGUID = "nevernamed.inscryption.sigils";
        public const string PackManagerGUID = "zorro.inscryption.infiniscryption.packmanager";
        public const string PluginGuid = "extraVoid.inscryption.RegionExpansions";
		private const string PluginName = "RegionExpansions";
		private const string PluginVersion = "2.2.0";

		public static string Directory;
		internal static ManualLogSource Log;
        public static AssetBundle RegionExpansionBundle;


        public static BossBattleNodeData GravekeeperBossNode;
        public static Opponent.Type GravekeeperBoss;
        public static string GraveyardBossBattleSequencer;



        private void Awake()
		{

			Log = base.Logger;
			Directory = this.Info.Location.Replace("RegionExpansions.dll", "");

			Plugin.RegionExpansionBundle = Plugin.LoadBundle("RegionExpansions\\Resources\\region_expansions");

            Harmony harmony = new(PluginGuid);
			harmony.PatchAll();
			RegionExpansions.sigils.DyingWind.specialAbility = SpecialTriggeredAbilityManager.Add(Plugin.PluginGuid, "Dying Wind", typeof(RegionExpansions.sigils.DyingWind)).Id;

			High_Tide.AddCard();
			Low_Tide.AddCard();
			Strong_Wind_1.AddCard();
			American_Lobster.AddCard();
			Jonah_Crab.AddCard();
			Costal_Salmon.AddCard();
			Moon_Jellyfish.AddCard();
			Mussel.AddCard();
			School_Fish.AddCard();
			Starfish.AddCard();

			///Regions.Region_Beach.AddRegionIntroDialogue();
			Regions.Graveyard.Region_Graveyard.AddRegionIntroDialogue();
            Regions.Graveyard.Gravekeeper_boss.AddBossNodes();

		}



        private void Start()
        {


            BirdOfTheSea.AddEncounter();
            TideOfFish.AddEncounter();
            CrabsAndLobster.AddEncounter();


            ///Regions.Region_Beach.AddRegion();
            Regions.Graveyard.Region_Graveyard.AddRegion();

            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(Plugin.PackManagerGUID))
            {
                lib.CreateCardPack.CreatePack();
            }

        }

        public static AssetBundle LoadBundle(string path)
        {
            AssetBundle result;
            using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path.Replace("\\", ".").Replace("/", ".")))
            {
                result = AssetBundle.LoadFromStream(manifestResourceStream);
            }
            return result;
        }

        [HarmonyPatch(typeof(ResourceBank), "Awake", new Type[] { })]
        internal class ResourceBank_Awake
        {
            public static void Postfix()
            {
                Plugin.Log.LogInfo("Load Region Game Objects");
                Regions.Region_Graveyard.LoadGameObjects();
            }
        }


    }



    public static class ScriptableObjectExtension
	{
		/// <summary>
		/// Creates and returns a clone of any given scriptable object.
		/// </summary>
		public static T Clone<T>(this T scriptableObject) where T : ScriptableObject
		{
			if (scriptableObject == null)
			{
				Debug.LogError($"ScriptableObject was null. Returning default {typeof(T)} object.");
				return (T)ScriptableObject.CreateInstance(typeof(T));
			}

			T instance = UnityEngine.Object.Instantiate(scriptableObject);
			instance.name = scriptableObject.name; // remove (Clone) from name
			return instance;
		}
	}
}