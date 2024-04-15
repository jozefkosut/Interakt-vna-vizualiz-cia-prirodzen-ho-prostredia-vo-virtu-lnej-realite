using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class QuiverInteraction : MonoBehaviour
{
    public GameObject arrowPrefab;

    private XRDirectInteractor directInteractor;

    private void Start()
    {
        directInteractor = GetComponent<XRDirectInteractor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            SpawnArrowInHand(other.gameObject);
        }
        
    }

    private bool HasArrowInHand(GameObject hand)
    {
        return hand.GetComponentInChildren<SipKontroler>() != null;
    }

    private void SpawnArrowInHand(GameObject hand)
    {
        GameObject newArrow = Instantiate(arrowPrefab, hand.transform);
        newArrow.transform.localPosition = Vector3.zero;
        newArrow.transform.localRotation = Quaternion.identity;

        /*
        ArrowController arrowController = newArrow.GetComponent<ArrowController>();
        
        if (arrowController != null)
        {
            arrowController.SetHeld(true);
        }
        */
    }
}