using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyuBossTamaDasu : MonoBehaviour
{
    public GameObject prefabToSpawn1;

    public float spawnIntervalPrefab1 = 3f;

    float timerPrefab1 = 0f;

    void Update()
    {
        // prefabToSpawn1の生成タイミングを管理
        timerPrefab1 += Time.deltaTime;
        if (timerPrefab1 >= spawnIntervalPrefab1)
        {
            SpawnPrefab1();
            timerPrefab1 = 0f; // タイマーをリセット
        }
    }

    void SpawnPrefab1()
    {
        // prefabToSpawn1をインスタンス化して場面に追加
        Instantiate(prefabToSpawn1, transform.position + Vector3.left, Quaternion.identity);
    }

}