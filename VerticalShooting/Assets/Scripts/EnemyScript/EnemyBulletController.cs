using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float bulletSpeed = 1;
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
        this.transform.Translate(new Vector3(0, -1 * bulletSpeed* Time.deltaTime, 0));
        if (this.transform.position.y <= -5)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
