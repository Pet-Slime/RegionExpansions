using DiskCardGame;
using InscryptionAPI.Encounters;
using System;
using System.Collections.Generic;
using System.Text;
using static UnityEngine.GridBrushBase;
using UnityEngine;
using InscryptionAPI.Helpers;
using RegionExpansions.cards;
using System.Collections;
using Object = UnityEngine.Object;

namespace RegionExpansions.Regions.Graveyard
{
    public class GravekeeperBattleSequencer : Part1BossBattleSequencer
    {

        public static readonly SpecialSequenceManager.FullSpecialSequencer FullSequencer = SpecialSequenceManager.Add(Plugin.PluginGuid, "GravekeeperBattleSequencer", typeof(GravekeeperBattleSequencer));

        public override Opponent.Type BossType
        {
            get
            {
                return Plugin.GravekeeperBoss;
            }
        }


        public override StoryEvent DefeatedStoryEvent
        {
            get
            {
                return StoryEvent.AnglerDefeated;
            }
        }

        private FishHookGrab FishHookGrab
        {
            get
            {
                return Singleton<TurnManager>.Instance.Opponent.GetComponent<FishHookGrab>();
            }
        }

        // Token: 0x06001E5B RID: 7771 RVA: 0x00065A10 File Offset: 0x00063C10
        public override EncounterData BuildCustomEncounter(CardBattleNodeData nodeData)
        {
            EncounterData encounterData = base.BuildCustomEncounter(nodeData);
            encounterData.Blueprint = ResourceBank.Get<EncounterBlueprintData>("Data/EncounterBlueprints/Part1/AnglerBossP1");
            encounterData.opponentTurnPlan = DiskCardGame.EncounterBuilder.BuildOpponentTurnPlan(encounterData.Blueprint, nodeData.difficulty + RunState.Run.DifficultyModifier, true);
            if (nodeData.difficulty >= 15)
            {
                EncounterData.StartCondition startCondition = new EncounterData.StartCondition();
                startCondition.cardsInOpponentSlots[0] = CardLoader.GetCardByName("BaitBucket");
                startCondition.cardsInOpponentSlots[3] = CardLoader.GetCardByName("BaitBucket");
                encounterData.startConditions.Add(startCondition);
            }
            return encounterData;
        }

        // Token: 0x06001E5C RID: 7772 RVA: 0x00065A99 File Offset: 0x00063C99
        public override IEnumerator OpponentCombatEnd()
        {
            if (Singleton<TurnManager>.Instance.GameEnding)
            {
                yield return this.FishHookGrab.CancelHook();
                yield break;
            }
            if (this.FishHookGrab.AimingHook)
            {
                yield return this.FishHookGrab.PullHook();
            }
            else if (Singleton<TurnManager>.Instance.Opponent.NumLives > 1)
            {
                yield return this.FishHookGrab.AimHookAtRandomSlot();
            }
            yield break;
        }

        // Token: 0x06001E5D RID: 7773 RVA: 0x00065AA8 File Offset: 0x00063CA8
        public override IEnumerator OpponentLifeLost()
        {
            yield return this.FishHookGrab.CancelHook();
            yield break;
        }

        // Token: 0x06001E5E RID: 7774 RVA: 0x0000CA74 File Offset: 0x0000AC74
        public override bool RespondsToOtherCardResolve(PlayableCard otherCard)
        {
            return true;
        }

        // Token: 0x06001E5F RID: 7775 RVA: 0x00065AB7 File Offset: 0x00063CB7
        public override IEnumerator OnOtherCardResolve(PlayableCard otherCard)
        {
            yield return this.FishHookGrab.OnOtherCardResolved(otherCard);
            yield break;
        }

        // Token: 0x06001E60 RID: 7776 RVA: 0x0000CA74 File Offset: 0x0000AC74
        public override bool RespondsToOtherCardAssignedToSlot(PlayableCard otherCard)
        {
            return true;
        }

        // Token: 0x06001E61 RID: 7777 RVA: 0x00065ACD File Offset: 0x00063CCD
        public override IEnumerator OnOtherCardAssignedToSlot(PlayableCard otherCard)
        {
            yield return this.FishHookGrab.OnOtherCardAssignedToSlot(otherCard);
            yield break;
        }

        // Token: 0x06001E62 RID: 7778 RVA: 0x00065AE3 File Offset: 0x00063CE3
        public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
        {
            return card.Info.name == "BaitBucket" && (deathSlot.Card == null || deathSlot.Card.Dead);
        }

        // Token: 0x06001E63 RID: 7779 RVA: 0x00065B19 File Offset: 0x00063D19
        public override IEnumerator OnOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
        {
            yield return new WaitForSeconds(0.2f);
            CardInfo cardByName = CardLoader.GetCardByName("Shark");
            yield return Singleton<BoardManager>.Instance.CreateCardInSlot(cardByName, deathSlot, 0.1f, true);
            yield return new WaitForSeconds(0.25f);
            if (!this.sharkDialoguePlayed)
            {
                this.sharkDialoguePlayed = true;
                yield return new WaitForSeconds(0.5f);
                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Go fish.", -0.65f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
            }
            yield return new WaitForSeconds(0.1f);
            yield break;
        }

        // Token: 0x0400154B RID: 5451
        private bool sharkDialoguePlayed;
    }
}
