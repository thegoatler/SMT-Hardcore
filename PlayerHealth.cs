using System.Runtime.Remoting;
using StarterAssets;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float costOfDeath = -500f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        if (currentHealth <= 0) Die(costOfDeath);
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    public void Die(float cost)
    {
        //hook into this function to remove money when you die
        GameData.Instance.CmdAlterFunds(cost);
        //HealthMod.Logger.LogInfo("Send Player to jail");
        FirstPersonController.Instance.GetComponent<PlayerPermissions>().UserCode_RpcJPlayer__Int32(10);
        //HealthMod.Logger.LogInfo("Sent player to jaill");
        currentHealth = maxHealth;
    }
}