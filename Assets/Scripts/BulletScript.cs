using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool FromPlayer;
    public float Damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !FromPlayer)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(Damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy" && FromPlayer)
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}