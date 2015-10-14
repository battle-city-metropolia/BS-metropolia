using UnityEngine;
using System.Collections;

public class AttackSpeedPowerUp : AbstractPowerUp
{
    public override bool EnemyDestroyPowerUp { get { return false; } }
    public override bool DestroyPowerUpAfterTrigger { get { return false; } }
    public override bool AlreadyUsed { get; set; }

    public float powerUpDurationSec = 5.0f; // Duration in seconds
    public float attackSpeed = 0.1f;

    private float oldAttackSpeed;

    public override void PowerUpEffectPlayerTriggered()
    {
        //Debug.Log("Player picked up health powerup");
        RaiseAttackSpeed();
    }

    public override void PowerUpEffectEnemyTriggered()
    {
        //Debug.Log("Enemy picked up health powerup");
        // Do nothing if enemy picks up
    }

    void RaiseAttackSpeed()
    {
        AlreadyUsed = true;
        GetComponent<Renderer>().enabled = false;
        WeaponScript playerWeapon = otherCollider.gameObject.GetComponent<WeaponScript>();
        if (playerWeapon != null)
        {
            oldAttackSpeed = playerWeapon.shootingRate;
            playerWeapon.shootingRate = attackSpeed;
            Invoke("RestoreAttackSpeed", powerUpDurationSec);
        }
    }

    void RestoreAttackSpeed()
    {
        WeaponScript playerWeapon = otherCollider.gameObject.GetComponent<WeaponScript>();
        if (playerWeapon != null)
        {
            playerWeapon.shootingRate = oldAttackSpeed;
        }
        Destroy(this.gameObject);
    }
}
