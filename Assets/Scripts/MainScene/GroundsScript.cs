using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundsScript : MonoBehaviour
{
    private float differ;

    private float speed;

    private float createPos;

    public GameObject ground;
    public GameObject gameManager;

    private List<GameObject> grounds = new List<GameObject>();

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
        grounds.Add(newGround);

        if (grounds.Count > 5)
        {
            GameObject a = grounds[0];
            grounds.RemoveAt(0);
            Destroy(a);
        }

        createPos += 12.8f;
    }

    public void SpeedUp()
    {
        speed += 0.5f;
    }

    public IEnumerator MakeEnemy()
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemies[Random.Range(0, 3)]);
            enemy.transform.parent = transform;

            yield return new WaitForSeconds(Random.Range(3.5f, 6.5f));
        }
    }
}
