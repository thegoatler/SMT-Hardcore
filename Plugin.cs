using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Michsky.MUIP;
using StarterAssets;
using UnityEngine;

[BepInPlugin("com.thegoatler.healthmod", "SMT Hardcore", "1.0")]
public class HealthMod : BaseUnityPlugin
{
    public new static ManualLogSource Logger;
    private static Harmony harmonyThingySomethingUhh = new Harmony("harmonyThingySomethingUhh");
    void Awake()
    {
        HealthMod.Logger = base.Logger;
        HealthMod.Logger.LogInfo("Beforer patches");
        harmonyThingySomethingUhh.PatchAll();
        HealthMod.Logger.LogInfo("After patches");
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
    