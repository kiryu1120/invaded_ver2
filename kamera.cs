using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Move(Vector3 moveDirection)
    {
        var pos = transform.position;
        var moveSpeed = 6;
        pos += moveDirection * moveSpeed * Time.deltaTime;
        transform.position = pos;
    }
    // Update is called once per frame
    void Update()
        {
            // ランダムなX座標とY座標を生成
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);

            // ランダムな位置へ移動するベクトルを生成
            Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

            // 移動速度を設定
            float moveSpeed = 2f;

            // Bossをランダムな位置に移動させる
            Move(randomPosition.normalized * moveSpeed);
        }
}
