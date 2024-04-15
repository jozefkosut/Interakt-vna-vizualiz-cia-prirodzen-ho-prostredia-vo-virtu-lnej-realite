using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class limit_range : MonoBehaviour
{
    public float minX = -0.68f;
    public float maxX = 0.65f;
    public float minZ = 0.07f;
    public float maxZ = 0.29f;

    private XRGrabInteractable grabInteractable;
    private bool isGrabbed = false;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(Grabbed);
        grabInteractable.selectExited.AddListener(Released);
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(Grabbed);
        grabInteractable.selectExited.RemoveListener(Released);
    }

    private void Grabbed(SelectEnterEventArgs arg)
    {
        isGrabbed = true;
    }

    private void Released(SelectExitEventArgs arg)
    {
        isGrabbed = false;
    }

    void Update()
    {
        if (isGrabbed)
        {
            Vector3 limitedPosition = transform.position;
            limitedPosition.x = Mathf.Clamp(limitedPosition.x, minX, maxX);
            limitedPosition.z = Mathf.Clamp(limitedPosition.z, minZ, maxZ);
            transform.position = limitedPosition;
        }
    }
}
