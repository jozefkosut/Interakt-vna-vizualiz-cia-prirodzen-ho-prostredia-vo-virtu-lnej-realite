using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nozik : MonoBehaviour
{
    [SerializeField] private float poskodenie_sila;
    [SerializeField] private Drevo Drevo;
    [SerializeField] private ParticleSystem drevoFX;
    public AudioSource audio_efekt;
    private ParticleSystem.EmissionModule drevo_efekt;
    private void Start() {
        drevo_efekt = drevoFX.emission;
    }
    private void Update() {
    }
    private void OnCollisionExit(Collision collision)
    {
        drevo_efekt.enabled = false;
    }

    private void OnCollisionStay(Collision collision) {
        Coll coll = collision.collider.GetComponent <Coll> ();
        if (coll != null) {
            drevo_efekt.enabled = true;
            PlayzaCas(1f);
            drevoFX.transform.position = collision.contacts[0].point;
            coll.Hit_Collider(poskodenie_sila);
            Drevo.Hit(coll.index_cislo,poskodenie_sila);
        }
    }
    public void PlayzaCas(float duration)
    {
        StartCoroutine(PlayAudioefekt(duration));
    }
    private IEnumerator PlayAudioefekt(float duration)
    {
        audio_efekt.Play(); 
        yield return new WaitForSeconds(duration);
        audio_efekt.Stop();
    }
}
