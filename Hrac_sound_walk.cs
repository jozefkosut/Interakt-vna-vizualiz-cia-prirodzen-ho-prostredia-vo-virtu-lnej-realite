using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hrac_sound_walk : MonoBehaviour
{
    public float movementThreshold = 0.1f; // Min pohyb pre zvuk
    public AudioSource walk;
    public Vector3 pozicia;

    void Start()
    {
        walk = GetComponent<AudioSource>();
        pozicia = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, pozicia) > movementThreshold)
        {
            if (!walk.isPlaying)
            {
                walk.Play();
            }
        }
        else
        {
            if (walk.isPlaying)
            {
                walk.Stop();
            }
        }
        pozicia = transform.position;
    }
}
