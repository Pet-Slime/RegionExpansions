using System.Collections.Generic;
using DiskCardGame;
using UnityEngine;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;
using InscryptionAPI.Guid;
using GBC;

namespace RegionExpansions.cards.Beach
{
    public static class Starfish
    {
        public static readonly Ability CustomAbility1 = GuidManager.GetEnumValue<Ability>("extraVoid.inscryption.voidSigils", "Sluggish");
        public static readonly Ability CustomAbility2 = GuidManager.GetEnumValue<Ability>("extraVoid.inscryption.voidSigils", "Regen 2");
        public static void AddCard()
        {
            string modPrefix = "re";
            string name = "re_Starfish";
            string displayName = "Beach Star";
            string description = "A starfish found in tidepools. They love to consume crab.";
            int baseAttack = 1;
            int baseHealth = 4;
            int bloodCost = 2;
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
                Plugin.Log.LogMessage("Lily Totems found, " + name + " is now " + BoTribe);
                Tribes.Add(GuidManager.GetEnumValue<Tribe>(Plugin.TotemGUID, BoTribe));
            }

            List<Ability> Abilities = new List<Ability>
            {
                CustomAbility1,
                CustomAbility2
            };

            List<Trait> Traits = new List<Trait>();

            Texture2D DefaultTexture = TextureHelper.GetImageAsTexture("re_Starfish.png", typeof(Plugin).Assembly);
            Texture2D eTexture = TextureHelper.GetImageAsTexture("re_Starfish_e.png", typeof(Plugin).Assembly);

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
