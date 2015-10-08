using UnityEngine;
using System.Collections;

public class GrenadePowerUp : AbstractPowerUp
{
    // Set to true if enemy triggers the powerup and implement PowerUpEffectEnemyTriggered()
    bool enemyTriggerPowerUp = false;

    public override void PowerUpEffectPlayerTriggered()
    {
        GameObject[] enemyTanks = GameObject.FindGameObjectsWithTag("EnemyTank");
        foreach (GameObject enemyTank in enemyTanks)
        {
            // Destory all tanks
            EnemyHealth enemyTankHealth = enemyTank.GetComponent<EnemyHealth>();
            if (enemyTankHealth != null)
                enemyTankHealth.TakeDamage(999999);
        }
        Debug.Log("Player picked up grenade");
    }

    public override void PowerUpEffectEnemyTriggered()
    {
        Debug.Log("Enemy picked up grenade");
        // Do nothing if enemy picks up
    }
}
