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
    internal class Open_Grave
    {
        public static readonly Ability CustomAbility1 = GuidManager.GetEnumValue<Ability>("ATS", "Poisonous");
        public static void AddCard()
        {
            string name = "re_Open_Grave";
            string displayName = "Open Grave";
            string description = "A grave needs a body.";
            int baseAttack = 0;
            int baseHealth = 1;
            int bloodCost = 0;
            int boneCost = 0;
            int energyCost = 0;

            List<CardMetaCategory> metaCategories = new List<CardMetaCategory>();

            List<Tribe> Tribes = new List<Tribe>();
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(Plugin.TotemGUID))
            {
                Plugin.Log.LogMessage("Lily Totems found, Coffin is now undead");
                Tribes.Add(GuidManager.GetEnumValue<Tribe>(Plugin.TotemGUID, "undead"));
            }


            List<Ability> Abilities = new List<Ability>
            {
                CustomAbility1
            };

            List<Trait> Traits = new List<Trait>();

            Texture2D DefaultTexture = TextureHelper.GetImageAsTexture("re_coffin.png", typeof(Plugin).Assembly);
            Texture2D eTexture = TextureHelper.GetImageAsTexture("re_coffin_e.png", typeof(Plugin).Assembly);

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
            newCard.SetTerrain();
            CardManager.Add("re", newCard);
        }
    }
}
