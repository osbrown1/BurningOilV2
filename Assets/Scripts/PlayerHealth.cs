using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private int playerHealth = 100;
    [SerializeField] private AudioSource deathSoundEffect;


    private int MAX_HEALTH = 100;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // Heal(10);
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
            Die();
        }
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
    }

    private void Die()
    {
        deathSoundEffect.Play();
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }
}