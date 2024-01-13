using System.Collections.Generic;
using InscryptionAPI.Encounters;
using InscryptionAPI.Regions;
using DiskCardGame;
using UnityEngine;

namespace RegionExpansions.Regions
{
    internal class Region_Beach
    {

        public static void AddRegionIntroDialogue()
        {
            var Initial = new List<CustomLine>();
            Initial.Add(("In the distance, you hear what sounds like singing... 'heave, ho'", DialogueEvent.Speaker.Leshy));
            Initial.Add(("Your curiosity of it brought you here to this place.", DialogueEvent.Speaker.Leshy));
            Initial.Add(("To get to the source, you must pass through... [c:bR]The Shoreline[c:]", DialogueEvent.Speaker.Leshy));

            var repeat1 = new List<CustomLine>();
            repeat1.Add(("The smell of salt water assults your nose...", DialogueEvent.Speaker.Leshy));
            repeat1.Add(("as the sound of waves crash apon the sand.", DialogueEvent.Speaker.Leshy));
            repeat1.Add(("You journey on in... [c:bR]The Shoreline[c:]", DialogueEvent.Speaker.Leshy));

            var repeat2 = new List<CustomLine>();
            repeat2.Add(("The sea is calm.", DialogueEvent.Speaker.Leshy));
            repeat2.Add(("The tide is full", DialogueEvent.Speaker.Leshy));
            repeat2.Add(("You walk along... [c:bR]The Shoreline[c:]", DialogueEvent.Speaker.Leshy));

            var repeat3 = new List<CustomLine>();
            repeat3.Add(("The coarse sand on the beach entered your boots...", DialogueEvent.Speaker.Leshy));
            repeat3.Add(("You continued your travels despite the irritation...", DialogueEvent.Speaker.Leshy));
            repeat3.Add(("You tread through... [c:bR]The Shoreline.[c:]", DialogueEvent.Speaker.Leshy));

            var repeatLines = new List<List<CustomLine>>();
            repeatLines.Add(repeat1);
            repeatLines.Add(repeat2);
            repeatLines.Add(repeat3);

            DialogueEventGenerator.GenerateEvent("RegionBeach", Initial, repeatLines, DialogueEvent.MaxRepeatsBehaviour.RandomDefinedRepeat, "Game Flow", TextDisplayer.LetterAnimation.WavyJitter, TextDisplayer.LetterAnimation.WavyJitter);
        }


        public static void AddRegion()
        {

            var pirateRegionBase = EncounterHelper.GetRegionData("Pirateville");

            var fernClone = pirateRegionBase.fillerScenery[0].data.Clone();
            var palmtreeClone = pirateRegionBase.predefinedScenery.scenery[0].data.Clone();
            var treasutreClone = pirateRegionBase.predefinedScenery.scenery[7].data.Clone();

            ///PalmTree


            Texture2D test = (Texture2D)pirateRegionBase.mapEmission;

            FillerSceneryEntry fillerData = new FillerSceneryEntry();
            fillerData.data = fernClone;
            fillerData.data.radius = fillerData.data.radius * 1.5F;

            ScarceSceneryEntry palmtree = new ScarceSceneryEntry();
            palmtree.data = palmtreeClone;
            palmtree.minDensity = 100 * 2;
            palmtree.minInstances = 10 * 2;
            palmtree.maxInstances = 20 * 2;
            palmtree.data.name = "PalmTree";
            palmtree.data.prefabNames = new List<string> { "PalmTree" };
            palmtree.data.radius = 0.065F;
            palmtree.data.perlinNoiseHeight = false;

            ScarceSceneryEntry treastureChest = new ScarceSceneryEntry();
            treastureChest.data = treasutreClone;
            treastureChest.minDensity = 25;
            treastureChest.minInstances = 5;
            treastureChest.maxInstances = 10;
            treastureChest.data.name = "TreasureChest";
            treastureChest.data.prefabNames = new List<string> { "TreasureChest" };
            treastureChest.data.maxScale = new Vector2(1.5F, 1.5F);
            treastureChest.data.minScale = new Vector2(0.5F, 0.5F);
            treastureChest.data.baseEulers = new Vector3(-90.0F, 0.0F, 0.0F);
            treastureChest.data.radius = 0.05F;
            treastureChest.data.perlinNoiseHeight = false;


            var boardlight = pirateRegionBase.boardLightColor;
            var cardlight = pirateRegionBase.cardsLightColor;
            var mapAlbendo = pirateRegionBase.mapAlbedo;

            RegionManager.New("Beach", 2, true)
                .SetBoardColor(boardlight)
                .SetCardsColor(cardlight)
                .AddFillerScenery(fillerData)
                .AddScarceScenery(palmtree, treastureChest)
                .SetMapAlbedo(mapAlbendo)
                .SetMapEmission(test)
                .SetAmbientLoopId("boss_pirateskull_ambient")
                .SetMapEmissionColor(pirateRegionBase.mapEmissionColor)
                .SetFogAlpha(pirateRegionBase.fogAlpha)
                .SetFogEnabled(pirateRegionBase.fogEnabled)
                .SetDustParticlesEnabled(false)
                .AddBosses(Opponent.Type.PirateSkullBoss)
                .AddDominantTribes(Tribe.Bird)
                .AddEncounters(EncounterHelper.GetBlueprintData("Submerge"), EncounterHelper.GetBlueprintData("BirdFlock"))
                .AddLikelyCards("Kingfisher")
                .AddLikelyCards("portrait_skeletonparrot")
                .AddTerrainCards("re_High_Tide", "re_Strong_Wind_1","Boulder", "re_Low_Tide")
                .Build();

        }
    }
}
