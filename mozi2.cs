using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mozi2 : MonoBehaviour
{
    public TextMeshProUGUI tmpro;
    // Start is called before the first frame update
    void Start()
    {
        tmpro.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.SetActive(true);
            tmpro.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            gameObject.SetActive(false);
            tmpro.gameObject.SetActive(false);
        }
    }
}