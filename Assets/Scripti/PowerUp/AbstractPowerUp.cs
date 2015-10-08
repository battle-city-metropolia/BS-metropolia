using UnityEngine;
using System.Collections;

public abstract class AbstractPowerUp : MonoBehaviour
{
    // Abstract class for powerup effect
    public abstract void PowerUpEffectPlayerTriggered();
    public abstract void PowerUpEffectEnemyTriggered();
    public bool enemyTriggerPowerUp;

    // Trigger the powerup effect and destroy the object
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        string tag = otherCollider.gameObject.tag;
        if (tag.Equals(GlobalVars.playerTankTag))
        {
            PowerUpEffectPlayerTriggered();
            Destroy(this.gameObject);
        }
        else if (tag.Equals(GlobalVars.enemyTankTag))
        {
            PowerUpEffectEnemyTriggered();
            if (enemyTriggerPowerUp)
                Destroy(this.gameObject);
        }   
    }

}
