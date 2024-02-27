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
    public class BossBattleNodeData_Gravekeeper
    {

        public static BossBattleNodeData GravekeeperBossNode;

        public static void AddBossNodes()
        {
            Plugin.GravekeeperBossNode = new BossBattleNodeData
            {
                bossType = Graveyard.GravekeeperBossOpponent.FullOpponent.Id,
                specialBattleId = Graveyard.GravekeeperBattleSequencer.FullSequencer.Id,
                position = new Vector2(0.5f, 0.86f)
            };
            Type typeFromHandle = typeof(GravekeeperBattleSequencer);
            Type typeFromHandle2 = typeof(GravekeeperBossOpponent);
            Plugin.GraveyardBossBattleSequencer = SpecialSequenceManager.Add(Plugin.PluginGuid, typeFromHandle.Name, typeFromHandle).Id;
            Plugin.GravekeeperBoss = OpponentManager.Add(Plugin.PluginGuid, typeFromHandle2.Name, Plugin.GraveyardBossBattleSequencer, typeFromHandle2, new List<Texture2D>
                {
                    TextureHelper.GetImageAsTexture("animated_bossnode_gravekeeper_1.png", typeof(Plugin).Assembly),
                    TextureHelper.GetImageAsTexture("animated_bossnode_gravekeeper_1.png", typeof(Plugin).Assembly),
                    TextureHelper.GetImageAsTexture("animated_bossnode_gravekeeper_2.png", typeof(Plugin).Assembly),
                    TextureHelper.GetImageAsTexture("animated_bossnode_gravekeeper_2.png", typeof(Plugin).Assembly),
                    TextureHelper.GetImageAsTexture("animated_bossnode_gravekeeper_3.png", typeof(Plugin).Assembly),
                    TextureHelper.GetImageAsTexture("animated_bossnode_gravekeeper_3.png", typeof(Plugin).Assembly),
                    TextureHelper.GetImageAsTexture("animated_bossnode_gravekeeper_4.png", typeof(Plugin).Assembly),
                    TextureHelper.GetImageAsTexture("animated_bossnode_gravekeeper_4.png", typeof(Plugin).Assembly)
                }).Id;
        }
    }
}
