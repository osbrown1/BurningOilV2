using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public int health = 200;

    //public GameObject deathEffect;

    public bool isInvulnerable = false;

    public Animator animator;

    public void TakeDamage(int damage, float delay)
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
        Debug.Log("Hit BOSS");
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;

        this.enabled = false;
        Destroy(gameObject);
    }

}