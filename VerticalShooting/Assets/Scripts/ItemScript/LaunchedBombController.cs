using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchedBombController : MonoBehaviour
{
    public float damage = 500;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
