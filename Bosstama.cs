using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosstama : MonoBehaviour
{
    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        Move(Vector2.left);
        if (transform.position.x <= -10.0f)
        {
            Destroy(this.gameObject);
        }
    }
    private void Move(Vector3 moveDirection)
    {
        var pos = transform.position;
        var moveSpeed = 10;
        pos += moveDirection * moveSpeed * Time.deltaTime;
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        var LayerName = LayerMask.LayerToName(col.gameObject.layer);
        if (LayerName == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
        if (LayerName == "Block")
        {
            Destroy(this.gameObject);
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
        if (LayerName == "Bullet")
        {
            Destroy(this.gameObject);
            Instantiate(Effect, transform.position, Quaternion.identity);
        }
    }
}
