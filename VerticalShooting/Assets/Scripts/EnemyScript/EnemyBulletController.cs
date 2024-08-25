using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public GameObject enemyAGo;
    void Start()
    {
        this.transform.position = new Vector3(enemyAGo.transform.position.x, enemyAGo.transform.position.y - 0.4f, enemyAGo.transform.position.z);
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        this.transform.Translate(new Vector3(0, -1 * 1f * Time.deltaTime, 0));
        if (this.transform.position.y <= -5)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
