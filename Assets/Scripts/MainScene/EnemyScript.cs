using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
}
