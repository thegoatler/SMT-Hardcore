using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace GoatlerSMTHealth
{
    [HarmonyPatch(typeof(GameData))]
    internal class GameDataPatch
    {
        //Hook into gaining money without experience for selling furniture
        [HarmonyPatch("CmdAlterFundsWithoutExperience")]
        [HarmonyPostfix]
        public static void deleteBehaviourPatch(GameData __instance)
        {
            HealthMod.Logger.LogInfo("DeleteBehaviour Invoked");
            UIManager.playerHealth.TakeDamage(10f);
            HealthMod.Logger.LogInfo("Health Decreased");
        }

        //Hook into the method adding to the expensive list
        [HarmonyPatch("AddExpensiveList")]
        [HarmonyPostfix]
        public static void tooExpensivePatch(GameData __instance)
        {
            HealthMod.Logger.LogInfo("Product Too Expensive");
            UIManager.playerHealth.TakeDamage(5f);
            HealthMod.Logger.LogInfo("Health Decreased");
        }

        //Hook into the method adding to the not found list
        [HarmonyPatch("AddNotFoundList")]
        [HarmonyPostfix]
        public static void notFoundPatch(GameData __instance)
        {
            HealthMod.Logger.LogInfo("Product Not Found");
            UIManager.playerHealth.TakeDamage(5f);
            HealthMod.Logger.LogInfo("Health Decreased");
        }
    }
}
