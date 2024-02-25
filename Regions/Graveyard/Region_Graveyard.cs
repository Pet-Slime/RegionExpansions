using System.Collections.Generic;
using InscryptionAPI.Encounters;
using InscryptionAPI.Regions;
using DiskCardGame;
using UnityEngine;

namespace RegionExpansions.Regions.Graveyard
{
    internal class Region_Graveyard
    {

        private static List<string> Graves = new List<string>
            {
                "gravestone_1",
                "gravestone_2",
                "gravestone_3",
                "coffin"
            };


        public static RegionData regionData;

        public static void AddRegionIntroDialogue()
        {
            var Initial = new List<CustomLine>();
            Initial.Add(("The fog rolls in.", DialogueEvent.Speaker.Leshy));
            Initial.Add(("The air stands still.", DialogueEvent.Speaker.Leshy));
            Initial.Add(("You have entered [c:bR]The Graveyard[c:]", DialogueEvent.Speaker.Leshy));

            var repeat1 = new List<CustomLine>();
            repeat1.Add(("The fog rolls in.", DialogueEvent.Speaker.Leshy));
            repeat1.Add(("The air stands still.", DialogueEvent.Speaker.Leshy));
            repeat1.Add(("You have entered [c:bR]The Graveyard[c:]", DialogueEvent.Speaker.Leshy));

            var repeatLines = new List<List<CustomLine>>();
            repeatLines.Add(repeat1);

            DialogueEventGenerator.GenerateEvent("RegionGraveyard", Initial, repeatLines, DialogueEvent.MaxRepeatsBehaviour.RandomDefinedRepeat, "Game Flow", TextDisplayer.LetterAnimation.WavyJitter, TextDisplayer.LetterAnimation.WavyJitter);
        }


        public static void AddRegion()
        {

            var forestRegionBase = EncounterHelper.GetRegionData("Forest");
            var wetlandRegionBase = EncounterHelper.GetRegionData("Wetlands");
            var alpineRegionBase = EncounterHelper.GetRegionData("Alpine");

            Texture2D test = (Texture2D)alpineRegionBase.mapEmission;



            var boardlight = Color.magenta;
            var cardlight = forestRegionBase.cardsLightColor;
            var mapAlbendo = wetlandRegionBase.mapAlbedo;

            regionData = RegionManager.New("Graveyard", 1, true)
                .SetBoardColor(boardlight)
                .SetCardsColor(cardlight)
                .SetMapAlbedo(mapAlbendo)
                .SetMapEmission(test)
                .SetAmbientLoopId("ambient_snowline")
                .SetMapEmissionColor(forestRegionBase.mapEmissionColor)
                .SetFogProfile(alpineRegionBase.fogProfile)
                .SetFogAlpha(forestRegionBase.fogAlpha)
                .SetFogEnabled(forestRegionBase.fogEnabled)
                .SetDustParticlesEnabled(true)
                .AddBosses(Plugin.GravekeeperBoss)
                .AddDominantTribes(Tribe.Canine, Tribe.Hooved)
                .AddEncounters(EncounterHelper.GetBlueprintData("CoyotePack"), EncounterHelper.GetBlueprintData("WolfPack"), EncounterHelper.GetBlueprintData("DireWolfJuggernaut"), EncounterHelper.GetBlueprintData("ElkHerd"), EncounterHelper.GetBlueprintData("MooseJuggernaut"), EncounterHelper.GetBlueprintData("WildBulls"))
                .AddTerrainCards("Boulder", "GoldNugget")
                .Build();

            Regions.Region_Graveyard.regionData.fillerScenery = Regions.Region_Graveyard.GetFillerScenery();
            Regions.Region_Graveyard.regionData.scarceScenery = Regions.Region_Graveyard.GetScarceScenery();
        }

        private static List<FillerSceneryEntry> GetFillerScenery()
        {
            List<FillerSceneryEntry> list = new List<FillerSceneryEntry>();
            FillerSceneryEntry fillerSceneryEntry = new FillerSceneryEntry();
            fillerSceneryEntry.data = RegionManager.BaseGameRegions.RegionByName("Alpine").scarceScenery[1].data.Clone();
            fillerSceneryEntry.data.radius *= 2.5f;
            list.Add(fillerSceneryEntry);
            return list;
        }

        private static List<ScarceSceneryEntry> GetScarceScenery()
        {
            List<ScarceSceneryEntry> list = new List<ScarceSceneryEntry>();
            ScarceSceneryEntry scarceSceneryGraves = new ScarceSceneryEntry
            {
                minInstances = 20,
                maxInstances = 30,
                minDensity = 0.05f
            };
            SceneryData data = ScriptableObject.CreateInstance<SceneryData>();
            scarceSceneryGraves.data = data;
            scarceSceneryGraves.data.minScale = new Vector2(0.35f, 0.35f);
            scarceSceneryGraves.data.maxScale = new Vector2(0.35f, 0.35f);
            scarceSceneryGraves.data.prefabNames = Region_Graveyard.ConvertNames(Region_Graveyard.Graves);
            scarceSceneryGraves.data.radius = 0.04f;
            list.Add(scarceSceneryGraves);
            return list;
        }

        private static List<string> ConvertNames(List<string> s)
        {
            List<string> list = new List<string>(s.Count);
            foreach (string str in s)
            {
                list.Add("Graveyard_RE_" + str);
            }
            return list;
        }

        public static void LoadGameObjects()
        {
            List<string> list = new List<string>();
            list.AddRange(Region_Graveyard.Graves);
            foreach (string text in list)
            {
                GameObject gameObject = Plugin.RegionExpansionBundle.LoadAsset<GameObject>(text);
                bool flag = gameObject != null;
                if (flag)
                {
                    bool flag2 = gameObject.GetComponent<MapElement>() == null;
                    if (flag2)
                    {
                        gameObject.AddComponent<MapElement>();
                    }
                    ResourceBank.instance.resources.Add(new ResourceBank.Resource
                    {
                        path = "Prefabs/Map/MapScenery/Graveyard_RE_" + text,
                        asset = gameObject
                    });
                }
            }
        }
    }
}
