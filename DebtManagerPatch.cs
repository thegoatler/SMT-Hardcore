using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using HutongGames.PlayMaker.Actions;

namespace GoatlerSMTHealth
{
    [HarmonyPatch(typeof(DebtManager))]
    internal class DebtManagerPatch
    {
        [HarmonyPatch("RetrieveTotalLoanLeftFromInvoices")]
        [HarmonyPostfix]
        public static void debtManagerPatch(DebtManager __instance)
        {
            int daysPastDue = 0;
            for(int i = 0; i < __instance.currentInvoicesData.Length; i++)
            {
                string text = __instance.currentInvoicesData[i];
                if(text != "")
                {
                    int invoiceTypeID;
                    float invoiceAmount;
                    int startDate;
                    int endDate;
                    string extraDataStr;
                    __instance.GetInvoiceDataValues(text, out invoiceTypeID, out invoiceAmount, out startDate, out endDate, out extraDataStr);
                    //HealthMod.Logger.LogInfo(startDate.ToString());
                    int currentDay = GameData.Instance.gameDay;
                    //HealthMod.Logger.LogInfo(currentDay.ToString());
                    daysPastDue += currentDay - endDate;
                    //HealthMod.Logger.LogInfo(daysPastDue.ToString());
                }
            }
            UIManager.playerHealth.TakeDamage(daysPastDue * HealthMod.OverdueLoanDamage.Value);
            //HealthMod.Logger.LogInfo("Damage Dealt from Debt");

        }
    }
}
