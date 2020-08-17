using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigit2d;

    private bool canJump;

    private int color;

    private float differTime;

    public GameObject gameManager;

    void Start()
    {
        rigit2d = gameObject.GetComponent<Rigidbody2D>();
        canJump = false;
        differTime = 0;

        //色の初期化
        color = 2;
        PlayerColorChange();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (canJump)
            {
                rigit2d.AddForce(Vector3.up * 8, ForceMode2D.Impulse);
                canJump = false;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!canJump)
            {
                rigit2d.AddForce(Vector3.down);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerColorChange();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GroundScript gs = collision.gameObject.GetComponent<GroundScript>();

            if (color == gs.GetColor())
            {
                differTime = 0;
            }
            else
            {
                differTime += Time.deltaTime;

                //GameOver
                if (differTime >= 0.2f)
                {
                    gameManager.GetComponent<GameManagerScript>().GameOver();
                }
            }
        }
    }

    public void PlayerColorChange()
    {
        switch (color)
        {
            case 0:
                color = 1;
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                break;

            case 1:
                color = 2;
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                break;

            case 2:
                color = 0;
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;
        }
    }
}
