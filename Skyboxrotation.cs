using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skyboxrotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float Skyboxspeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * Skyboxspeed);
    }
}
