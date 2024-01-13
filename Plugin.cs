using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using RegionExpansions.cards;
using InscryptionAPI.Card;
using UnityEngine;

namespace RegionExpansions
{
	[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
	[BepInDependency(APIGUID, BepInDependency.DependencyFlags.HardDependency)]
	[BepInDependency(SigilGUID, BepInDependency.DependencyFlags.SoftDependency)]

	public partial class Plugin : BaseUnityPlugin
	{
		public const string APIGUID = "cyantist.inscryption.api";
		public const string SigilGUID = "extraVoid.inscryption.voidSigils";
		public const string PluginGuid = "extraVoid.inscryption.RegionExpansions";
		private const string PluginName = "RegionExpansions";
		private const string PluginVersion = "1.1.0";

		public static string Directory;
		internal static ManualLogSource Log;



		private void Awake()
		{

			Log = base.Logger;
			Directory = this.Info.Location.Replace("RegionExpansions.dll", "");

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
			School_Fish.AddCard();

			Regions.Region_Beach.AddRegionIntroDialogue();
			///Regions.Region_Ridgeline.AddRegionIntroDialogue();

		}

		private void Start()
        {
			Regions.Region_Beach.AddRegion();
			///Regions.Region_Ridgeline.AddRegion();
			///

			lib.CreateCardPack.CreatePack();
			Log.LogWarning("ADDED BEACH SUCCESSFULLY");
			Encounter.BirdOfTheSea.AddEncounter();
            Encounter.TideOfFish.AddEncounter();
            Encounter.CrabsAndLobster.AddEncounter();

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