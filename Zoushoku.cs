using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoushoku : MonoBehaviour
{
    public GameObject goEnemy; // Enemyのプレハブ
    public float spawnInterval = 2.0f;
    private float spawnTimer = 0.0f;

    public GameObject slow;
    public float spawnInterval2 = 5.0f;
    private float spawnTimer2 = 0.0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0.0f;

            // 一定時間ごとに生産スピードを上げる（例：現在の生産間隔を0.9倍にする）
            spawnInterval *= 0.95f;
        }

        spawnTimer2 += Time.deltaTime;
        if (spawnTimer2 >= spawnInterval2)
        {
            SpawnEnemy();
            spawnTimer2 = 0.0f;

            // 一定時間ごとに生産スピードを上げる（例：現在の生産間隔を1.0倍にする）
            spawnInterval2 *= 0.95f;
        }
    }

    void SpawnEnemy()
    {
        // ランダムなY座標を生成
        float randomY = Random.Range(-4.5f, 4.5f);
        float newrandomY = Random.Range(-4.5f, 4.5f);

        // Enemyを生成（X座標は8のまま）
        Vector3 spawnPosition = new Vector3(8.0f, randomY, 0.0f);
        Instantiate(goEnemy, spawnPosition, Quaternion.identity);

        Vector3 spawnPosition2 = new Vector3(8.0f, newrandomY, 0.0f);
        Instantiate(slow, spawnPosition2, Quaternion.identity);
    }
}