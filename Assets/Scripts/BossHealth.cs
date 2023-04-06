using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public int health = 200;

    public GameObject deathEffect;

    public bool isInvulnerable = false;

    public Animator animator;

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("hurt");
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}