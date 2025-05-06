using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;


namespace GoatlerSMTHealth
{
    [HarmonyPatch(typeof(PricingMachine))]
    internal class PricingMachinePatch
    {
        [HarmonyPatch("SetAllPercentages")]
        [HarmonyPostfix]
        public static void setPricesPatch(PricingMachine __instance)
        {
            HealthMod.Logger.LogInfo("Test pricing damage");
            UIManager.playerHealth.TakeDamage(HealthMod.SetPricesDamage.Value);
        }
    }
}
