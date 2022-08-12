using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public float spawnTime;
    public List<SpawnChance> powerup = new List<SpawnChance>();

    private bool hasSpawn;

    private void Update()
    {
        if (hasSpawn == false)
        {
            StartCoroutine(Spawn(spawnTime));
        }
    }

    private IEnumerator Spawn(float time)
    {
        hasSpawn = true;

        GameObject powerupObj = Instantiate(CalculateWeight(), transform.position + RandomPointOnCircleEdge(Random.Range(60, 80)), transform.rotation);

        Rigidbody2D rigid = powerupObj.GetComponent<Rigidbody2D>();
        rigid.AddForce(-(powerupObj.transform.position - RandomPointOnCircleEdge(10)).normalized * 5, ForceMode2D.Impulse);

        yield return new WaitForSeconds(time);
        hasSpawn = false;
    }


    private GameObject CalculateWeight()
    {
        int weight = 0;
        GameObject power = null;

        for (int i = 0; i < powerup.Count; i++)
        {
            weight += powerup[i].rarity;
        }

        int randValue = Random.Range(0, weight);
        int top = 0;

        for (int z = 0; z < powerup.Count; z++)
        {
            top += powerup[z].rarity;
            if (randValue < top)
            {
                power = powerup[z].powerupPrefab;
                break;
            }
        }
        return power;
    }

    private Vector3 RandomPointOnCircleEdge(float radius)
    {
        var vector2 = Random.insideUnitCircle.normalized * radius;
        return new Vector3(vector2.x, vector2.y, 0);
    }


    [System.Serializable]
    public class SpawnChance
    {
        public GameObject powerupPrefab;
        public float lifeTime;
        public int rarity;
    }
}
