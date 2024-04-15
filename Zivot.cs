using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Zivot : MonoBehaviour
{
    public float maxZivot;
    public float aktualnyZivot;
    Animator animator;
    [SerializeField] public TMP_Text zivotText;
    void Start()
    {
        aktualnyZivot = maxZivot;
        animator = GetComponent<Animator>();
        UpdateZivotText();
    }
    public void PoskodenieBot(float amount)
    {
        aktualnyZivot -= amount;
        UpdateZivotText();
        if (aktualnyZivot <= 0.0f)
        {
            DieBot();
        }
    }
    public void PoskodenieHrac(float amount)
    {
        aktualnyZivot -= amount;
        UpdateZivotText();
        if (aktualnyZivot <= 0.0f)
        {
            DieHrac();
        }
    }
    private void DieBot(){
        animator.SetTrigger("Death");
    }
    private void DieHrac()
    {
        SceneManager.LoadScene(1);
    }
    private void UpdateZivotText()
    {
        if (zivotText != null)
        {
            zivotText.text = "Health: " + aktualnyZivot.ToString("F0");
        }
    }
}