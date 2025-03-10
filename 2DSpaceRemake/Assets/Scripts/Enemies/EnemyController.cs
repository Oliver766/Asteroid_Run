using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum State
    {
        Idle,
        Chasing,
        Attacking
    }

    public float speed = 2.0f;
    public float attackRange = 1.0f;
    public int damage = 10;
    private Transform player;
    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                Idle();
                break;
            case State.Chasing:
                Chase();
                break;
            case State.Attacking:
                Attack();
                break;
        }
    }

    void Idle()
    {
        if (player != null && Vector3.Distance(transform.position, player.position) < attackRange * 5)
        {
            currentState = State.Chasing;
        }
    }

    void Chase()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                currentState = State.Attacking;
            }
        }
    }

    void Attack()
    {
        if (player != null && Vector3.Distance(transform.position, player.position) > attackRange)
        {
            currentState = State.Chasing;
        }
        else
        {
            // Implement attack logic here, e.g., reduce player's health
            Debug.Log("Enemy attacks and deals " + damage + " damage.");
        }
    }
}
