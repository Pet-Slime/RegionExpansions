using System;
using System.Collections.Generic;
using System.Text;
using InscryptionAPI.Card;
using InscryptionAPI.Encounters;
using InscryptionAPI.Regions;
using DiskCardGame;
using UnityEngine;
using VolumetricFogAndMist;

namespace RegionExpansions.Regions
{
    internal class RegionDataDump
    {
        public static void DumpRegionData()
        {


			Plugin.Log.LogMessage("Dumping Region Data");
			for (var index = 0; index < InscryptionAPI.Regions.RegionManager.BaseGameRegions.Count; index++)
			{
				var region = InscryptionAPI.Regions.RegionManager.BaseGameRegions[index];
				Plugin.Log.LogMessage("Dumping Region Data, region " + index);
				Plugin.Log.LogMessage("Dumping Region Data, region " + index + " name is:" + region.name);
				for (var index_B = 0; index_B < region.bosses.Count; index_B++)
				{
					Plugin.Log.LogMessage("Dumping Region Data, region " + index + " boss is:" + region.bosses[index_B]);
				}
				Plugin.Log.LogMessage("Dumping Region Data, region " + index + " bossPrepCondition is:" + region.bossPrepCondition);
				Plugin.Log.LogMessage("Dumping Region Data, region " + index + " ambientLoopId is:" + region.ambientLoopId);
				Plugin.Log.LogMessage("Dumping Region Data, region " + index + " boardLightColor is:" + region.boardLightColor);
				Plugin.Log.LogMessage("Dumping Region Data, region " + index + " cardsLightColor is:" + region.cardsLightColor);
				for (var index_B = 0; index_B < region.consumableItems.Count; index_B++)
				{
					Plugin.Log.LogMessage("Dumping Region Data, region " + index + " consumableItems is:" + region.consumableItems[index_B]);
				}
				for (var index_B = 0; index_B < region.dominantTribes.Count; index_B++)
				{
					Plugin.Log.LogMessage("Dumping Region Data, region " + index + " dominantTribes is:" + region.dominantTribes[index_B]);
				}
				Plugin.Log.LogMessage("Dumping Region Data, region " + index + " dustParticlesDisabled is:" + region.dustParticlesDisabled);
				for (var index_B = 0; index_B < region.encounters.Count; index_B++)
				{
					Plugin.Log.LogMessage("Dumping Region Data, region " + index + " encounters is:" + region.encounters[index_B]);
				}
				for (var index_B = 0; index_B < region.fillerScenery.Count; index_B++)
				{
					Plugin.Log.LogMessage("Dumping Region Data, region " + index + " fillerScenery is:" + region.fillerScenery[index_B]);
					if (region.fillerScenery[index_B].data.name != null)
					{
						Plugin.Log.LogMessage("Dumping Region Data, region " + index + " fillerScenery.data.name is:" + region.fillerScenery[index_B].data.name);
					}
				}
				Plugin.Log.LogMessage("Dumping Region Data, region " + index + " fogAlpha is:" + region.fogAlpha);
				Plugin.Log.LogMessage("Dumping Region Data, region " + index + " fogEnabled is:" + region.fogEnabled);
				Plugin.Log.LogMessage("Dumping Region Data, region " + index + " fogProfile is:" + region.fogProfile);
				for (var index_B = 0; index_B < region.likelyCards.Count; index_B++)
				{
					Plugin.Log.LogMessage("Dumping Region Data, region " + index + " likelyCards is:" + region.likelyCards[index_B]);
				}
				Plugin.Log.LogMessage("Dumping Region Data, region " + index + " mapAlbedo is:" + region.mapAlbedo);
				Plugin.Log.LogMessage("Dumping Region Data, region " + index + " mapEmission is:" + region.mapEmission);
				Plugin.Log.LogMessage("Dumping Region Data, region " + index + " mapEmissionColor is:" + region.mapEmissionColor);
				for (var index_B = 0; index_B < region.mapParticlesPrefabs.Count; index_B++)
				{
					Plugin.Log.LogMessage("Dumping Region Data, region " + index + " mapParticlesPrefabs is:" + region.mapParticlesPrefabs[index_B]);
				}
				Plugin.Log.LogMessage("Dumping Region Data, region " + index + " predefinedNodes is:" + region.predefinedNodes);
				if (region.predefinedScenery != null)
				{
					for (var index_B = 0; index_B < region.predefinedScenery.scenery.Count; index_B++)
					{
						Plugin.Log.LogMessage("Dumping Region Data, region " + index + " predefinedScenery is:" + region.predefinedScenery.scenery[index_B].data.name);
					}

				}
				for (var index_B = 0; index_B < region.scarceScenery.Count; index_B++)
				{
					Plugin.Log.LogMessage("Dumping Region Data, region " + index + " scarceScenery is:" + region.scarceScenery[index_B]);
					if (region.scarceScenery[index_B].data.name != null)
					{
						Plugin.Log.LogMessage("Dumping Region Data, region " + index + " scarceScenery.data.name is:" + region.scarceScenery[index_B].data.name);
					}
				}
				for (var index_B = 0; index_B < region.terrainCards.Count; index_B++)
				{
					Plugin.Log.LogMessage("Dumping Region Data, region " + index + " terrainCards is:" + region.terrainCards[index_B]);
				}

				for (var index_B = 0; index_B < region.encounters.Count; index_B++)
				{
					Plugin.Log.LogMessage("Dumping Region Data, region " + index + " terrainCards is:" + region.encounters[index_B].name);
				}
			}
		}
    }
}
