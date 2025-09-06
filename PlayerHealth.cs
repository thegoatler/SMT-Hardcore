using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting;
using BepInEx;
using GoatlerSMTHealth;
using HutongGames.PlayMaker;
using Mirror;
using StarterAssets;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        NamedVariable[] arr = GameCanvas.Instance.jReference.GetComponent<PlayMakerFSM>().FsmVariables.GetAllNamedVariables();
        if (arr[0].ToString() == "0" || HealthMod.ReceiveDamageInJail.Value)
        {
            currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
            if (currentHealth <= 0) Die(-HealthMod.DeathCost.Value);
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
    public void Die(float cost)
    {
        //call this function to remove money when you die
        GameData.Instance.UserCode_CmdAlterFunds__Single(cost);
        //HealthMod.Logger.LogInfo("Send Player to jail");
        if(HealthMod.SendToJail.Value)
            FirstPersonController.Instance.GetComponent<PlayerPermissions>().UserCode_RpcJPlayer__Int32(HealthMod.NumJailClicks.Value);
        //HealthMod.Logger.LogInfo("Sent player to jaill");
        currentHealth = maxHealth;
    }
}