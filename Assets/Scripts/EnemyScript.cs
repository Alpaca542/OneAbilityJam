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
    public GameObject blt;
    public float firerate;
    private bool Shooting;
    public GameObject myGun;
    public float health;
    public GameObject deathParticles;
    public GameObject money;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
            CancelInvoke(nameof(InvokeNormalColor));
            Invoke(nameof(InvokeNormalColor), 0.2f);
        }
    }
    public void InvokeNormalColor()
    {
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }
    public void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Instantiate(money, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void Update()
    {
        if((Player.transform.position - transform.position).magnitude > 3f)
        {
            agent.SetDestination(Player.transform.position);
            Shooting = false;
            CancelInvoke(nameof(ShootingInvoke));
        }
        else
        {
            agent.SetDestination(transform.position);
            if (!Shooting)
            {
                Shooting = true;
                InvokeRepeating(nameof(ShootingInvoke), 0f, firerate);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }
    public void ShootingInvoke()
    {
        GameObject bullet = Instantiate(blt, transform.position, myGun.transform.rotation);
        bullet.GetComponent<BulletScript>().FromPlayer = false;
        bullet.GetComponent<BulletScript>().Damage = damage;
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * 1000f);
    }
}
