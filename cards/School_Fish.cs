using System.Collections.Generic;
using DiskCardGame;
using UnityEngine;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;
using InscryptionAPI.Guid;

namespace RegionExpansions.cards
{
	public static class School_Fish
	{
		public static readonly Ability CustomAbility1 = InscryptionAPI.Guid.GuidManager.GetEnumValue<Ability>("extraVoid.inscryption.voidSigils", "Schooling");
		public static void AddCard()
		{
			string name = "re_Schoolling_Fish";
			string displayName = "Schooling Fish";
			string description = "A fish that likes to swim with fellow waterborne, increasing their numbers and strength.";
			int baseAttack = 1;
			int baseHealth = 1;
			int bloodCost = 1;
			int boneCost = 0;
			int energyCost = 0;

			List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
			metaCategories.Add(CardMetaCategory.ChoiceNode);
			metaCategories.Add(CardMetaCategory.TraderOffer);

			List<Tribe> Tribes = new List<Tribe>();
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(Plugin.TotemGUID))
            {
                Plugin.Log.LogMessage("Lily Totems found, Schooling Fish is now aquatic");
                Tribes.Add(GuidManager.GetEnumValue<Tribe>("Lily.BOT", "aquatic"));
            }

            List<Ability> Abilities = new List<Ability>();
			Abilities.Add(CustomAbility1);
			Abilities.Add(Ability.Submerge);

			List<Trait> Traits = new List<Trait>();

			Texture2D DefaultTexture = TextureHelper.GetImageAsTexture("re_Pogfish.png", typeof(High_Tide).Assembly);
			Texture2D eTexture = TextureHelper.GetImageAsTexture("re_Pogfish_e.png", typeof(High_Tide).Assembly);

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
