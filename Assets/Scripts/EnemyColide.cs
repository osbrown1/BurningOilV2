using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColide : MonoBehaviour
{
    [SerializeField] private int damage;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        // check if the collision is with the player
     /*   if (.collider == true)
            {
            PlayerHealth health = coll.collider.GetComponent<PlayerHealth>();
            health.Damage(damage);

        }*/



    }
}
 

