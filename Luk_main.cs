using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Luk_main : MonoBehaviour
{
    [SerializeField]
    private Tetiva tetivaRender;
    private XRGrabInteractable interakciaTetiva;
    [SerializeField]
    private Transform s_bod_grab, s_bod_viz, s_bod_rodic;
    [SerializeField]
    private float luk_max_natiahnutie = 0.3f;
    private Transform interakcia;
    private float sila;
    [SerializeField]
    public UnityEvent<float> Luk_pusteny;
    public AudioSource zvuk;
    private bool zvukLoop = false;
    private void Awake()
    {
        interakciaTetiva = s_bod_grab.GetComponent<XRGrabInteractable>();
    }
    private void Start()
    {
        interakciaTetiva.selectEntered.AddListener(NatiahniTetivu);
        interakciaTetiva.selectExited.AddListener(VyrovnajTetivu);
    }
    private void VyrovnajTetivu(SelectExitEventArgs arg0)
    {
        Luk_pusteny?.Invoke(sila);
        sila = 0;
        interakcia = null;
        s_bod_grab.localPosition = Vector3.zero;
        s_bod_viz.localPosition = Vector3.zero;
        tetivaRender.VytvorTetivu(null);
    }
    private void NatiahniTetivu(SelectEnterEventArgs arg0)
    {
        interakcia = arg0.interactorObject.transform;
    }
    private void Update()
    {
        if (interakcia != null)
        {
            Vector3 stredLocal = s_bod_rodic.InverseTransformPoint(s_bod_grab.position);
            float stredLocalZ = Mathf.Abs(stredLocal.z);
            PosunutLimit(stredLocal);
            NatiahnutLimit(stredLocalZ, stredLocal);
            Natiahnut_luk(stredLocalZ, stredLocal);
            tetivaRender.VytvorTetivu(s_bod_viz.position);
        }
    }
    private void Natiahnut_luk(float stredLocalZ, Vector3 stredLocal)
    {
        if (stredLocal.z < 0 && stredLocalZ < luk_max_natiahnutie)
        {
            if (!zvukLoop)
            {
                zvuk.Play();
                zvukLoop = true;
            }
            sila = VypocitajSilu(stredLocalZ, 0, luk_max_natiahnutie, 0, 1);
            s_bod_viz.localPosition = new Vector3(0, 0, stredLocal.z);
        }
    }
    private void NatiahnutLimit(float stredLocalZ, Vector3 stredLocal)
    {
        if (stredLocal.z < 0 && stredLocalZ >= luk_max_natiahnutie)
        {
            zvuk.Stop();
            zvukLoop = false;
            sila = 1;
            s_bod_viz.localPosition = new Vector3(0, 0, -luk_max_natiahnutie);
        }
    }
    private void PosunutLimit(Vector3 stredovybod)
    {
        if (stredovybod.z >= 0)
        {
            zvuk.Stop();
            zvukLoop = false;
            sila = 0;
            s_bod_viz.localPosition = Vector3.zero;
        }
    }
    private float VypocitajSilu(float stredLocalZ, int od_Min, float od_Max, int do_Min, int do_Max)
    {
        return (stredLocalZ - od_Min) / (od_Max - od_Min) * (do_Max - do_Min) + do_Min;
    }
}