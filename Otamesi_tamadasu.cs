using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otamesi_tamadasu : MonoBehaviour
{
    public GameObject goEnemy; // Enemyのプレハブ
    public float spawnInterval = 2.0f;
    private float spawnTimer = 0.0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0.0f;

            // 一定時間ごとに生産スピードを上げる（例：現在の生産間隔を0.9倍にする）
            spawnInterval *= 1f;
        }
    }

    void SpawnEnemy()
    {
        // ランダムなY座標を生成
        float randomY = Random.Range(3f, 3f);

        // Enemyを生成（X座標は8のまま）
        Vector3 spawnPosition = new Vector3(8.0f, randomY, 0.0f);
        Instantiate(goEnemy, spawnPosition, Quaternion.identity);
    }
}
