using DiskCardGame;
using InscryptionAPI.Encounters;
using InscryptionAPI.Guid;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegionExpansions.Regions.Graveyard.Encounters
{
    internal class UndeadElks
    {
        public static void AddEncounter()
        {
            //Name of the encounter
            string name = "UndeadElks";

            //Vanilla region names are: Forest, Wetlands, and Alpine
            string regionName = "Graveyard";

            //What is the most common tribe?
            List<Tribe> dominate = new List<Tribe>();
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(Plugin.TotemGUID))
            {
                dominate.Add(GuidManager.GetEnumValue<Tribe>(Plugin.TotemGUID, "undead"));
            }
            else
            {
                dominate.Add(Tribe.Hooved);
            }

            //Are any abilities redundent? Thus shouldnt be used on a totem
            List<Ability> redundant = new List<Ability>();
            redundant.Add(Ability.Strafe);

            //Is this encounter locked to a region?
            bool regionLocked = true;

            //Add random Replacements
            List<CardInfo> randomReplacements = EncounterHelper.AddRandomCards("Long Elk");


            //Encounter by turns
            List<List<EncounterBlueprintData.CardBlueprint>> turns = new List<List<EncounterBlueprintData.CardBlueprint>>();

            List<EncounterBlueprintData.CardBlueprint> turn_1 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_1.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("eri_RatSkeleton")
            });

            List<EncounterBlueprintData.CardBlueprint> turn_2 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_2.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = null,
                difficultyReplace = true,
                difficultyReq = 13,
                replacement = CardLoader.GetCardByName("eri_ElkSkeleton")
            });
            turn_2.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("eri_RatSkeleton")
            });

            List<EncounterBlueprintData.CardBlueprint> turn_3 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_3.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("eri_RatSkeleton")
            });

            List<EncounterBlueprintData.CardBlueprint> turn_4 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_4.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("eri_ElkSkeleton"),
                randomReplaceChance = 25
            });
            turn_4.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = null,
                difficultyReplace = true,
                difficultyReq = 18,
                replacement = CardLoader.GetCardByName("eri_ElkSkeleton")
            });
            turn_4.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("eri_ElkSkeleton")
            });

            List<EncounterBlueprintData.CardBlueprint> turn_5 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_5.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("eri_ElkSkeleton"),
                randomReplaceChance = 25
            });
            turn_5.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("eri_ElkSkeleton"),
                randomReplaceChance = 25
            });
            turn_5.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("eri_ElkSkeleton")
            });
            List<EncounterBlueprintData.CardBlueprint> turn_6 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_6.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("eri_ElkSkeleton"),
                randomReplaceChance = 25
            });
            turn_6.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = null,
                difficultyReplace = true,
                difficultyReq = 18,
                replacement = CardLoader.GetCardByName("eri_ElkSkeleton")
            });
            turn_6.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = null,
                difficultyReplace = true,
                difficultyReq = 13,
                replacement = CardLoader.GetCardByName("eri_ElkSkeleton")
            });
            List<EncounterBlueprintData.CardBlueprint> turn_7 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_7.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("eri_ElkSkeleton"),
                randomReplaceChance = 25
            });
            turn_7.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("eri_ElkSkeleton"),
                randomReplaceChance = 25
            });


            turns.Add(turn_1);
            turns.Add(turn_2);
            turns.Add(turn_3);
            turns.Add(turn_4);
            turns.Add(turn_5);
            turns.Add(turn_6);
            turns.Add(turn_7);


            var encounter = EncounterHelper.BuildBlueprint(name, dominate, redundant, regionLocked, 0, 30, randomReplacements, turns);

            EncounterManager.Add(encounter);

            ///   InscryptionAPI.Regions.RegionExtensions.AddEncounters(EncounterHelper.GetRegionData(regionName), encounter);

        }
    }
}
