using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using StarterAssets;

namespace GoatlerSMTHealth
{
    [HarmonyPatch(typeof(PlayerNetwork))]
    internal class PlayerNetworkPatch
    {
        //The patch for broom smackology
        [HarmonyPatch("InvokeUserCode_RpcPushPlayer__Vector3")]
        [HarmonyPostfix]
        public static void broomHitPatch(PlayerNetwork __instance)
        {
            HealthMod.Logger.LogInfo("Broom Smack InvokeRPC Triggered");
            UIManager.playerHealth.TakeDamage(10f);
            HealthMod.Logger.LogInfo("Health Decreased");
        }
    }
}
