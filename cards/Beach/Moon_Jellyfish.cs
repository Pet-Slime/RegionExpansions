using System.Collections.Generic;
using DiskCardGame;
using UnityEngine;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;
using InscryptionAPI.Guid;
using GBC;

namespace RegionExpansions.cards.Beach
{
    public static class Moon_Jellyfish
    {
        public static readonly Ability CustomAbility1 = GuidManager.GetEnumValue<Ability>("extraVoid.inscryption.voidSigils", "Submerged Ambush");
        public static void AddCard()
        {
            string name = "re_Moon_Jellyfish";
            string displayName = "Moon Jellyfish";
            string description = "A crab with a thick shell.";
            int baseAttack = 1;
            int baseHealth = 1;
            int bloodCost = 1;
            int boneCost = 0;
            int energyCost = 0;
            string BoTribe = "aquatic";

            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
            metaCategories.Add(CardMetaCategory.ChoiceNode);
            metaCategories.Add(CardMetaCategory.TraderOffer);

            List<Tribe> Tribes = new List<Tribe>();
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(Plugin.TotemGUID))
            {
                Plugin.Log.LogMessage("Lily Totems found, " + name + " is now " + BoTribe);
                Tribes.Add(GuidManager.GetEnumValue<Tribe>(Plugin.TotemGUID, BoTribe));
            }

            List<Ability> Abilities = new List<Ability>();
            Abilities.Add(CustomAbility1);
            Abilities.Add(Ability.Submerge);

            List<Trait> Traits = new List<Trait>();

            Texture2D DefaultTexture = TextureHelper.GetImageAsTexture("re_Jellyfish.png", typeof(Plugin).Assembly);
            Texture2D eTexture = TextureHelper.GetImageAsTexture("re_Jellyfish_e.png", typeof(Plugin).Assembly);

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
            CardManager.Add("re", newCard);
        }
    }
}
