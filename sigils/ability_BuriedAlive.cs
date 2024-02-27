using DiskCardGame;
using InscryptionAPI.Helpers;
using RegionExpansions.cards.Beach;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RegionExpansions.sigils
{
    public class BuriedAlive
    {
        public static void AddBuriedAlive()
        {
            // setup ability
            const string rulebookName = "Buried Alive";
            const string rulebookDescription = "When Destroyed, [creature] will create an undead in it's slot.";
            const string LearnDialogue = "It craves their blood";
            Texture2D tex_a1 = TextureHelper.GetImageAsTexture("re_Jellyfish.png", typeof(Plugin).Assembly);
            Texture2D tex_a2 = TextureHelper.GetImageAsTexture("re_Jellyfish.png", typeof(Plugin).Assembly);
            int powerlevel = 0;
            bool LeshyUsable = false;
            bool part1Shops = false;
            bool canStack = false;

            // set ability to behaviour class
            ability_BuriedAlive.ability = SigilUtils.CreateAbilityWithDefaultSettings(rulebookName, rulebookDescription, typeof(ability_BuriedAlive), tex_a1, tex_a2, LearnDialogue,
                                                                                    true, powerlevel, LeshyUsable, part1Shops, canStack).ability;
        }
    }

    public class ability_BuriedAlive : AbilityBehaviour
    {
        public override Ability Ability => ability;

        public static Ability ability;

        public override bool RespondsToDie(bool wasSacrifice, PlayableCard killer)
        {
            return !wasSacrifice && base.Card.OnBoard;
        }

        // Token: 0x06001536 RID: 5430 RVA: 0x0004933C File Offset: 0x0004753C
        public override IEnumerator OnDie(bool wasSacrifice, PlayableCard killer)
        {
            yield return base.PreSuccessfulTriggerSequence();
            yield return new WaitForSeconds(0.3f);
            string name = "Opossum";
            yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName(name), base.Card.Slot, 0.15f, true);
            yield return base.LearnAbility(0.5f);
            yield break;
        }
    }
}