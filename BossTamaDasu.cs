using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTamaDasu : MonoBehaviour
{
    public GameObject prefabToSpawn1;
    public GameObject prefabToSpawn2;
    public float spawnIntervalPrefab1 = 1f;
    public float spawnIntervalPrefab2 = 2.5f;

    float timerPrefab1 = 0f;
    float timerPrefab2 = 0f;

    void Update()
    {
        // prefabToSpawn1の生成タイミングを管理
        timerPrefab1 += Time.deltaTime;
        if (timerPrefab1 >= spawnIntervalPrefab1)
        {
            SpawnPrefab1();
            timerPrefab1 = 0f; // タイマーをリセット
        }

        // prefabToSpawn2の生成タイミングを管理
        timerPrefab2 += Time.deltaTime;
        if (timerPrefab2 >= spawnIntervalPrefab2)
        {
            SpawnPrefab2();
            timerPrefab2 = 0f; // タイマーをリセット
        }
    }

    void SpawnPrefab1()
    {
        // prefabToSpawn1をインスタンス化して場面に追加
        Instantiate(prefabToSpawn1, transform.position + Vector3.left, Quaternion.identity);
    }

    void SpawnPrefab2()
    {
        // prefabToSpawn2をインスタンス化して場面に追加
        Instantiate(prefabToSpawn2, transform.position + Vector3.right, Quaternion.identity);
    }
}
