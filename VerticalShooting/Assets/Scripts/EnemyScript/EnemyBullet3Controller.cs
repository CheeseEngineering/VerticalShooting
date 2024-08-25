using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet3Controller : MonoBehaviour
{
    public float bulletSpeed = 10f;
    void Start()
    {
        bulletSpeed = 1f;
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        this.transform.Translate(new Vector3(0, -1 * bulletSpeed * Time.deltaTime, 0));
        if (this.transform.position.y <= -5 || this.transform.position.x <-2.7 || this.transform.position.x > 2.7)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
