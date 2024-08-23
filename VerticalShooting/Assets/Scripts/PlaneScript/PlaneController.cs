using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public GameObject planeGo;
    public GameObject planeBulletGo;
    private PlaneBulletController planeBulletController;

    private Rigidbody2D rg2D;
    private Animator animator;

    private float h;
    private float v;
    private Vector3 planeVectorNormalize;
    private int planeDirection;

    void Start()
    {
        animator = planeGo.GetComponent<Animator>();
        rg2D = planeGo.GetComponent<Rigidbody2D>();
        planeBulletController = planeBulletGo.GetComponent<PlaneBulletController>();
    }
    void Update()
    {
        Move();

        Fire();
    }

    private void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        planeVectorNormalize = new Vector3(h, v, 0);
        planeVectorNormalize.Normalize();
        this.rg2D.velocity = new Vector3(planeVectorNormalize.x * 150f * Time.deltaTime, planeVectorNormalize.y * 150f * Time.deltaTime);
        if (h > 0)
        {
            animator.SetInteger("State", 2);
        }
        else if (h < 0)
        {
            animator.SetInteger("State", 1);

        }
        else
        {
            animator.SetInteger("State", 0);
        }
    }

    private void Fire()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(planeBulletGo);
            Debug.Log("Shoot");
        }
    }
}