using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    private Animator anim;

    public bool isDead = false;

    [SerializeField] private int playerHealth = 100;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private Text healthText;


    private int MAX_HEALTH = 100;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.playerHealth -= amount;

        if (playerHealth <= 0)
        {
            deathSoundEffect.Play();
            Die();
        }
        else
        {
            animator.SetBool("IsHurt", true);
            StartCoroutine(ResetIsHurtBool());
            UpdateHealthText();
        }
    }

    private IEnumerator ResetIsHurtBool()
    {
        yield return new WaitForSeconds(.1f);
        animator.SetBool("IsHurt", false);
    }


    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = playerHealth + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.playerHealth = MAX_HEALTH;
        }
        else
        {
            this.playerHealth += amount;
        }

        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        if (healthText == null)
        {
            Debug.LogError("Health text not set in the inspector.");
            return;
        }


        healthText.text = "Health: " + playerHealth.ToString();
    }

    private void Die()
    {
        isDead = true;
        healthText.text = "Dead!!!";

        animator.SetBool("IsHurt", false);
        animator.SetBool("IsDead", true);
        deathSoundEffect.Play();


        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;

        this.enabled = false;

    }


}