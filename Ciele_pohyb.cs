using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciele_pohyb : MonoBehaviour, Terc_pohyb
{
    private Rigidbody rigitbody;
    private bool zastavene = false;
    private Vector3 dalsiapozicia;
    private Vector3 originalpozicia;
    [SerializeField]
    private int zivot = 3;
    [SerializeField]
    private float prahdorazu = 0.1f, pohybRadius = 1, rychlost = 0.2f;
    private void Awake()
    {
        rigitbody = GetComponent<Rigidbody>();
        originalpozicia = transform.position;
        dalsiapozicia = NovaPozicia();
    }
    public void Trafil_terc()
    {
        zivot--;
        if (zivot <= 0)
        {
            zastavene = true;
            rigitbody.isKinematic = false;
        }
        DisplayScore.score++;
    }
    private Vector3 NovaPozicia()
    {
        return originalpozicia + (Vector3)Random.insideUnitCircle * pohybRadius;
    }
    private void FixedUpdate()
    {
        if (zastavene == false)
        {
            if (Vector3.Distance(transform.position, dalsiapozicia) < prahdorazu)
            {
                dalsiapozicia = NovaPozicia();
            }
            Vector3 smer = dalsiapozicia - transform.position;
            rigitbody.MovePosition(transform.position + smer.normalized * Time.fixedDeltaTime * rychlost);
        }
    }
}
public interface Terc_pohyb
{
    void Trafil_terc();
}