using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public float velocityIntensity;
    public float rychlost_strelby = 5.0f;
    public GameObject[] prefabs;
    public Transform[] spawnPoints;
    public AudioSource startSound;
    public float spawnCas = 2;
    public AudioSource spawnSound;
    private float spawnDelay = 6.0f;
    private float cas = 0.0f;
    private bool spawningStarted = false;
    private bool spawningTrigger = false;
    public TextMeshPro spawnDelayText;
    void Start()
    {
        spawnSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawningTrigger = true;
        }
    }
    void LateUpdate()
    {
        if (spawningTrigger == true)
        {
            if (!spawningStarted)
            {
                spawnDelay -= Time.deltaTime;
                spawnDelayText.text = $"{spawnDelay:F2}";
                if (spawnDelay <= 0.0f)
                {
                    spawningStarted = true;
                    spawnDelayText.gameObject.SetActive(false);
                    if (!startSound.isPlaying)
                    {
                        startSound.Play();
                    }
                }
                else
                {
                    return;
                }
            }
            cas += Time.deltaTime;
            if (cas > spawnCas)
            {
                Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];
                GameObject spawnedPrefab = Instantiate(randomPrefab, randomPoint.position, randomPoint.rotation * Quaternion.Euler(0, Random.Range(0, 360), 0));
                cas -= spawnCas;
                Rigidbody rb = spawnedPrefab.GetComponent<Rigidbody>();
                rb.velocity = randomPoint.forward * velocityIntensity;
                rb.angularVelocity = new Vector3(Random.Range(-rychlost_strelby, rychlost_strelby), Random.Range(-rychlost_strelby, rychlost_strelby), Random.Range(-rychlost_strelby, rychlost_strelby));
                spawnSound.Play();
            }
        }
    }
}