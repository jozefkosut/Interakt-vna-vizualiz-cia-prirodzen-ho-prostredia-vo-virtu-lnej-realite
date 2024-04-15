using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SipRotacia : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigitbody;
    private void FixedUpdate()
    {
        transform.forward = Vector3.Slerp(transform.forward, rigitbody.velocity.normalized, Time.fixedDeltaTime);
    }

}