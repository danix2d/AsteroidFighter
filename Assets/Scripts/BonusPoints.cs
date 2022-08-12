using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPoints : MonoBehaviour, IDamageable
{
    public IntVariableEvent PlayerScore;
    public void Damage()
    {
        PlayerScore.Value += 100;
        Destroy(gameObject);
    }
}
