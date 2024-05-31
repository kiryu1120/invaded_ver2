using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//STARTのゲームマネージャー
public class GameManager : MonoBehaviour
{
    public enum Wave
    {
        Block,
        Enemy,
        Boss
    }

    public GameObject BlockPrefab;

    public int BlockNums;

    public float BlockInterval;

    public GameObject EnemyPrefab;

    public int EnemyNums;

    public float EnemyInterval;

    public GameObject BossPrefab;

    public float WaveInterval;

    private Wave currentWave = Wave.Block;

    private int spawnCount = 0;

    private float timeCount = 0.0f;

    public static int DefeatCount = 0;

    public static int DefeaCount { get; internal set; }

    void Update()
    {
        switch (currentWave)
        {
            case Wave.Block:
                UpdateBlockWave();
                break;

            case Wave.Enemy:
                UpdateEnemyWave();
                break;

            case Wave.Boss:
                UpdateBossWave();
                break;
        }
    }
    void UpdateBlockWave()
    {
        timeCount += Time.deltaTime;

        if(spawnCount >= BlockNums){
            if(timeCount >= WaveInterval){
                spawnCount = 0;
                timeCount = 0;

                currentWave = Wave.Enemy;
            }
        }
        else{
            if(timeCount >= BlockInterval){
                Instantiate(BlockPrefab, new Vector3(10.0f, 0f, 0),Quaternion.identity);
                spawnCount++;
                timeCount = 0;
            }
        }
    }
    void UpdateEnemyWave()
    {
        timeCount += Time.deltaTime;

        if(DefeatCount >= EnemyNums){
            if(timeCount >= WaveInterval){
                DefeatCount = 0;
                timeCount = 0;

                currentWave = Wave.Boss;
            }
        }else{
            if(timeCount >= EnemyInterval){
                var randomPos = new Vector3(10.0f, Random.Range(-4.0f, 4.0f), 0);
                Instantiate(EnemyPrefab, randomPos, Quaternion.identity);

                timeCount = 0;
            }
        }
    }
    void UpdateBossWave()
    {
        if(spawnCount == 0){
            Instantiate(BossPrefab, new Vector3(15f, -0.5f, 0), Quaternion.identity);
            spawnCount++;
        }
    }
}
