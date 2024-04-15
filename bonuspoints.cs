using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonuspoints : MonoBehaviour, Terc_pohyb
{
    public void Trafil_terc()
    {
        DisplayScore.score += 5;
        
    }

    public interface Terc_pohyb
    {
        void Trafil_terc();
    }
}

