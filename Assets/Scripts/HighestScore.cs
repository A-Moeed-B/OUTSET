using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighestScore : MonoBehaviour
{
    public static int highestScore;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        highestScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Score:" + PlayerPrefs.GetInt("SCORE"));
        if (highestScore < PlayerPrefs.GetInt("SCORE"))
            highestScore = PlayerPrefs.GetInt("SCORE");
        scoreText.SetText("Highest Score: " + "\n\n" + highestScore);
    }
}
