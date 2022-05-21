using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Tooltip("Hangi nesnenin �retilece�i")]
    [SerializeField] GameObject enemyPrefab;
    [Tooltip("Havuzun geni�li�i")]
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [Tooltip("Kac Saniyede Spawn olucak")]
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;


    [Tooltip("Pool Dizisi")]
    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }


    void PopulatePool() //Havuzu Doldur
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++) //dizi uzunlu�u kadar d�n
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }
    void EnableObjectPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy==false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

}
