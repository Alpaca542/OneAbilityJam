using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshPlus;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject Player;
    public float damage;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if((Player.transform.position - transform.position).magnitude > 3f)
        {
            agent.SetDestination(Player.transform.position);
        }
        else
        {
            //shoot idk
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
