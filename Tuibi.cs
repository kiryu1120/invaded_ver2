
using UnityEngine;


public class Tuibi : MonoBehaviour
{
    public AudioClip audioSource;
    public float moveSpeed = 8f;
    private Transform player;

    void Start()
    {
        // "Player" レイヤーのオブジェクトを検索して player 変数に割り当てます
        player = GameObject.FindWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player オブジェクトが見つかりません。");
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            if (transform.position.x <= -20f)
            {
                Destroy(gameObject);
               
            }
        }
    }
    public GameObject Effect;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        var LayerName = LayerMask.LayerToName(col.gameObject.layer);
        if (LayerName == "Bullet")
        {
            //GetComponent<AudioSource>().PlayOneShot(audioSource);
            GetComponent<AudioSource>().clip = audioSource;
            GetComponent<AudioSource>().Play();
            GameObject.Find("Text2").GetComponent<ScoreCounter>().AddScoreTuibe();
            Destroy(this.gameObject);
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
    }
}
