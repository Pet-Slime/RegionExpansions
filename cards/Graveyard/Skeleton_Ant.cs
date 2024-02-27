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
    public static class Skeleton_Ant
    {
        public static void AddCard()
        {
            string name = "eri_AntHusk";
            string displayName = "Ant Husk";
            string description = "The husk of an ant, their dedication truly know no bounds";
            int baseAttack = 0;
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
            Tribes.Add(Tribe.Insect);
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(Plugin.TotemGUID))
            {
                Plugin.Log.LogMessage("Lily Totems found, " + name + " is now " + BoTribe);
                Tribes.Add(GuidManager.GetEnumValue<Tribe>(Plugin.TotemGUID, BoTribe));
            }


            List<Ability> Abilities = new List<Ability>();

            List<Trait> Traits = new List<Trait>
            {
                Trait.Ant
            };

            Texture2D DefaultTexture = TextureHelper.GetImageAsTexture("eri_AntHusk.png", typeof(Plugin).Assembly);
            Texture2D eTexture = TextureHelper.GetImageAsTexture("eri_AntHusk_e.png", typeof(Plugin).Assembly);

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
            newCard.SetStatIcon(SpecialStatIcon.Ants);
            newCard.AddSpecialAbilities(SpecialTriggeredAbility.Ant);
            CardManager.Add("eri", newCard);
        }
    }
}
