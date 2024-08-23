using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAController : MonoBehaviour
{
    public GameObject planeBulletGo;
    private PlaneBulletController planeBulletController;
    public Animator animator;

    private float hp = 100;
    private float maxHp = 100;

    void Start()
    {
        planeBulletController = planeBulletGo.GetComponent<PlaneBulletController>();
    }
    void Update()
    {
        Move();

        Dead();

    }
    private void Move()
    {
        animator.SetInteger("isHit", 0);
    }
    private void Dead()
    {
        if (this.hp <= 0)
        {
            this.hp = 0;
            Debug.Log("Enemy가 파괴되었습니다.");
            Object.Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.hp -= planeBulletController.damage;
        Debug.Log($"EnemyA의 현재 체력 : {this.hp}/{this.maxHp}");
        animator.SetInteger("isHit", 1);
        Object.Destroy(collision.gameObject);
    }
}
