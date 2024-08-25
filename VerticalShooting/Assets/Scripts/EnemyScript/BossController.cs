using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Rigidbody2D rg2D;
    public Animator animator;

    public GameObject planeBulletGo;
    public GameObject LaunchedBombGo;
    public GameObject gameDirectorGo;
    public GameObject DestroyGo;
    public GameObject BossBullet1Go;
    public GameObject BossBullet2Go;
    public GameObject BossBullet3Go;

    private GameDirectorController gameDirectorController;
    private PlaneBulletController planeBulletController;
    private LaunchedBombController launchedBombController;

    public float hp = 10000;
    private float maxHp = 10000;
    private float hitTimer;
    private bool isHit;
    public bool isDead;
    public float BossScore = 1000;

    private float fireTimer;

    void Start()
    {
        hp = 1000;
        rg2D = this.GetComponent<Rigidbody2D>();
        gameDirectorGo = GameObject.Find("GameDirector");
        planeBulletController = planeBulletGo.GetComponent<PlaneBulletController>();
        gameDirectorController = gameDirectorGo.GetComponent<GameDirectorController>();
        launchedBombController = LaunchedBombGo.GetComponent<LaunchedBombController>();
    }
    void Update()
    {
        Move();

        Hit();

        Fire();

        Dead();
    }
    private void Move()
    {
        if (this.transform.position.y >= 3.5)
        {
            rg2D.velocity = new Vector3(0, -1 * 10f * Time.deltaTime, 0);
        }
        else
        {
            rg2D.velocity = new Vector3(0, 0, 0);

        }

    }
    private void Fire()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > 5)
        {
            Instantiate(BossBullet1Go);
            fireTimer = 0;
        }
    }
    private void Hit()
    {
        if (isHit)
        {
            hitTimer += Time.deltaTime;
            if (hitTimer >= 1)
            {
                animator.SetInteger("isHit", 0);
                this.isHit = false;
                hitTimer = 0;
            }

        }

    }
    private void Dead()
    {
        if (this.hp <= 0)
        {
            this.hp = 0;
            this.isDead = true;
            DestroyGo.transform.position = this.transform.position;
            Instantiate(DestroyGo);
            gameDirectorController.Score += this.BossScore;
            Object.Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PlaneBullet(Clone)")
        {
            this.hp -= planeBulletController.damage;
            animator.SetInteger("isHit", 1);
            Debug.Log($"EnemyA의 현재 체력 : {this.hp}/{this.maxHp}");
            Object.Destroy(collision.gameObject);
            this.isHit = true;
        }
        else if (collision.name == "LaunchedBomb(Clone)")
        {
            this.hp -= launchedBombController.damage;
            Debug.Log($"EnemyA의 현재 체력 : {this.hp}/{this.maxHp}");
            animator.SetInteger("isHit", 1);
            this.isHit = true;
        }
    }
}   
