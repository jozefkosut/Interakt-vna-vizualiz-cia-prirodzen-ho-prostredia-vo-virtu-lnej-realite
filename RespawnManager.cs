using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject objectToRespawn;
    public float respawnDelay = 3f; // Time in seconds before respawning

    private void Start()
    {
        // Spawn the object initially
        SpawnObject();
    }

    private void SpawnObject()
    {
        Instantiate(objectToRespawn, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        // When the object is destroyed, schedule a respawn
        Invoke("SpawnObject", respawnDelay);
    }
}

