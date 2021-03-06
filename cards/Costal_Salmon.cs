using System.Collections.Generic;
using DiskCardGame;
using UnityEngine;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;

namespace RegionExpansions.cards
{
	public static class Costal_Salmon
	{
		public static void AddCard()
		{
			string name = "re_Costal_Salmon";
			string displayName = "Costal Salmon";
			string description = "A salmon found along the coast around this time.";
			int baseAttack = 2;
			int baseHealth = 2;
			int bloodCost = 2;
			int boneCost = 0;
			int energyCost = 0;

			List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();
			metaCategories.Add(CardMetaCategory.ChoiceNode);
			metaCategories.Add(CardMetaCategory.TraderOffer);

			List<Tribe> Tribes = new List<Tribe>();

			List<Ability> Abilities = new List<Ability>();
			Abilities.Add(Ability.Strafe);
			Abilities.Add(Ability.Submerge);

			List<Trait> Traits = new List<Trait>();

			Texture2D DefaultTexture = TextureHelper.GetImageAsTexture("re_salmon.png", typeof(High_Tide).Assembly);
			Texture2D eTexture = TextureHelper.GetImageAsTexture("re_salmon_e.png", typeof(High_Tide).Assembly);

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
