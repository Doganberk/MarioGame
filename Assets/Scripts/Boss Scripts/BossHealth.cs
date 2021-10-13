using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    private Animator anim;
    private int health = 10;

    private bool canDamage;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        canDamage = true;
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(1f);
        canDamage = true;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (canDamage)
        {
            if (target.tag == MyTags.BULLET_TAG)
            {
                health--;
                canDamage = false;

                if (health == 0)
                {
                    anim.Play("BossDead");
                    GetComponent<BossScript>().DeactivateBossScript();
                    StartCoroutine(Dead());
                }

                StartCoroutine(WaitForDamage());
            }
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("EndGame");
    }
}
