using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private bool hasHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (this.gameObject.CompareTag("Asteroid") && collision.gameObject.CompareTag("Asteroid")) { return; }

        if(collision.gameObject)
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if(damageable != null)
            {
                damageable.Damage();
            }
        }

    }
}
