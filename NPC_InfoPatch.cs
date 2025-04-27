using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
namespace GoatlerSMTHealth
{
    [HarmonyPatch(typeof(NPC_Info))]
    internal class NPC_InfoPatch
    {
        [HarmonyPatch("OnDestroy")]
        [HarmonyPostfix]
        public static void destroyNPCPatch(NPC_Info __instance)
        {
            if (__instance.isAThief)
            {
                //HealthMod.Logger.LogInfo("Thief Got away");
                UIManager.playerHealth.TakeDamage(HealthMod.ThiefDamage.Value);
            }
            
        }
    }
}
