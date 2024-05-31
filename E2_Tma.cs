using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Hardの中ボスの弾
public class E2_Tma : MonoBehaviour
{
    public float speed = 3.0f; // 追尾速度
    public float chaseRange = 20.0f; // 追尾範囲
    private Transform player; // プレイヤーのTransform
    private Animator animator;
    public GameObject Effect;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // "Player" タグを持つオブジェクトのTransformを取得
    }

    void Update()
    {
        if (transform.position.x >= 12.0f)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.x <= -12.0f)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y >= 8.0f)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y <= -8.0f)
        {
            Destroy(this.gameObject);
        }
        // プレイヤーとの距離を計算
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 追尾範囲内にプレイヤーが入ったら追尾
        if (distanceToPlayer <= chaseRange)
        {
            // プレイヤーの方に向かって移動
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        // プレイヤーの方を向く
        Vector3 direction = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 反転処理を追加
        transform.rotation = Quaternion.Euler(0, 0, angle - 0);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        var LayerName = LayerMask.LayerToName(col.gameObject.layer);
        if (LayerName == "Bullet")
        {
            Destroy(this.gameObject);
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }


}
