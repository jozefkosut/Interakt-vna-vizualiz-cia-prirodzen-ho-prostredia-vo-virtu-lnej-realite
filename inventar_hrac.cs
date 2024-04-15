using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventar_hrac : MonoBehaviour
{
    public Transform ciel;
    public Vector3 offset;
    void FixedUpdate()
    {
        transform.position = ciel.position + Vector3.up * offset.y
            + Vector3.ProjectOnPlane(ciel.right, Vector3.up).normalized * offset.x
            + Vector3.ProjectOnPlane(ciel.forward, Vector3.up).normalized * offset.z;
        transform.eulerAngles = new Vector3(0, ciel.eulerAngles.y, 0);
    }
}
