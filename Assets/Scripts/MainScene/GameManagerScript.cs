using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    public static float score;

    public GameObject grounds;
    public Text scoreText;
    
    void Start()
    {
        score = 0;

        StartCoroutine(SpeedUp());
    }

    public void GameOver()
    {
        gameObject.GetComponent<SceneLoadScript>().ToGameOverScene();
    }

    public IEnumerator SpeedUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            grounds.GetComponent<GroundsScript>().SpeedUp();
        }
    }

    public void ScoreUp(float i)
    {
        score += i;
        scoreText.text = score.ToString("F0");
    }
}
