﻿using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;
   
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = BulletController.score.ToString();
    }
}
