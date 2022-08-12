using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public GameEvent GameOver;
    public GameEvent PlayerDeath;
    public IntVariableEvent playerHealth;

    public GameObject explodeVFX;
    public void Damage()
    {
        playerHealth.Value--;
        Instantiate(explodeVFX, transform.position, Quaternion.identity);
        gameObject.SetActive(false);

        if (playerHealth.Value <= 0)
        {
            GameOver.Raise();
        }
        else
        {
            PlayerDeath.Raise();
        }
    }
}
