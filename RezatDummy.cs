using UnityEngine;
using EzySlice;

public class RezatDummy : MonoBehaviour
{
    public Transform startBod;
    public Transform endBod;
    public VelocityEstimator velocityEstimator;
    public LayerMask rezatLayer;
    public AudioSource zvuk_rezat;
    public Material rezaciMaterial;
    public float sila_rezat = 1000;
    void Start()
    {
        zvuk_rezat = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        RaycastHit trefa;
        Vector3 smerMec = endBod.position - startBod.position;
        bool trafil = Physics.Raycast(startBod.position, smerMec, out trefa, smerMec.magnitude, rezatLayer);
        if (trafil)
        {
            Rez(trefa.transform.gameObject, trefa.point, velocityEstimator.GetVelocityEstimate());
        }
    }

    public void Rez(GameObject dummy, Vector3 planePozicia, Vector3 rychlostRezu)
    {
        Vector3 smerMec = endBod.position - startBod.position;
        Vector3 smerPlane = Vector3.Cross(rychlostRezu, smerMec);
        SlicedHull hull = dummy.Slice(endBod.position, smerPlane);
        zvuk_rezat.Play();
        if (hull != null)
        {
            DisplayScore.score2++;
            GameObject vrch = hull.CreateUpperHull(dummy, rezaciMaterial);
            GameObject spodok = hull.CreateLowerHull(dummy, rezaciMaterial);
            ModelpreRezany(vrch);
            ModelpreRezany(spodok);
            Destroy(dummy);
        }
    }

    public void ModelpreRezany(GameObject dummyPolka)
    {
        Rigidbody rb = dummyPolka.AddComponent<Rigidbody>();
        MeshCollider collider = dummyPolka.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(sila_rezat, dummyPolka.transform.position, 1);
        // viac rezov
        //dummyPolka.layer = LayerMask.NameToLayer("Sliceable");
        dummyPolka.layer = LayerMask.NameToLayer("Cut");
        //Destroy(dummyPolka, 10);
    }
}

