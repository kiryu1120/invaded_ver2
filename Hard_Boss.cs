using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SBOSS : MonoBehaviour
{
    public int HP = 100;
    public float speed = 7f;
    public float speed2 = 9f;
    public float speed3 = 11f;
    public float speed4 = 13f;
    public float maxY = 4.0f;
    public float minY = -4.0f;


    private Vector3 originalPosition;
    public enum ActionPattern
    {
        Apper,
        Move,
        Ikari,
        Modoru,
        Move2,
        Ikari2,
        Modoru2,
        Move3,
        Ikari3,
        Modoru3,
        Move4,
    }
    private ActionPattern currentAction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentAction)
        {
            case ActionPattern.Apper:
                UpdateAppearAction();
                break;
            case ActionPattern.Move:
                UpdateMove();
                break;
            case ActionPattern.Ikari:
                UpdateIkari();
                break;
            case ActionPattern.Modoru:
                UpdateModoru();
                break;
            case ActionPattern.Move2:
                UpdateMove2();
                break;
            case ActionPattern.Ikari2:
                UpdateIkari2();
                break;
            case ActionPattern.Modoru2:
                UpdateModoru2();
                break;
            case ActionPattern.Move3:
                UpdateMove3();
                break;
            case ActionPattern.Ikari3:
                UpdateIkari3();
                break;
            case ActionPattern.Modoru3:
                UpdateModoru3();
                break;
            case ActionPattern.Move4:
                UpdateMove4();
                break;
        }
    }
    private void Move2(Vector3 moveDirection)//アタック用のmove2
    {
        var pos = transform.position;
        var moveSpeed = 15;
        pos += moveDirection * moveSpeed * Time.deltaTime;
        transform.position = pos;
    }
    private void Move(Vector3 moveDirection)
    {
        var pos = transform.position;
        var moveSpeed = 6;
        pos += moveDirection * moveSpeed * Time.deltaTime;
        transform.position = pos;
    }
    private void UpdateAppearAction()
    {
        Move(Vector2.left);
        if (transform.position.x <= 6f)
        {
            currentAction = ActionPattern.Move;
        }
    }

    private void UpdateMove()
    {
        float newY = Mathf.PingPong(Time.time * speed, maxY - minY) + minY;
        transform.position = new Vector2(transform.position.x, newY);

        if (HP == 90)
        {
            currentAction = ActionPattern.Ikari;
        }
    }

    private void UpdateIkari()
    {
        Move2(Vector2.left);
        if (transform.position.x <= -7.5f)
        {
            currentAction = ActionPattern.Modoru;
        }

    }
    private void UpdateModoru()
    {
        Move2(Vector2.right);
        if (transform.position.x >= 6f)
        {
            currentAction = ActionPattern.Move2;
        }
    }
    private void UpdateMove2()
    {
        float newY = Mathf.PingPong(Time.time * speed2, maxY - minY) + minY;
        transform.position = new Vector2(transform.position.x, newY);

        if(HP == 60)
        {
            currentAction = ActionPattern.Ikari2;
        }
    }
    private void UpdateIkari2()
    {
        Move2(Vector2.left);
        if (transform.position.x <= -7.5f)
        {
            currentAction = ActionPattern.Modoru2;
        }
    }
    private void UpdateModoru2()
    {
        Move2(Vector2.right);
        if (transform.position.x >= 6f)
        {
            currentAction = ActionPattern.Move3;
        }
    }
    private void UpdateMove3()
    {
        float newY = Mathf.PingPong(Time.time * speed3, maxY - minY) + minY;
        transform.position = new Vector2(transform.position.x, newY);

        if (HP == 30)
        {
            currentAction = ActionPattern.Ikari3;
        }
    }
    private void UpdateIkari3()
    {
        Move2(Vector2.left);
        if (transform.position.x <= -7.5f)
        {
            currentAction = ActionPattern.Modoru3;
        }
    }
    private void UpdateModoru3()
    {
        Move2(Vector2.right);
        if (transform.position.x >= 6f)
        {
            currentAction = ActionPattern.Move4;
        }
    }
    private void UpdateMove4()
    {
        float newY = Mathf.PingPong(Time.time * speed4, maxY - minY) + minY;
        transform.position = new Vector2(transform.position.x, newY);

        if (HP == 30)
        {
            //currentAction = ActionPattern.Ikari3;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (currentAction == ActionPattern.Apper)
        {
            return;
        }
        var LayerName = LayerMask.LayerToName(col.gameObject.layer);
        if (LayerName == "Bullet")
        {
            HP -= 1;
            //Debug.Log("damaged");
            if (HP == 0)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene("Game Clear");
            }
        }
    }
}
