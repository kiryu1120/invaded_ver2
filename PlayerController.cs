using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        var moveDirection = new Vector2(x, y).normalized;
        Move(moveDirection);

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        {

        }
    }

    private void Move(Vector3 moveDirection)
    {
        var pos = transform.position;
        var moveSpeed = 7;
        pos += moveDirection * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -8.4f, 8.4f);
        pos.y = Mathf.Clamp(pos.y, -4.5f, 4.5f);
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        var layerName = LayerMask.LayerToName(col.gameObject.layer);
        if (layerName == "Enemy")
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("Game over");
        }
    }
}
