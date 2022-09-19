using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject sword, fakeSword;
    public Animator anim;
    public float attackCooldown = 1.0f;
    public bool canAttack = true;
    public bool isAttacking = false;
    public bool isArmed = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sword.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!isArmed)
            {
                isArmed = true;
                anim.SetTrigger("isArmed");
                StartCoroutine(GetSword(0.35f, true));
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isArmed)
            {
                isArmed = false;
                anim.SetTrigger("isDisarmed");
                StartCoroutine(GetSword(1.0f, false));
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (canAttack && isArmed)
            {
                SwordAttacking();
            }
        }
    }

    void SwordAttacking()
    {
        canAttack = false;
        isAttacking = true;
        anim.SetTrigger("Attack");
        StartCoroutine(ResetSwordAttacking());
    }

    IEnumerator ResetSwordAttacking()
    {
        StartCoroutine(ResetAttack());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    IEnumerator GetSword(float time, bool active)
    {
        yield return new WaitForSeconds(time);
        sword.SetActive(active);
        fakeSword.SetActive(!active);
    }
}
