using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

    public int health = 200;
    public bool isBossDead = false;

    [SerializeField] private Text bossHealthText;

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
        UpdateBossHealthText();
    }

    private void UpdateBossHealthText()
    {
        if (bossHealthText == null)
        {
            Debug.LogError("Health text not set in the inspector.");
            return;
        }

        if (isBossDead == true)
        {
            bossHealthText.text = "";
        }

        bossHealthText.text = "Boss Health: " + health;
    }

    void Die()
    {

        isBossDead = true;

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;


        this.enabled = false;
        Destroy(gameObject);
    }

}