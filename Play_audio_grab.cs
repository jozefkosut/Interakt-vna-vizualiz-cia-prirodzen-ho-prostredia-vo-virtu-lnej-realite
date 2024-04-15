using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Play_audio_grab : MonoBehaviour
{
    public AudioSource audioSource; 
    private XRGrabInteractable grabInteractable;
    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(StartSound);
            grabInteractable.selectExited.AddListener(StopSound);
        }
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
            audioSource.loop = false;
        }
        else
        {
            Debug.LogError("Chyba", this);
        }
    }
    private void StartSound(SelectEnterEventArgs arg)
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    private void StopSound(SelectExitEventArgs arg)
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
