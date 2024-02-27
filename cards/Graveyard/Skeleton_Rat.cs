using DiskCardGame;
using InscryptionAPI.Card;
using InscryptionAPI.Guid;
using InscryptionAPI.Helpers;
using RegionExpansions.cards.Beach;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RegionExpansions.cards.Graveyard
{
    public static class Skeleton_Rat
    {
        public static readonly Ability CustomAbility1 = GuidManager.GetEnumValue<Ability>("ATS", "Bone lord 5");
        public static readonly Ability CustomAbility2 = GuidManager.GetEnumValue<Ability>("ATS", "Pathetic Sacrifice");
        public static void AddCard()
        {
            string modPrefix = "eri";
            string name = "eri_RatSkeleton";
            string displayName = "Rat Skeleton";
            string description = "The remnant of a rat... Can't be picky when you're starving for ressources";
            int baseAttack = 1;
            int baseHealth = 1;
            int bloodCost = 0;
            int boneCost = 4;
            int energyCost = 0;

            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();

            List<Tribe> Tribes = new List<Tribe>();
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(Plugin.TotemGUID))
            {
                Plugin.Log.LogMessage("Lily Totems found, Rat Skeleton is now undead and rodent");
                Tribes.Add(GuidManager.GetEnumValue<Tribe>(Plugin.TotemGUID, "undead"));
                Tribes.Add(GuidManager.GetEnumValue<Tribe>(Plugin.TotemGUID, "rodent"));
            }


            List<Ability> Abilities = new List<Ability>
            {
                CustomAbility1,
                CustomAbility2
            };

            List<Trait> Traits = new List<Trait>();

            Texture2D DefaultTexture = TextureHelper.GetImageAsTexture("eri_RatSkeleton.png", typeof(Plugin).Assembly);
            Texture2D eTexture = TextureHelper.GetImageAsTexture("eri_RatSkeleton_e.png", typeof(Plugin).Assembly);

            CardInfo newCard = SigilUtils.CreateCardWithDefaultSettings(
                ModPrefix: modPrefix,
                InternalName: name,
                DisplayName: displayName,
                attack: baseAttack,
                health: baseHealth,
                texture_base: DefaultTexture,
                texture_emission: eTexture,
                texture_pixel: null,
                cardMetaCategories: metaCategories,
                tribes: Tribes,
                traits: Traits,
                abilities: Abilities,
                bloodCost: bloodCost,
                boneCost: boneCost,
                energyCost: energyCost
                );
            newCard.description = description;
            newCard.SetRare();
            CardManager.Add("eri", newCard);
            Plugin.Log.LogDebug("Added card: " + newCard.name);
        }
    }
}
