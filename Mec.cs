using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Mec : MonoBehaviour
{
    private XRGrabInteractable interactable;
    public AudioSource mecUder;
    public LayerMask hracLayer;
    public LayerMask botLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & hracLayer) != 0)
        {
            Zivot zivotSkript = other.gameObject.GetComponentInParent<Zivot>();
            if (zivotSkript != null)
            {
                zivotSkript.PoskodenieBot(1);
            }
        }
        if (((1 << other.gameObject.layer) & botLayer) != 0)
        {
            Zivot zivotSkript = other.gameObject.GetComponentInParent<Zivot>();
            if (zivotSkript != null)
            {
                zivotSkript.PoskodenieHrac(1);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        mecUder.Play();
    }
}
