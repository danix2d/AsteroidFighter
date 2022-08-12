using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public IntVariableEvent PlayerScore;
    public List<AsteroidSetup> asteroids = new List<AsteroidSetup>();

    private bool hasSpawn;

    private void Update()
    {
        GetAsteroid();
    }

    private void GetAsteroid()
    {
        if (hasSpawn == false)
        {
            for (int i = 0; i < asteroids.Count; i++)
            {
                if (PlayerScore.Value <= asteroids[i].spawnScore)
                {
                    StartCoroutine(Spawn(asteroids[i]));
                    break;
                }
            }
        }
    }

    private IEnumerator Spawn(AsteroidSetup setup)
    {
        hasSpawn = true;

        int rand = Random.Range(0, setup.asteroidsToSpawn.Count);

        GameObject asteroid = Instantiate(setup.asteroidsToSpawn[rand], transform.position + RandomPointOnCircleEdge(Random.Range(60,80)), transform.rotation);

        Rigidbody2D rigid = asteroid.GetComponent<Rigidbody2D>();
        rigid.AddForce(-(asteroid.transform.position - RandomPointOnCircleEdge(10)).normalized * 10,ForceMode2D.Impulse);
        rigid.AddTorque(Random.Range(-10, 10),ForceMode2D.Impulse);

        yield return new WaitForSeconds(setup.spawnTime);
        hasSpawn = false;
    }

    private Vector3 RandomPointOnCircleEdge(float radius)
    {
        var vector2 = Random.insideUnitCircle.normalized * radius;
        return new Vector3(vector2.x, vector2.y, 0);
    }
}


[System.Serializable]
public class AsteroidSetup
{
    public float spawnTime;
    public float spawnScore;
    public float spawnNumber;
    public List<GameObject> asteroidsToSpawn = new List<GameObject>();
}

