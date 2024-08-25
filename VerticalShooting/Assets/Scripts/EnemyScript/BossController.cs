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
    private EnemyBullet1Controller BossBullet1GoBulletController;
    private EnemyBullet2Controller BossBullet2GoBulletController;
    private EnemyBullet3Controller BossBullet3GoBulletController;

    public float hp = 10000;
    private float maxHp = 10000;
    private float hitTimer;
    private bool isHit;
    public bool isDead;
    public float BossScore = 1000;

    private float fireTimer;
    private float fireCount;
    private float patternCount;

    void Start()
    {
        hp = 1000;
        rg2D = this.GetComponent<Rigidbody2D>();
        gameDirectorGo = GameObject.Find("GameDirector");
        planeBulletController = planeBulletGo.GetComponent<PlaneBulletController>();
        gameDirectorController = gameDirectorGo.GetComponent<GameDirectorController>();
        launchedBombController = LaunchedBombGo.GetComponent<LaunchedBombController>();

        BossBullet1GoBulletController = BossBullet1Go.GetComponent<EnemyBullet1Controller>();
        BossBullet2GoBulletController = BossBullet2Go.GetComponent<EnemyBullet2Controller>();
        BossBullet3GoBulletController = BossBullet3Go.GetComponent<EnemyBullet3Controller>();
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
        if (fireTimer > 5&& patternCount <2)
        {
            BossBullet1Go.transform.position = new Vector3(-0.83f, this.transform.position.y - 0.4f, this.transform.position.z);
            Instantiate(BossBullet1Go);

            BossBullet1Go.transform.position = new Vector3(-0.6f, this.transform.position.y - 0.4f, this.transform.position.z);
            Instantiate(BossBullet1Go);

            BossBullet1Go.transform.position = new Vector3(0.6f, this.transform.position.y - 0.4f, this.transform.position.z);
            Instantiate(BossBullet1Go);

            BossBullet1Go.transform.position = new Vector3(0.83f, this.transform.position.y - 0.4f, this.transform.position.z);
            Instantiate(BossBullet1Go);

            fireTimer = 0; 
            patternCount++;
        }
        else if(fireTimer > 5 && patternCount < 4 && patternCount >=2)
        {
            if (patternCount == 2)
            {
                BossBullet2Go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, this.transform.position.z);
                BossBullet2Go.transform.Rotate(new Vector3(0, 0, 15f));
                Instantiate(BossBullet2Go);

                BossBullet2Go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, this.transform.position.z);
                BossBullet2Go.transform.Rotate(new Vector3(0, 0, -5f));
                Instantiate(BossBullet2Go);

                BossBullet2Go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, this.transform.position.z);
                BossBullet2Go.transform.Rotate(new Vector3(0, 0, -5f));
                Instantiate(BossBullet2Go);

                BossBullet2Go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, this.transform.position.z);
                BossBullet2Go.transform.Rotate(new Vector3(0, 0, -5f));
                Instantiate(BossBullet2Go);

                BossBullet2Go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, this.transform.position.z);
                BossBullet2Go.transform.Rotate(new Vector3(0, 0, -5f));
                Instantiate(BossBullet2Go);

                BossBullet2Go.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (patternCount == 3)
            {
                BossBullet2Go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, this.transform.position.z);
                BossBullet2Go.transform.Rotate(new Vector3(0, 0, -15f));
                Instantiate(BossBullet2Go);

                BossBullet2Go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, this.transform.position.z);
                BossBullet2Go.transform.Rotate(new Vector3(0, 0, 5f));
                Instantiate(BossBullet2Go);

                BossBullet2Go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, this.transform.position.z);
                BossBullet2Go.transform.Rotate(new Vector3(0, 0, 5f));
                Instantiate(BossBullet2Go);

                BossBullet2Go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, this.transform.position.z);
                BossBullet2Go.transform.Rotate(new Vector3(0, 0, 5f));
                Instantiate(BossBullet2Go);

                BossBullet2Go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, this.transform.position.z);
                BossBullet2Go.transform.Rotate(new Vector3(0, 0, 5f));
                Instantiate(BossBullet2Go);

                BossBullet2Go.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            fireTimer = 0;
            patternCount++;
        }
        else if (patternCount >= 4)
        {
            BossBullet3Go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, this.transform.position.z);
            if (fireTimer >= 5)
            {
                patternCount++;
                fireTimer = 0;
            }
            if (patternCount == 5)
            {
                if (fireTimer >= 0.5)
                {
                    if (fireCount < 7)
                    {
                        BossBullet3Go.transform.Rotate(new Vector3(0, 0, 20f));
                        Instantiate(BossBullet3Go);
                        fireCount++;
                    }
                    else if (fireCount >= 7)
                    {
                        BossBullet3Go.transform.Rotate(new Vector3(0, 0, -20f));
                        Instantiate(BossBullet3Go);
                        fireCount++;
                    }
                    else if (fireCount >= 12)
                    {
                        BossBullet3Go.transform.Rotate(new Vector3(0, 0, -20f));
                        Instantiate(BossBullet3Go);
                        fireCount++;
                    }
                    else if (fireCount >= 19)
                    {
                        BossBullet3Go.transform.Rotate(new Vector3(0, 0, 20f));
                        Instantiate(BossBullet3Go);
                        fireCount++;
                    }

                    if (fireCount >= 19)
                    {
                        patternCount = 0;
                        BossBullet3Go.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    }
                    fireTimer = 0;
                }
            }
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
            gameDirectorController.BossDead = true;
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
