using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float startingValue = 1.5f;
    private float currentValue;
    public float Enemyamount;
    public GameObject[] Enemies;
    public Transform anchor1;
    public Transform anchor2;

    void Start()
    {
        currentValue = startingValue;
        StartCoroutine(SpawningCourutine());
    }

    public IEnumerator SpawningCourutine()
    {
        for (int i = 0; i < Enemyamount; i++)
        {
            yield return new WaitForSeconds(currentValue);
            Instantiate(Enemies[Random.Range(0, Enemies.Length)], new Vector2(Random.Range(anchor1.position.x, anchor2.position.x), Random.Range(anchor1.position.y, anchor2.position.y)), Quaternion.identity);
            currentValue -= 0.02f;
        }
    }
}