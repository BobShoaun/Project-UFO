using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;

    private int score = 0;
    public int Score {
        get { return score; }
        set {
            score = value;
            scoreText.text = "Score: " + score;
        }
    }

    public static Player Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Score = 0;
    }

}
