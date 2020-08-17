using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public static float score;
    
    void Start()
    {
        score = 0;
    }

    public void GameOver()
    {
        gameObject.GetComponent<SceneLoadScript>().ToGameOverScene();
    }
}
