using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Hardのゲームマネージャー
public class GameManager2 : MonoBehaviour
{
    public enum Wave
    {
        Enemy1,
        Enemy,
        Boss
    }

    public GameObject Enemy1Prefab;

    public int Enemy1Nums;

    public float Enemy1Interval;

    public GameObject Enemy2Prefab;

    public int Enemy2Nums;

    public float Enemy2Interval;

    public GameObject BossPrefab;

    public float WaveInterval;

    private Wave currentWave = Wave.Enemy1;

    private int spawnCount2 = 0;

    private int spawnCount = 0;

    private float timeCount = 0.0f;

    public static int DefeatCount = 0;

    public static int DefeatCount1 = 0;

    void Update()
    {
        switch (currentWave)
        {
            case Wave.Enemy1:
                UpdateEnemy1Wave();
                break;

            case Wave.Enemy:
                UpdateEnemyWave();
                break;

            case Wave.Boss:
                UpdateBossWave();
                break;
        }
    }
    void UpdateEnemy1Wave()
    {
        timeCount += Time.deltaTime;

        if (DefeatCount1 >= Enemy1Nums)
        {
            if (timeCount >= WaveInterval)
            {

                DefeatCount1 = 0;
                timeCount = 0;

                currentWave = Wave.Enemy;
            }
        }
        else
        {
            if (timeCount >= Enemy1Interval)
            {
                var randomPos = new Vector3(10.0f, Random.Range(-4.0f, 4.0f), 0);
                Instantiate(Enemy1Prefab, randomPos, Quaternion.identity);

                timeCount = 0;
            }
        }
    }
    void UpdateEnemyWave()
    {
        timeCount += Time.deltaTime;

        if (DefeatCount >= Enemy2Nums)
        {
            if (timeCount >= WaveInterval)
            {
                DefeatCount = 0;
                timeCount = 0;

                currentWave = Wave.Boss;
            }
        }
        else
        {
            if (spawnCount2 == 0)
            {
                Instantiate(Enemy2Prefab, new Vector3(10f, 4f, 0), Quaternion.identity);
                Instantiate(Enemy2Prefab, new Vector3(10f, -4f, 0), Quaternion.identity);
                spawnCount2++;
            }
        }
    }
    void UpdateBossWave()
    {
        if (spawnCount == 0)
        {
            Instantiate(BossPrefab, new Vector3(15f, -0.5f, 0), Quaternion.identity);
            spawnCount++;
        }
    }
}
