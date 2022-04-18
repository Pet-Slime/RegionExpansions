using System.Collections.Generic;
using DiskCardGame;
using UnityEngine;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;

namespace RegionExpansions.cards
{
	public static class Strong_Wind_1
	{
		public static readonly Ability CustomAbility2 = InscryptionAPI.Guid.GuidManager.GetEnumValue<Ability>("extraVoid.inscryption.voidSigils", "Strong Wind");
		public static void AddCard()
		{
			string name = "re_Strong_Wind_1";
			string displayName = "Strong Wind";
			string description = "A strong wind forces fliers to land.";
			int baseAttack = 0;
			int baseHealth = 1;
			int bloodCost = 0;
			int boneCost = 0;
			int energyCost = 0;

			List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();

			List<Tribe> Tribes = new List<Tribe>();

			List<Ability> Abilities = new List<Ability>();
			Abilities.Add(Ability.Reach);
			Abilities.Add(CustomAbility2);

			List<Trait> Traits = new List<Trait>();
			Traits.Add(Trait.Terrain);

			Texture2D DefaultTexture = TextureHelper.GetImageAsTexture("re_Strong_Wind.png", typeof(Strong_Wind_1).Assembly);
			Texture2D eTexture = TextureHelper.GetImageAsTexture("re_Strong_Wind.png", typeof(Strong_Wind_1).Assembly);

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
			newCard.SetExtendedProperty("void_dying_count", 1);
			newCard.AddSpecialAbilities(RegionExpansions.sigils.DyingWind.specialAbility);
			newCard.SetTerrain();
			CardManager.Add("re", newCard);
		}
	}
}
