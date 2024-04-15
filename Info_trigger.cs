using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info_trigger : MonoBehaviour
{
    public GameObject text_info;
    public AudioSource audio_info;
    void Start()
    {
        audio_info = GetComponent<AudioSource>();

        if (text_info != null)
        {
            text_info.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (text_info != null)
            {
                text_info.SetActive(true);
            }
            if (audio_info != null)
            {
                audio_info.Play();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (text_info != null)
            {
                text_info.SetActive(false);
            }

            if (audio_info != null)
            {
                audio_info.Stop();
            }
        }
    }
}
