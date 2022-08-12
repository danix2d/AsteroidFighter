using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;

    public void SpawnPlayer()
    {
        Instantiate(player, transform.position, Quaternion.identity);
    }
}
