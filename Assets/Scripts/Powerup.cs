using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject vfx;
    public BulletSO powerup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(vfx, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Weapon>().bulletSO = powerup;
        }
    }
}
