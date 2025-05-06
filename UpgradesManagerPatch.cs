using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace GoatlerSMTHealth
{
    [HarmonyPatch(typeof(UpgradesManager))]
    internal class UpgradesManagerPatch
    {
        [HarmonyPatch("SetAccelerationMethod")]
        [HarmonyPostfix]
        public static void timeAccelerationPatch(UpgradesManager __instance)
        {
            if (__instance.acceleratedTime)
            {
                UIManager.playerHealth.TakeDamage(HealthMod.TimeAcceleratorDamage.Value);
            }
        }
    }
}
