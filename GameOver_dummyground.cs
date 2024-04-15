using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_dummyground : MonoBehaviour
{
    public int maxError = 3;
    private int currentError = 0;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.CompareTag("O3"))
        {
            currentError++;
            if (currentError == maxError)
            {
                
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            }
            //displayScore.safe();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
        }
        
    }
}
