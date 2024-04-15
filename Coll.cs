using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour
{
    public int index_cislo;
    BoxCollider boxCollider;
    private void Awake() {
        boxCollider = GetComponent<BoxCollider>(); 
        index_cislo = transform.GetSiblingIndex();
    }
    public void Hit_Collider(float poskodenie) {
        if (boxCollider.size.y - poskodenie > 0.0f)
            boxCollider.size = new Vector3(boxCollider.size.x, boxCollider.size.y - poskodenie, boxCollider.size.z);
        else
            Destroy(this);
    }
}
