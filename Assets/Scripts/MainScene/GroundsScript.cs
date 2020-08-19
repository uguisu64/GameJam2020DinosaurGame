using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundsScript : MonoBehaviour
{
    private float differ;

    private float speed;

    private float createPos;

    public GameObject ground;
    public GameObject gameManager;

    public GameObject[] enemies;

    void Start()
    {
        differ = 0;
        speed = 3;
        createPos = 0;

        //初期床生成
        MakeNewGround(0);
        MakeNewGround(Random.Range(0, 3));
        MakeNewGround(Random.Range(0, 3));

        //敵生成開始
        StartCoroutine(MakeEnemy());
    }

    
    void Update()
    {
        gameObject.transform.position -= Vector3.right * speed * Time.deltaTime;
        differ += speed * Time.deltaTime;
        gameManager.GetComponent<GameManagerScript>().ScoreUp(speed * Time.deltaTime);

        if (differ >= 12.8f)
        {
            differ = 0;
            MakeNewGround(Random.Range(0, 3));
        }
    }

    public void MakeNewGround(int i)
    {
        GameObject newGround = Instantiate(ground);
        newGround.GetComponent<GroundScript>().SetColor(i);
        newGround.transform.parent = transform;
        newGround.transform.localPosition = new Vector3(createPos, 0, 0);

        createPos += 12.8f;
    }

    public void SpeedUp()
    {
        speed += 0.5f;
        Debug.Log(speed);
    }

    public IEnumerator MakeEnemy()
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Count())]);
            enemy.transform.parent = transform;

            yield return new WaitForSeconds(Random.Range(10.0f / speed, 15.0f / speed));
        }
    }
}
