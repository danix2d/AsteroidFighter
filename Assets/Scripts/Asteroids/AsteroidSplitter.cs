using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSplitter : MonoBehaviour, IDamageable
{
    [Range(2,6)]
    public int splitTo;

    public GameObject prefabAsteroids;
    public GameObject explodeVFX;
    private PolygonCollider2D parentRigid;

    private void Awake()
    {
        parentRigid = GetComponent<PolygonCollider2D>();
    }

    public void Damage()
    {
        parentRigid.enabled = false;

        Instantiate(explodeVFX, transform.position, Quaternion.identity);

        for (int i = 0; i < splitTo; i++)
        {
            int randnum = Random.Range(2, 12);
            float angle = i * Mathf.PI * 2 / splitTo;
            float x = Mathf.Cos(angle) * 2.5f;
            float y = Mathf.Sin(angle) * 2.5f;
            Vector3 pos = transform.position + new Vector3(x, y, 0);
            Vector2 rand = Random.insideUnitCircle * 2;
            Vector3 dir = pos + new Vector3(rand.x, rand.y, 0);

            GameObject asteroid;
            Rigidbody2D rigid;

            asteroid = Instantiate(prefabAsteroids, transform.position, Quaternion.identity);
            asteroid.transform.position = pos;

            rigid = asteroid.GetComponent<Rigidbody2D>();
            rigid.AddForce((dir - transform.position).normalized * randnum, ForceMode2D.Impulse);
            rigid.AddTorque(Random.Range(-10, 10),ForceMode2D.Impulse);
        }

        Destroy(this.gameObject);
    }
}
