using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAController : MonoBehaviour
{
    public GameObject planeBulletGo;
    public GameObject LaunchedBombGo;
    public GameObject gameDirectorGo;
    public GameObject DestroyGo;
    public GameObject enemyBulletGo;

    public GameObject BombGo;
    public GameObject CoinGo;
    public GameObject PowerGo;

    private GameDirectorController gameDirectorController;
    private PlaneBulletController planeBulletController;
    private LaunchedBombController launchedBombController;

    public Animator animator;
    private Rigidbody2D rg2D;

    private List<GameObject> ItemSpawner;

    private float timer;
    private float fireTimer;
    private float hitTimer;
    public float hp = 100;
    private float maxHp = 100;
    private bool isHit;
    public bool isDead;
    public float enemyAScore = 10;
    public int fireJam;

    private int h=0;
    private int v=0;

    void Start()
    {
        hp = 100;
        ItemSpawner = new List<GameObject>();
        ItemSpawner.Add(BombGo);
        ItemSpawner.Add(CoinGo);
        ItemSpawner.Add(PowerGo);
        gameDirectorGo = GameObject.Find("GameDirector");
        rg2D = this.GetComponent<Rigidbody2D>();
        planeBulletController = planeBulletGo.GetComponent<PlaneBulletController>();
        gameDirectorController = gameDirectorGo.GetComponent<GameDirectorController>();
        launchedBombController = LaunchedBombGo.GetComponent<LaunchedBombController>();
      
    }
    void Update()
    {

        Fire();

        Hit();

        Dead();
    }
    
    private void Fire()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > 1)
        {
            fireJam = Random.Range(0, 101);
            if (fireJam > 70)
            {
                enemyBulletGo.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.4f, this.transform.position.z);
                Instantiate(enemyBulletGo);
            }
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
            ItemSpawn();
            Instantiate(DestroyGo);
            gameDirectorController.Score += this.enemyAScore;
            Object.Destroy(this.gameObject);
        }
    }
    private void ItemSpawn()
    {
        int item = Random.Range(0, 3);
        int prohability = Random.Range(0, 101);
        if (prohability <= 20)
        {
            ItemSpawner[item].transform.position = this.transform.position;
            Instantiate(ItemSpawner[item]);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "PlaneBullet(Clone)")
        {
            this.hp -= planeBulletController.damage;
            animator.SetInteger("isHit", 1);
            Debug.Log($"EnemyA의 현재 체력 : {this.hp}/{this.maxHp}");
            Object.Destroy(collision.gameObject);
            this.isHit = true;
        }
        else if(collision.name == "LaunchedBomb(Clone)")
        {
            this.hp -= launchedBombController.damage;
            Debug.Log($"EnemyA의 현재 체력 : {this.hp}/{this.maxHp}");
            animator.SetInteger("isHit", 1);
            this.isHit = true;
        }
        else if (collision.name == "Boss(Clone)")
        {
            Object.Destroy(this.gameObject);
        }
    }
}
