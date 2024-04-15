using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject controller;
    public GameObject menu;
    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;
    public GameObject scene4;
    public GameObject scene5;

    public GameObject dalej;
    public GameObject spat;
    public GameObject panel;

    public void Dalej()
    {
        dalej.SetActive(false);
        controller.SetActive(false);
        menu.SetActive(true);
        panel.SetActive(true);
    }
    public void Spat()
    {
        menu.SetActive(true);
        panel.SetActive(true);
        spat.SetActive(false);
        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(false);
        scene5.SetActive(false);
    }
    public void Castle()
    {
        controller.SetActive(false);
        menu.SetActive(false);
        scene1.SetActive(true);
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(false);
        scene5.SetActive(false);
        panel.SetActive(false);
        spat.SetActive(true);
    }
    public void Sword()
    {
        controller.SetActive(false);
        menu.SetActive(false);
        scene1.SetActive(false);
        scene2.SetActive(true);
        scene3.SetActive(false);
        scene4.SetActive(false);
        scene5.SetActive(false);
        panel.SetActive(false);
        spat.SetActive(true);
    }
    public void Bow()
    {
        controller.SetActive(false);
        menu.SetActive(false);
        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(true);
        scene4.SetActive(false);
        scene5.SetActive(false);
        panel.SetActive(false);
        spat.SetActive(true);
    }
    public void Fly()
    {
        controller.SetActive(false);
        menu.SetActive(false);
        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(true);
        scene5.SetActive(false);
        panel.SetActive(false);
        spat.SetActive(true);
    }
    public void Bot()
    {
        controller.SetActive(false);
        menu.SetActive(false);
        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(false);
        scene4.SetActive(false);
        scene5.SetActive(true);
        panel.SetActive(false);
        spat.SetActive(true);
    }
}
