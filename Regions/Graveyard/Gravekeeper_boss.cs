using DiskCardGame;
using InscryptionAPI.Encounters;
using System;
using System.Collections.Generic;
using System.Text;
using static UnityEngine.GridBrushBase;
using UnityEngine;
using InscryptionAPI.Helpers;
using RegionExpansions.cards;

namespace RegionExpansions.Regions.Graveyard
{
    internal class Gravekeeper_boss
    {

        public static BossBattleNodeData magmaBossNode;

        public static void AddBossNodes()
        {
            Plugin.GravekeeperBossNode = new BossBattleNodeData{};
            Type typeFromHandle = typeof(ProspectorBattleSequencer);
            Type typeFromHandle2 = typeof(ProspectorBossOpponent);
            Plugin.GraveyardBossBattleSequencer = SpecialSequenceManager.Add(Plugin.PluginGuid, typeFromHandle.Name, typeFromHandle).Id;
            Plugin.GravekeeperBoss = OpponentManager.Add(Plugin.PluginGuid, typeFromHandle2.Name, Plugin.GraveyardBossBattleSequencer, typeFromHandle2, new List<Texture2D>
                {
                    TextureHelper.GetImageAsTexture("animated_bossnode_gravekeeper_1.png", typeof(High_Tide).Assembly),
                    TextureHelper.GetImageAsTexture("animated_bossnode_gravekeeper_2.png", typeof(High_Tide).Assembly),
                    TextureHelper.GetImageAsTexture("animated_bossnode_gravekeeper_3.png", typeof(High_Tide).Assembly),
                    TextureHelper.GetImageAsTexture("animated_bossnode_gravekeeper_4.png", typeof(High_Tide).Assembly)
                }).Id;
        }
    }
}
