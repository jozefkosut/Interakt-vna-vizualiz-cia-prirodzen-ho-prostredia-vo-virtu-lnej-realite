using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private bool inputActive = true;
    [SerializeField]
    private float casDelay = 1.0f;

    private void Start()
    {
        StartCoroutine(DisableInputCooldown());
    }
    private IEnumerator DisableInputCooldown()
    {
        yield return new WaitForSeconds(casDelay);
        inputActive = false;
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(casDelay);
        if (!inputActive)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    public void LoadScene_ST()
    {
        if (!inputActive)
        {
            StartCoroutine(LoadSceneAfterDelay("Sword_training"));
        }
    }

    public void LoadScene_BT()
    {
        SceneManager.LoadScene("ArcheryScene");
    }

    public void LoadScene_FT()
    {
        SceneManager.LoadScene("fly_test");
    }

    public void LoadScene_Bot()
    {
        SceneManager.LoadScene("bot_test");
    }

    public void LoadScene_default()
    {
        SceneManager.LoadScene("Default");
    }

    public void LoadScene_Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}


