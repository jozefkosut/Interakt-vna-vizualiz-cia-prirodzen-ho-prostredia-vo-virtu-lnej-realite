using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_fix : MonoBehaviour
{
    public GameObject menu;
    void Start()
    {
        menu.SetActive(false);
        StartCoroutine(EnableObjectAfterDelay(2f));
    }

    IEnumerator EnableObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        menu.SetActive(true);
    }
}
