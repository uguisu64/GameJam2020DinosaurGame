using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private int color;

    public void SetColor(int c)
    {
        color = c;
        switch (c)
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;

            case 1:
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                break;

            case 2:
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
        }
    }

    public int GetColor()
    {
        return color;
    }
}
