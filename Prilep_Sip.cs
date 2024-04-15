using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prilep_Sip : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private SphereCollider colliderHrot;
    [SerializeField]
    private GameObject sipPrilepit;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "O3")
        {
            rb.isKinematic = true;
            colliderHrot.isTrigger = true;
            GameObject sip = Instantiate(sipPrilepit);
            sip.transform.position = transform.position;
            sip.transform.forward = transform.forward;
            if (collision.collider.attachedRigidbody != null)
            {
                sip.transform.parent = collision.collider.attachedRigidbody.transform;
            }
            collision.collider.GetComponent<Terc_pohyb>()?.Trafil_terc();
            Destroy(gameObject);
        }
    }
}