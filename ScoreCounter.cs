using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    int score = 0;
    Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        this.textComponent = GameObject.Find("Text2").GetComponent<Text>();
        this.textComponent.text = "Score " + score.ToString();
    }

    public void AddScoreTuibe()
    {
        this.score += 100;
        this.textComponent.text = "Score " + score.ToString();
    }
}
