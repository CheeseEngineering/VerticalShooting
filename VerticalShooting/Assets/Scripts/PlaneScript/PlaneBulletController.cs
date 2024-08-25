using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBulletController : MonoBehaviour
{
    public GameObject planeGo;
    private PlaneController planeController;
    public float bulletSpeed = 10;

    public float damage = 40;

    void Start()
    {
        planeGo = GameObject.Find("Plane");
        this.transform.position = new Vector3(planeGo.transform.position.x, planeGo.transform.position.y+0.7f, planeGo.transform.position.z);
        planeController = planeGo.GetComponent<PlaneController>();
    }
    void Update()
    {
        Move();
    }
    
    private void Move()
    {
        this.transform.Translate(new Vector3(0, 1*bulletSpeed* Time.deltaTime, 0));
        if (this.transform.position.y <= -5 || this.transform.position.x < -2.7 || this.transform.position.x > 2.7)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
