using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamageable
{
    public GameObject explosionVFX;
    public Rigidbody2D rigid;
    public float lifeTime = 1.5f;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Invoke("Damage", lifeTime);
    }
    public void Damage()
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
