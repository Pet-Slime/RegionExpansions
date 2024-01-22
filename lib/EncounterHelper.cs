using System;
using System.Collections.Generic;
using System.Linq;
using DiskCardGame;
using UnityEngine;
using InscryptionAPI.Card;
using InscryptionAPI.Encounters;

namespace RegionExpansions
{
    public class EncounterHelper
    {

        public static EncounterBlueprintData BuildBlueprint(string name, List<Tribe> tribes, List<Ability> redundant, bool regionLocked, int minDifficulty, int maxDifficulty,
            List<CardInfo> randomReplacementCards, List<List<EncounterBlueprintData.CardBlueprint>> blueprintTurns)
        {
            var blueprint = ScriptableObject.CreateInstance<EncounterBlueprintData>();
            blueprint.name = name;
            blueprint.regionSpecific = regionLocked;
            blueprint.SetDifficulty(minDifficulty, maxDifficulty);
            blueprint.dominantTribes = tribes;
            blueprint.redundantAbilities = redundant;
            blueprint.randomReplacementCards = randomReplacementCards;
            blueprint.turns = blueprintTurns;

            return blueprint;
        }


        public static CardInfo GetCardInfo(string self)
        {
            return CardLoader.GetCardByName(self);
        }


        public static RegionData GetRegionData(string RegionName)
        {
            RegionData region = InscryptionAPI.Regions.RegionManager.BaseGameRegions[0];

            for (var index = 0; index < InscryptionAPI.Regions.RegionManager.BaseGameRegions.Count; index++)
            {
                if (InscryptionAPI.Regions.RegionManager.BaseGameRegions[index].name == RegionName)
                {
                    region = InscryptionAPI.Regions.RegionManager.BaseGameRegions[index];
                }
            }

            return region;
        }


        public static EncounterBlueprintData GetBlueprintData(string EncounterName)
        {
            EncounterBlueprintData Encounter = InscryptionAPI.Encounters.EncounterManager.BaseGameEncounters[0];

            for (var index = 0; index < InscryptionAPI.Encounters.EncounterManager.BaseGameEncounters.Count; index++)
            {
                if (InscryptionAPI.Encounters.EncounterManager.BaseGameEncounters[index].name == EncounterName)
                {
                    Encounter = InscryptionAPI.Encounters.EncounterManager.BaseGameEncounters[index];
                }
            }

            return Encounter;
        }

        public static EncounterBlueprintData GetCustomBlueprintData(string EncounterName)
        {
            EncounterBlueprintData Encounter = InscryptionAPI.Encounters.EncounterManager.NewEncounters[0];

            for (var index = 0; index < InscryptionAPI.Encounters.EncounterManager.NewEncounters.Count; index++)
            {
                if (InscryptionAPI.Encounters.EncounterManager.NewEncounters[index].name == EncounterName)
                {
                    Encounter = InscryptionAPI.Encounters.EncounterManager.NewEncounters[index];
                }
            }

            return Encounter;
        }


        public static List<CardInfo> AddRandomCards(string turn1 = "none", string turn2 = "none", string turn3 = "none", string turn4 = "none", string turn5 = "none", string turn6 = "none", string turn7 = "none", string turn8 = "none", string turn9 = "none")
        {

            List<CardInfo> randomReplacements = new List<CardInfo>();
            if (turn1 != "none")
            {
                randomReplacements.Add(CardLoader.GetCardByName(turn1));
            }
            else
            {
                return randomReplacements;
            }
            if (turn2 != "none")
            {
                randomReplacements.Add(CardLoader.GetCardByName(turn2));
            }
            else
            {
                return randomReplacements;
            }
            if (turn3 != "none")
            {
                randomReplacements.Add(CardLoader.GetCardByName(turn3));
            }
            else
            {
                return randomReplacements;
            }
            if (turn4 != "none")
            {
                randomReplacements.Add(CardLoader.GetCardByName(turn4));
            }
            else
            {
                return randomReplacements;
            }
            if (turn5 != "none")
            {
                randomReplacements.Add(CardLoader.GetCardByName(turn5));
            }
            else
            {
                return randomReplacements;
            }
            if (turn6 != "none")
            {
                randomReplacements.Add(CardLoader.GetCardByName(turn6));
            }
            else
            {
                return randomReplacements;
            }
            if (turn7 != "none")
            {
                randomReplacements.Add(CardLoader.GetCardByName(turn7));
            }
            else
            {
                return randomReplacements;
            }
            if (turn8 != "none")
            {
                randomReplacements.Add(CardLoader.GetCardByName(turn8));
            }
            else
            {
                return randomReplacements;
            }
            if (turn9 != "none")
            {
                randomReplacements.Add(CardLoader.GetCardByName(turn9));
            }
            else
            {
                return randomReplacements;
            }
            return randomReplacements;
        }

    }
}