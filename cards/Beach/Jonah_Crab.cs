using System.Collections.Generic;
using DiskCardGame;
using UnityEngine;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;
using InscryptionAPI.Guid;

namespace RegionExpansions.cards.Beach
{
    public static class Jonah_Crab
    {
        public static readonly Ability CustomAbility1 = GuidManager.GetEnumValue<Ability>("ATS", "Thick Shell");
        public static void AddCard()
        {
            string modPrefix = "re";
            string name = "re_Jonah_Crab";
            string displayName = "Jonah Crab";
            string description = "A crab with a thick shell.";
            int baseAttack = 1;
            int baseHealth = 1;
            int bloodCost = 1;
            int boneCost = 0;
            int energyCost = 0;
            string BoTribe = "aquatic";

            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>
            {
                CardMetaCategory.ChoiceNode,
                CardMetaCategory.TraderOffer
            };

            List<Tribe> Tribes = new List<Tribe>();
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(Plugin.TotemGUID))
            {
                Plugin.Log.LogMessage("Lily Totems found, Jonah Crab is now aquatic");
                Tribes.Add(GuidManager.GetEnumValue<Tribe>("Lily.BOT", "aquatic"));
            }
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(Plugin.NeverGUID))
            {
                Plugin.Log.LogMessage("Never stuff found, Jonah Crab is now Crustacean");
                Tribes.Add(GuidManager.GetEnumValue<Tribe>(Plugin.NeverGUID, "Crustacean"));
            }

            List<Ability> Abilities = new List<Ability>
            {
                CustomAbility1
            };

            List<Trait> Traits = new List<Trait>();

            Texture2D DefaultTexture = TextureHelper.GetImageAsTexture("re_Crab.png", typeof(Plugin).Assembly);
            Texture2D eTexture = TextureHelper.GetImageAsTexture("re_Crab_e.png", typeof(Plugin).Assembly);

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
            CardManager.Add("re", newCard);
            Plugin.Log.LogDebug("Added card: " + newCard.name);
        }
    }
}
