using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mozi : MonoBehaviour
{
    public TextMeshProUGUI tmpro;
    // Start is called before the first frame update
    void Start()
    {
        tmpro.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.SetActive(false);
            tmpro.gameObject.SetActive(false);
        }
    }
}
