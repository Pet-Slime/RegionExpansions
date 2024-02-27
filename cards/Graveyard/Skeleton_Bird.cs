using DiskCardGame;
using GBC;
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
    public static class Skeleton_Bird
    {
        public static readonly Ability CustomAbility1 = GuidManager.GetEnumValue<Ability>("ATS", "Take-Off (Bones)");
        public static readonly Ability CustomAbility2 = GuidManager.GetEnumValue<Ability>("ATS", "Pathetic Sacrifice");
        public static void AddCard()
        {
            string name = "eri_BirdSkeleton";
            string displayName = "Bird Skeleton";
            string description = "The remnant of a bird, no longer will it fly";
            int baseAttack = 1;
            int baseHealth = 1;
            int bloodCost = 0;
            int boneCost = 2;
            int energyCost = 0;
            string BoTribe = "undead";

            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>
            {
                CardMetaCategory.ChoiceNode,
                CardMetaCategory.TraderOffer
            };

            List<Tribe> Tribes = new List<Tribe>();
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(Plugin.TotemGUID))
            {
                Plugin.Log.LogMessage("Lily Totems found, " + name + " is now " + BoTribe);
                Tribes.Add(GuidManager.GetEnumValue<Tribe>(Plugin.TotemGUID, BoTribe));
            }


            List<Ability> Abilities = new List<Ability>
            {
                CustomAbility1,
                CustomAbility2
            };

            List<Trait> Traits = new List<Trait>();

            Texture2D DefaultTexture = TextureHelper.GetImageAsTexture("eri_BirdSkeleton.png", typeof(Plugin).Assembly);
            Texture2D eTexture = TextureHelper.GetImageAsTexture("eri_BirdSkeleton_e.png", typeof(Plugin).Assembly);

            CardInfo newCard = SigilUtils.CreateCardWithDefaultSettings(
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
            CardManager.Add("eri", newCard);
        }
    }
}
