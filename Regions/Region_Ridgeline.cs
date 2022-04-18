using System.Collections.Generic;
using InscryptionAPI.Encounters;
using InscryptionAPI.Regions;
using DiskCardGame;
using UnityEngine;

namespace RegionExpansions.Regions
{
    internal class Region_Ridgeline
    {

        public static void AddRegionIntroDialogue()
        {
            var Initial = new List<CustomLine>();
            Initial.Add(("Pines and bare rock formations jet up from the ground.", DialogueEvent.Speaker.Leshy));
            Initial.Add(("You hear a mining off in the distance.", DialogueEvent.Speaker.Leshy));
            Initial.Add(("To get to the source, you must pass through... [c:bR]The Ridgeline[c:]", DialogueEvent.Speaker.Leshy));

            var repeat1 = new List<CustomLine>();
            repeat1.Add(("You see a glint of gold among the rocks above.", DialogueEvent.Speaker.Leshy));
            repeat1.Add(("As you climb for it, a rock slips out from under your foot and you tumble down.", DialogueEvent.Speaker.Leshy));
            repeat1.Add(("When you get back up, you decide to ignore it and continue on thrhough... [c:bR]The Ridgeline[c:]", DialogueEvent.Speaker.Leshy));

            var repeatLines = new List<List<CustomLine>>();
            repeatLines.Add(repeat1);

            DialogueEventGenerator.GenerateEvent("RegionRidgeline", Initial, repeatLines, DialogueEvent.MaxRepeatsBehaviour.RandomDefinedRepeat, "Game Flow", TextDisplayer.LetterAnimation.WavyJitter, TextDisplayer.LetterAnimation.WavyJitter);
        }


        public static void AddRegion()
        {

            var pirateRegionBase = EncounterHelper.GetRegionData("Forest");
            var wetlandRegionBase = EncounterHelper.GetRegionData("Wetlands");

            var PineTree = pirateRegionBase.fillerScenery[0].data.Clone();
            var RockColumn = pirateRegionBase.scarceScenery[0].data.Clone();
            var PineTree2 = wetlandRegionBase.fillerScenery[0].data.Clone();

            ///PalmTree
            Plugin.Log.LogMessage(PineTree2.prefabNames[0]);

            Texture2D test = (Texture2D)pirateRegionBase.mapEmission;

            FillerSceneryEntry fillerData = new FillerSceneryEntry();
            fillerData.data = PineTree;
            fillerData.data.name = RockColumn.name;
            fillerData.data.prefabNames = RockColumn.prefabNames;
            fillerData.data.minScale = new Vector2(0.05f, 0.01f);
            fillerData.data.maxScale = new Vector2(0.1f, 0.02f);
            fillerData.data.radius = fillerData.data.radius * 1.75F;

            ScarceSceneryEntry palmtree = new ScarceSceneryEntry();
            palmtree.data = RockColumn;
            palmtree.minDensity = 100 * 5;
            palmtree.minInstances = 10 * 5;
            palmtree.maxInstances = 20 * 5;
            palmtree.data.minScale = palmtree.data.minScale * 2F;
            palmtree.data.maxScale = palmtree.data.maxScale * 2F;
            palmtree.data.radius = palmtree.data.radius * 0.25F;
            palmtree.data.name = PineTree2.name;
            palmtree.data.prefabNames = PineTree2.prefabNames;


            var boardlight = Color.gray;
            var cardlight = Color.grey;
            var mapAlbendo = pirateRegionBase.mapAlbedo;

            RegionManager.New("Ridgeline", 0, true)
                .SetBoardColor(boardlight)
                .SetCardsColor(cardlight)
                .AddFillerScenery(fillerData)
                .AddScarceScenery(palmtree, palmtree, palmtree)
                .SetMapAlbedo(mapAlbendo)
                .SetMapEmission(test)
                .SetAmbientLoopId("boss_prospector_ambient")
                .SetMapEmissionColor(pirateRegionBase.mapEmissionColor)
                .SetFogAlpha(pirateRegionBase.fogAlpha)
                .SetFogEnabled(pirateRegionBase.fogEnabled)
                .SetDustParticlesEnabled(false)
                .AddBosses(Opponent.Type.ProspectorBoss)
                .AddDominantTribes(Tribe.Canine, Tribe.Hooved)
                .AddEncounters(EncounterHelper.GetBlueprintData("CoyotePack"), EncounterHelper.GetBlueprintData("WolfPack"), EncounterHelper.GetBlueprintData("DireWolfJuggernaut"), EncounterHelper.GetBlueprintData("ElkHerd"), EncounterHelper.GetBlueprintData("MooseJuggernaut"), EncounterHelper.GetBlueprintData("WildBulls"))
                .AddTerrainCards("Boulder", "GoldNugget")
                .Build();
        }
    }
}
