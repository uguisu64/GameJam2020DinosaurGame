using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManage : MonoBehaviour
{

    public Text scoreText;

    void Start()
    {
        scoreText.text = GameManagerScript.score.ToString("F0");
    }

}
