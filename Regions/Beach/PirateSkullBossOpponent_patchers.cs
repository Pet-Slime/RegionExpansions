using System.Collections;
using DiskCardGame;
using UnityEngine;
using HarmonyLib;

namespace RegionExpansions.Regions.Beach
{
    internal class PirateSkullBossOpponent_patchers
    {
        [HarmonyPatch(typeof(PirateSkullBossOpponent))]
        public class re_PirateSkullBoss_Intro_Patch
        {
            [HarmonyPostfix, HarmonyPatch(nameof(PirateSkullBossOpponent.IntroSequence))]
            public static IEnumerator Postfix(
            IEnumerator enumerator,
            PirateSkullBossOpponent __instance,
            EncounterData encounter
            )
            {

                yield return enumerator;
                if (RunState.CurrentMapRegion.name != "Pirateville")
                {
                    __instance.NumLives = 2;
                }

            }
        }

        [HarmonyPatch(typeof(PirateSkullBossOpponent))]
        public class re_PirateSkullBoss_LifeLostSequence_Patch
        {
            [HarmonyPostfix, HarmonyPatch(nameof(PirateSkullBossOpponent.LifeLostSequence))]
            public static IEnumerator Postfix(
            IEnumerator enumerator,
            PirateSkullBossOpponent __instance
            )
            {
                if (RunState.CurrentMapRegion.name != "Pirateville" && __instance.NumLives == 0)
                {
                    AudioController.Instance.SetLoopVolume(0f, 1f, 0, true);
                    AudioController.Instance.SetLoopVolume(0f, 1f, 1, true);
                    (Singleton<TurnManager>.Instance.SpecialSequencer as PirateSkullBattleSequencer).CleanupTargetIcons();
                    yield return new WaitForSeconds(0.4f);
                    Singleton<ViewManager>.Instance.SwitchToView(View.BossCloseup, false, true);
                    yield return new WaitForSeconds(0.4f);
                    yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Avast ye!", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.PirateSkull, null, true);
                    yield return new WaitForSeconds(0.2f);
                    __instance.bossSkull.GetComponentInChildren<Animator>().SetTrigger("close_eye");
                    yield return new WaitForSeconds(1.25f);
                    if (SaveFile.IsAscension && AscensionSaveData.Data.ChallengeIsActive(AscensionChallenge.FinalBoss))
                    {
                        ChallengeActivationUI.Instance.ShowActivation(AscensionChallenge.FinalBoss);
                        yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("I'll be seeing you later, and I'll be bringing my crew with me too!", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.PirateSkull, null, true);
                    }
                    else
                    {
                        yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Farewell.", -2.5f, 0.5f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.PirateSkull, null, true);
                    }
                    AscensionStatsData.TryIncrementStat(AscensionStat.Type.BossesDefeated);
                    yield return new WaitForSeconds(0.5f);
                    __instance.bossSkull.ExitSimple();
                    yield return new WaitForSeconds(1.2f);
                    LeshyAnimationController.Instance.ResetHeadOffset(true);
                    LeshyAnimationController.Instance.ResetEyesTexture();
                    yield return __instance.BossDefeatedSequence();
                    Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
                    Singleton<InteractionCursor>.Instance.InteractionDisabled = false;
                }
                else
                {
                    yield return enumerator;
                }
            }
        }

        [HarmonyPatch(typeof(PirateSkullBossOpponent))]
        public class re_PirateSkullBoss_StartNewPhaseSequence_Patch
        {
            [HarmonyPostfix, HarmonyPatch(nameof(PirateSkullBossOpponent.StartNewPhaseSequence))]
            public static IEnumerator Postfix(
            IEnumerator enumerator,
            PirateSkullBossOpponent __instance
            )
            {
                if (RunState.CurrentMapRegion.name != "Pirateville")
                {
                    __instance.TurnPlan.Clear();
                    int numLives = __instance.NumLives;
                    if (numLives == 1)
                    {
                        yield return __instance.StartPhase2();
                    }
                }
                else
                {
                    yield return enumerator;
                }
            }
        }

        [HarmonyPatch(typeof(PirateSkullBattleSequencer))]
        public class re_PirateSkullBoss_PirateSkullBattleSequencer_Patch
        {
            [HarmonyPostfix, HarmonyPatch(nameof(PirateSkullBattleSequencer.RespondsToUpkeep))]
            public static void Postfix(bool playerUpkeep, ref bool __result)
            {
                if (RunState.CurrentMapRegion.name != "Pirateville")
                {
                    if (playerUpkeep && Singleton<TurnManager>.Instance.TurnNumber > 1 && Singleton<TurnManager>.Instance.Opponent.NumLives > 0)
                    {
                        __result = true;
                    }
                }
            }
        }
    }
}
