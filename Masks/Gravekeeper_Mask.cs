using DiskCardGame;
using InscryptionAPI.Items;
using InscryptionAPI.Masks;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegionExpansions.Masks
{
    public class Gravekeeper_Mask : MaskBehaviour
    {

        public static LeshyAnimationController.Mask ID;

        public static void Setup()
        {
            ResourceLookup resourceLookup = new ResourceLookup();
            resourceLookup.FromAssetBundle(Plugin.RegionExpansionBundle, "gravekeeper_mask");
            MaskManager.ModelType modelType = MaskManager.RegisterPrefab(Plugin.PluginGuid, "gravekeeper_mask", resourceLookup);
            CustomMask customMask = MaskManager.Add(Plugin.PluginGuid, "Gravekeeper", null);
            customMask.SetModelType(modelType);
//            Bosses.MagmaBossMask.ID = customMask.ID;
        }
    }
}
