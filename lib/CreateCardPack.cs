using Infiniscryption.PackManagement;
using InscryptionAPI.Helpers;
using RegionExpansions.cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegionExpansions.lib
{
    public static class CreateCardPack
    {

        public static void CreatePack()
        {
            PackInfo incrediPack = PackManager.GetPackInfo("re");
            incrediPack.Title = "Beach Region Card Pack";
            incrediPack.SetTexture(TextureHelper.GetImageAsTexture("beach_pack.png", typeof(High_Tide).Assembly));
            incrediPack.Description = "Cards to help make the beach region with Royal as the boss more flavorful. Don't disable! Will break custom encounters for beach region!";
            incrediPack.ValidFor.Add((PackInfo.PackMetacategory)CardTemple.Nature);
        }
    }
}