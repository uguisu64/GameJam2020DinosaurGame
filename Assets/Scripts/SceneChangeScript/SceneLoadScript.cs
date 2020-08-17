using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadScript : MonoBehaviour
{
    public void ToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ToGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
