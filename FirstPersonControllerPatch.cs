using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using StarterAssets;

namespace GoatlerSMTHealth
{
    [HarmonyPatch(typeof(FirstPersonController))]
    internal class FirstPersonControllerPatch
    {
        //This method is called when the method FirstPersonController.Start ends
        [HarmonyPatch("Start")]
        //Postfix is for when you want this to be called after the method "Start" finished. HarmonyPrefix for the opposite.
        [HarmonyPostfix]
        public static void elizabeth(FirstPersonController __instance)
        {
            UIManager.SpawnHealthUI();
            HealthMod.Logger.LogInfo("Health UI Spawn Triggered");
        }
    }
}
/*
    Eachtime there is theft at a self checkout
    NPC_Manager -> GetAvailableSelfCheckout

*/
