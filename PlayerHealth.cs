using System.Runtime.Remoting;
using StarterAssets;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float costOfDeath = -200f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        if (currentHealth <= 0) Die();
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    private void Die()
    {
        //hook into this function to remove money when you die
        GameData.Instance.CmdAlterFunds(costOfDeath);
        HealthMod.Logger.LogInfo("Send Player to jail");
        FirstPersonController.Instance.GetComponent<PlayerPermissions>().UserCode_RpcJPlayer__Int32(10);
        HealthMod.Logger.LogInfo("Sent player to jaill");
        currentHealth = maxHealth;
    }
}