using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BotLogika : MonoBehaviour
{
    float timer = 0.0f;
    NavMeshAgent bot;
    Animator animator;
    private Coroutine currentAnimationCoroutine;
    private float utokCooldown = 0f;
    private bool isAttacking = false;
    private Zivot zivotSkript;
    public Transform hrac_pozicia;
    public float max_cas = 1.0f;
    public float max_vzdialenost = 1.0f;
    public float vzdialenost_utoku = 2f;
    public float vzdialenost_stop = 2f;
    void Start()
    {
        bot = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        zivotSkript = GetComponent<Zivot>();
        bot.stoppingDistance = vzdialenost_stop;
    }
    void Update()
    {
        float health = zivotSkript.aktualnyZivot;
        max_cas -= Time.deltaTime;
        if (max_cas < 0.0f && health > 0)
        {
            float sqdistance = (hrac_pozicia.position - bot.destination).sqrMagnitude;
            if (sqdistance < max_vzdialenost)
            {
                bot.destination = hrac_pozicia.position;
            }
        }
        float vzialenostHraca = Vector3.Distance(transform.position, hrac_pozicia.position);
        if (vzialenostHraca <= vzdialenost_utoku && health > 0)
        {
            if (utokCooldown <= 0f)
                {
                    float randomValue = Random.value;
                    string animationClipName = "";
                    if (randomValue <= 0.5f)
                    {
                        animationClipName = "slash";
                    }
                    else if (randomValue <= 0.7f)
                    {
                        animationClipName = "attack1";
                    }
                    else if (randomValue <= 0.9f)
                    {
                        animationClipName = "attack2";
                    }
                    else
                    {
                        animationClipName = "block";
                    }
                    currentAnimationCoroutine = StartCoroutine(PlayAnimationAndWait(animationClipName));
                    utokCooldown = Random.Range(2.0f, 4.0f);
                    isAttacking = true;
                }
                else
                {
                    utokCooldown -= Time.deltaTime;
                }
        }
        else
        {
            if (health != 0)
            {
                animator.SetFloat("Speed", bot.velocity.magnitude);
                bot.isStopped = false;
                isAttacking = false;
            }
        }
    }
    private IEnumerator PlayAnimationAndWait(string animationClipName)
    {
        animator.Play(animationClipName);
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }
        currentAnimationCoroutine = null;
    }
}
