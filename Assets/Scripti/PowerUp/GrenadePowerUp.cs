using UnityEngine;
using System.Collections;

public class GrenadePowerUp : AbstractPowerUp
{
    public override bool EnemyDestroyPowerUp { get { return false; } }
    public override bool DestroyPowerUpAfterTrigger { get { return true; } }
    public override bool AlreadyUsed { get; set; }

    public override void PowerUpEffectPlayerTriggered()
    {
        AlreadyUsed = true;

        GameObject[] enemyTanks = GameObject.FindGameObjectsWithTag("EnemyTank");
        foreach (GameObject enemyTank in enemyTanks)
        {
            // Destory all tanks
            EnemyHealth enemyTankHealth = enemyTank.GetComponent<EnemyHealth>();
            if (enemyTankHealth != null)
                enemyTankHealth.TakeDamage(999999);
        }
        //Debug.Log("Player picked up grenade");
    }

    public override void PowerUpEffectEnemyTriggered()
    {
        //Debug.Log("Enemy picked up grenade");
        // Do nothing if enemy picks up
    }
}
