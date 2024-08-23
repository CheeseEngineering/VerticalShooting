using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAController : MonoBehaviour
{
    public GameObject planeBulletGo;
    private PlaneBulletController planeBulletController;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rg2D;

    private float timer;
    public float hp = 100;
    private float maxHp = 100;
    private bool isHit;
    private bool isDead;

    void Start()
    {
        rg2D = this.GetComponent<Rigidbody2D>();
        planeBulletController = planeBulletGo.GetComponent<PlaneBulletController>();
    }
    void Update()
    {
        Move();

        Timer();

        Dead();
    }
    private void Move()
    {
        //rg2D.velocity = new Vector2()
    }
    private void Timer()
    {
        if (isHit)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5)
            {
                animator.SetInteger("isHit", 0);
                this.isHit = false;
                timer = 0;
            }

        }
        if (isDead)
        {
            timer += Time.deltaTime;
        }

    }
    private void Dead()
    {
        if (this.hp <= 0)
        {
            this.hp = 0;
            animator.SetInteger("isHit", 2);
            this.isDead = true;
            if (timer >= 0.5)
            {
                Debug.Log("Enemy가 파괴되었습니다.");
                Object.Destroy(this.gameObject);
                timer = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.hp -= planeBulletController.damage;
        Debug.Log($"EnemyA의 현재 체력 : {this.hp}/{this.maxHp}");
        animator.SetInteger("isHit", 1);
        Object.Destroy(collision.gameObject);
        this.isHit = true;
    }
}
