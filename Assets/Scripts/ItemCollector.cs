using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int apples = 0;
    

    [SerializeField] private Text applesText;
    [SerializeField] private PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null || collision.gameObject == null)
        {
            return;
        }
        if (collision.gameObject.CompareTag("Apple"))
        {
            if(!collision.gameObject.GetComponent<SpriteRenderer>().enabled)
            {
                return;
            }
            Destroy(collision.gameObject);
            apples++;
            applesText.text = "Apples: " + apples;
            playerHealth.Heal(10);
        }
    }


}
