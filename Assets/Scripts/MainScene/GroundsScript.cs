using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundsScript : MonoBehaviour
{
    private float differ;

    private float speed;

    private float createPos;

    public GameObject ground;

    private List<GameObject> grounds = new List<GameObject>();
    void Start()
    {
        differ = 0;
        speed = 2;
        createPos = 0;

        for(int i = 0; i < 3; i++)
        {
            MakeNewGround();
        }
    }

    
    void Update()
    {
        gameObject.transform.position -= Vector3.right * speed * Time.deltaTime;
        differ += speed * Time.deltaTime;

        if (differ >= 12)
        {
            differ = 0;
            MakeNewGround();
        }
    }

    public void MakeNewGround()
    {
        GameObject newGround = Instantiate(ground);
        newGround.GetComponent<GroundScript>().SetColor(Random.Range(0, 3));
        newGround.transform.parent = transform;
        newGround.transform.localPosition = new Vector3(createPos, 0, 0);
        grounds.Add(newGround);

        if (grounds.Count > 4)
        {
            GameObject a = grounds[0];
            grounds.RemoveAt(0);
            Destroy(a);
        }

        createPos += 12.8f;
    }
}
