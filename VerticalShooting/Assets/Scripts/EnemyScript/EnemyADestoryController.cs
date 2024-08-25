using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyADestoryController : MonoBehaviour
{
    private float timer;
    void Start()
    {
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
