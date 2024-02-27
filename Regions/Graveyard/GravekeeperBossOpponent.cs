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
using Pixelplacement;

namespace RegionExpansions.Regions.Graveyard
{
    public class GravekeeperBossOpponent : Part1BossOpponent
    {

        public static readonly OpponentManager.FullOpponent FullOpponent = OpponentManager.Add(Plugin.PluginGuid, "GraveKeeperBoss", Graveyard.GravekeeperBattleSequencer.FullSequencer.Id, typeof(GravekeeperBossOpponent));

        public override string DefeatedPlayerDialogue
        {
            get
            {
                return "More gold for me!";
            }
        }

        public override Color InteractablesGlowColor
        {
            get
            {
                return GameColors.Instance.lightPurple;
            }
        }

        public override IEnumerator IntroSequence(EncounterData encounter)
        {

            AudioController.Instance.FadeOutLoop(0.75f, Array.Empty<int>());
            yield return base.IntroSequence(encounter);
            yield return new WaitForSeconds(0.75f);
            Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
            yield return new WaitForSeconds(0.25f);
            yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("AnglerPreIntro", TextDisplayer.MessageAdvanceMode.Input, TextDisplayer.EventIntersectMode.Wait, null, null);
            yield return new WaitForSeconds(0.15f);
            LeshyAnimationController.Instance.PutOnMask(LeshyAnimationController.Mask.Angler, false);
            AudioController.Instance.SetLoopAndPlay("boss_angler_base", 0, true, true);
            AudioController.Instance.SetLoopAndPlay("boss_angler_ambient", 1, true, true);
            AudioController.Instance.SetLoopVolume(0.25f, 4f, 1, true);
            yield return new WaitForSeconds(1.5f);
            Singleton<OpponentAnimationController>.Instance.SetHeadTilt(5f, 1.5f, 0.1f);
            yield return base.FaceZoomSequence();
            base.InstantiateBossBehaviour<FishHookGrab>();
            yield return Singleton<TextDisplayer>.Instance.PlayDialogueEvent("AnglerIntro", TextDisplayer.MessageAdvanceMode.Input, TextDisplayer.EventIntersectMode.Wait, null, null);
            Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
            Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
            yield return new WaitForSeconds(0.25f);
            base.SpawnScenery("KnivesTableEffects");

            AudioController.Instance.PlaySound2D("angler_fish_enter", MixerGroup.TableObjectsSFX, 0.35f, 0f, null, null, null, null, false);
            yield return new WaitForSeconds(0.5f);
            yield break;
        }

        public void SceneryIds()
        {
            
        }

        // Token: 0x06001E68 RID: 7784 RVA: 0x00065B60 File Offset: 0x00063D60
        public override IEnumerator StartNewPhaseSequence()
        {
            if (base.HasGrizzlyGlitchPhase(0))
            {
                yield return base.GrizzlyGlitchSequence();
            }
            else
            {
                base.TurnPlan.Clear();
                yield return this.PlaceBaitSequence();
                yield return base.ReplaceBlueprint("AnglerBossP2", true);
            }
            yield break;
        }

        // Token: 0x06001E69 RID: 7785 RVA: 0x00065B6F File Offset: 0x00063D6F
        private IEnumerator PlaceBaitSequence()
        {
            Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, false);
            yield return new WaitForSeconds(0.2f);
            yield return base.ClearBoard();
            yield return base.ClearQueue();
            yield return new WaitForSeconds(0.4f);
            yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Go fish.", -0.65f, 0.4f, Emotion.Neutral, TextDisplayer.LetterAnimation.Jitter, DialogueEvent.Speaker.Single, null, true);
            yield return new WaitForSeconds(0.1f);
            List<CardSlot> list = Singleton<BoardManager>.Instance.OpponentSlotsCopy.FindAll((CardSlot x) => x.opposingSlot.Card != null);
            foreach (CardSlot slot in list)
            {
                yield return Singleton<BoardManager>.Instance.CreateCardInSlot(CardLoader.GetCardByName("BaitBucket"), slot, 0.2f, true);
                yield return new WaitForSeconds(0.25f);
            }
            yield return new WaitForSeconds(0.25f);
            yield break;
        }

        public override void SetSceneEffectsShown(bool showEffects)
        {
            if (showEffects)
            {
                LeshyAnimationController.Instance.SetHairColor(Color.black);
                Tween.Rotate(Singleton<ExplorableAreaManager>.Instance.HangingLight.transform, new Vector3(150f, 0f, 0f), Space.World, 25f, 0f, Tween.EaseInOut, Tween.LoopType.PingPong, null, null, true);
                Singleton<ExplorableAreaManager>.Instance.SetHangingLightIntensity(10f);
                Singleton<ExplorableAreaManager>.Instance.SetHangingLightCookie(ResourceBank.Get<Texture>("Art/Effects/WavesTextureCube"));
                Color darkBlue = GameColors.Instance.darkPurple;
                darkBlue.a = 0.5f;
                Singleton<TableVisualEffectsManager>.Instance.ChangeTableColors(GameColors.Instance.lightPurple, GameColors.Instance.marigold, this.InteractablesGlowColor, darkBlue, GameColors.Instance.darkPurple, this.InteractablesGlowColor, GameColors.Instance.gray, GameColors.Instance.gray, GameColors.Instance.lightGray);
                return;
            }
            LeshyAnimationController.Instance.ResetHairColor();
            Tween.Cancel(Singleton<ExplorableAreaManager>.Instance.HangingLight.transform.GetInstanceID());
            Singleton<ExplorableAreaManager>.Instance.ResetHangingLightIntensity();
            Singleton<ExplorableAreaManager>.Instance.ClearHangingLightCookie();
            Singleton<TableVisualEffectsManager>.Instance.ResetTableColors();
            Singleton<OpponentAnimationController>.Instance.ResetHeadTilt(0.2f);
        }
    }
}
