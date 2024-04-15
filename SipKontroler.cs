using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SipKontroler : MonoBehaviour
{
    [SerializeField]
    private GameObject s_bod_viz, sipPrefab, sipSpawn;
    [SerializeField]
    private float rychlost_strela = 10;
    [SerializeField]
    private AudioSource audio_strela;
    public bool isArrow;
    public void VystrelSip(float sila)
    {
        if (isArrow == true)
        {
            audio_strela.Play();
            s_bod_viz.SetActive(false);
            GameObject sip = Instantiate(sipPrefab);
            sip.transform.position = sipSpawn.transform.position;
            sip.transform.rotation = s_bod_viz.transform.rotation;
            Rigidbody rb = sip.GetComponent<Rigidbody>();
            rb.AddForce(s_bod_viz.transform.forward * sila * rychlost_strela, ForceMode.Impulse);
            isArrow = false;
        }
    }
}