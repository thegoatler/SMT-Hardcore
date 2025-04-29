using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using Michsky.MUIP;
using StarterAssets;
using UnityEngine;

[BepInPlugin("GoatlerSMTHealth", "SMT Hardcore", "1.1")]
public class HealthMod : BaseUnityPlugin
{
    public new static ManualLogSource Logger;
    private static Harmony harmonyThingySomethingUhh = new Harmony("harmonyThingySomethingUhh");

    public static ConfigEntry<float> DeathCost;
    public static ConfigEntry<bool> SendToJail;
    public static ConfigEntry<float> BroomDamage;
    public static ConfigEntry<float> DeleteDamage;
    public static ConfigEntry<float> NotFoundDamage;
    public static ConfigEntry<float> ThiefDamage;
    public static ConfigEntry<float> TooExpensiveDamage;
    public static ConfigEntry<float> OverdueLoanDamage;

    void Awake()
    {
        /*
         * General.Death Config Creation
         */
        DeathCost = Config.Bind("General.Death",
                                       "DeathCost",
                                       500f,
                                       "This is the amount of money you will lose when you die, pick a negative value zero or higher.");

        SendToJail = Config.Bind("General.Death",
                                        "SendToJail",
                                        true,
                                        "Should the player be sent to jail when they die?");

        /*
         * General.Damage Config Creation
         */
        BroomDamage = Config.Bind("General.Damage",
                                        "BroomDamage",
                                        20f,
                                        "How much damage should it deal when hit with a broom?");
        
        DeleteDamage = Config.Bind("General.Damage",
                                        "DeleteDamage",
                                        5f,
                                        "How much damage should it deal when deleting something from your store?");

        NotFoundDamage = Config.Bind("General.Damage",
                                        "NotFoundDamage",
                                        10f,
                                        "How much damage should it deal when a customer can't find a product they're looking for?");

        ThiefDamage = Config.Bind("General.Damage",
                                       "ThiefDamage",
                                       10f,
                                       "How much damage should it deal when a thief successfully robs your store?");

        TooExpensiveDamage = Config.Bind("General.Damage",
                                       "TooExpensiveDamage",
                                       10f,
                                       "How much damage should it deal when a customer finds an item that's too expensive?");

        OverdueLoanDamage = Config.Bind("General.Damage",
                                       "OverdueLoanDamage",
                                       5f,
                                       "How much damage should it deal per day a loan is overdue?");

        HealthMod.Logger = base.Logger;
        harmonyThingySomethingUhh.PatchAll();
        //I hate you. Because of the name, you were going good.
        //im not sure what its gonna do so idkj what to call it
        //Create object of Harmony type

        //Call patch thingy on it
        //Perfect
        //im leaving it too
        //Wat
        //not sure how to call the patch on it
        //ALL OF IT. PATCH IT ALL
        //LEAVE NO PRISONERS

        //Done
        //StartCoroutine makes a call that will execute until you yield. Then it waits for the next frame and keeps going where it left at.
        //A yield.break or reaching the end of the method finishes the call. Its basically used as a way of repeating a process, or, in your case,
        //  to give it a delay of sorts.

        /*
        bool moretrue = true;
        while (true && true && true && moretrue)
        {
            if (FirstPersonController.Instance != null)
            {
                UIManager.SpawnHealthUI();
                HealthMod.Logger.LogInfo("Health UI Spawn Triggered");
            }
        }
        */

    }


}
    