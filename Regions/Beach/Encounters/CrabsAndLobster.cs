using DiskCardGame;
using InscryptionAPI.Encounters;
using InscryptionAPI.Guid;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegionExpansions.Regions.Beach.Encounters
{
    internal class UndeadRush
    {
        public static void AddEncounter()
        {
            //Name of the encounter
            string name = "CrabsAndLobster";

            //Vanilla region names are: Forest, Wetlands, and Alpine
            string regionName = "Beach";

            //What is the most common tribe?
            List<Tribe> dominate = new List<Tribe>();
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(Plugin.TotemGUID))
            {
                dominate.Add(GuidManager.GetEnumValue<Tribe>(Plugin.TotemGUID, "aquatic"));
            }
            else
            {
                dominate.Add(Tribe.Bird);
            }

            //Are any abilities redundent? Thus shouldnt be used on a totem
            List<Ability> redundant = new List<Ability>();
            redundant.Add(Ability.Submerge);

            //Is this encounter locked to a region?
            bool regionLocked = true;

            //Add random Replacements
            List<CardInfo> randomReplacements = EncounterHelper.AddRandomCards("re_Starfish", "Shark", "Kingfisher", "re_Moon_Jellyfish");


            //Encounter by turns
            List<List<EncounterBlueprintData.CardBlueprint>> turns = new List<List<EncounterBlueprintData.CardBlueprint>>();

            List<EncounterBlueprintData.CardBlueprint> turn_1 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_1.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("re_Jonah_Crab")
            });
            turn_1.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("Kingfisher")
            });

            List<EncounterBlueprintData.CardBlueprint> turn_2 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_2.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("Kingfisher"),
                difficultyReplace = true,
                difficultyReq = 13,
                replacement = CardLoader.GetCardByName("re_American_Lobster"),
                randomReplaceChance = 25
            });

            List<EncounterBlueprintData.CardBlueprint> turn_3 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_3.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("re_Jonah_Crab"),
                difficultyReplace = true,
                difficultyReq = 12,
                replacement = CardLoader.GetCardByName("re_Starfish"),
                randomReplaceChance = 25
            });
            turn_3.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("re_Jonah_Crab"),
                difficultyReplace = true,
                difficultyReq = 19,
                replacement = CardLoader.GetCardByName("re_American_Lobster"),
                randomReplaceChance = 25
            });

            List<EncounterBlueprintData.CardBlueprint> turn_4 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_4.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = CardLoader.GetCardByName("Kingfisher"),
                difficultyReplace = true,
                difficultyReq = 13,
                replacement = CardLoader.GetCardByName("re_Jonah_Crab"),
                randomReplaceChance = 25
            });

            List<EncounterBlueprintData.CardBlueprint> turn_5 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_5.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = null,
                difficultyReplace = true,
                difficultyReq = 15,
                replacement = CardLoader.GetCardByName("re_Jonah_Crab"),
                randomReplaceChance = 25
            });
            List<EncounterBlueprintData.CardBlueprint> turn_6 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_6.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = null,
                difficultyReplace = true,
                difficultyReq = 17,
                replacement = CardLoader.GetCardByName("re_American_Lobster"),
                randomReplaceChance = 25
            });
            List<EncounterBlueprintData.CardBlueprint> turn_7 = new List<EncounterBlueprintData.CardBlueprint>();
            turn_7.Add(new EncounterBlueprintData.CardBlueprint
            {
                card = null,
                difficultyReplace = true,
                difficultyReq = 19,
                replacement = CardLoader.GetCardByName("Shark"),
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

            //  InscryptionAPI.Regions.RegionExtensions.AddEncounters(EncounterHelper.GetRegionData(regionName), encounter);

        }
    }
}
