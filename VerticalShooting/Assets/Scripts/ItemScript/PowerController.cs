using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    void Update()
    {
        Move();
    }
    private void Move()
    {
        this.transform.Translate(0, -1 * 1f * Time.deltaTime, 0);
        if (this.transform.position.y <= -5)
        {
            Object.Destroy(this.gameObject);
        }
    }
}