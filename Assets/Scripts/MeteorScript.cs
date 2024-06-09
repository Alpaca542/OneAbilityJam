using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public GameObject prt;
    public LayerMask enemylayer;
    private void Start()
    {
        Instantiate(prt, transform.position, Quaternion.identity);
        foreach (Collider2D gmb in Physics2D.OverlapCircleAll(transform.position, 3f, enemylayer))
        {
            gmb.GetComponent<EnemyScript>().Die();
        }
    }
}
