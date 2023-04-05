using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    private int currentPointIndex = 0;
    private Vector2 currentTarget;


    void Start()
    {
        currentTarget = patrolPoints[currentPointIndex].position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentTarget) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
            currentTarget = patrolPoints[currentPointIndex].position;
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        // Flip the sprite horizontally if moving to the left
        if (transform.position.x > currentTarget.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        // Flip the sprite back to normal if moving to the right
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}