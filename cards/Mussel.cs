using System.Collections.Generic;
using DiskCardGame;
using UnityEngine;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;
using InscryptionAPI.Guid;

namespace RegionExpansions.cards
{
	public static class Mussel
	{
		public static readonly Ability CustomAbility1 = InscryptionAPI.Guid.GuidManager.GetEnumValue<Ability>("extraVoid.inscryption.voidSigils", "Sluggish");
        public static readonly Ability CustomAbility2 = InscryptionAPI.Guid.GuidManager.GetEnumValue<Ability>("extraVoid.inscryption.voidSigils", "Sticky");
        public static void AddCard()
		{
			string name = "re_Mussel";
			string displayName = "Rock Mussel";
			string description = "A mussel that can stick to anything.";
			int baseAttack = 0;
			int baseHealth = 3;
			int bloodCost = 1;
			int boneCost = 0;
			int energyCost = 0;

			List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
			metaCategories.Add(CardMetaCategory.ChoiceNode);
			metaCategories.Add(CardMetaCategory.TraderOffer);

			List<Tribe> Tribes = new List<Tribe>();
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(Plugin.TotemGUID))
            {
                Plugin.Log.LogMessage("Lily Totems found, Rock Mussel is now aquatic");
                Tribes.Add(GuidManager.GetEnumValue<Tribe>("Lily.BOT", "aquatic"));
            }
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(Plugin.NeverGUID))
            {
                Plugin.Log.LogMessage("Never stuff found, Rock Mussel is now Crustacean");
                Tribes.Add(GuidManager.GetEnumValue<Tribe>(Plugin.NeverGUID, "Crustacean"));
            }

            List<Ability> Abilities = new List<Ability>();
			Abilities.Add(CustomAbility1);
			Abilities.Add(CustomAbility2);

			List<Trait> Traits = new List<Trait>();

			Texture2D DefaultTexture = TextureHelper.GetImageAsTexture("re_Mussel.png", typeof(High_Tide).Assembly);
			Texture2D eTexture = TextureHelper.GetImageAsTexture("re_Mussel_e.png", typeof(High_Tide).Assembly);

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
