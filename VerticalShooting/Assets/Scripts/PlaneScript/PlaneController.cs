using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public GameObject gameDirectorGo;
    public GameObject planeGo;
    public GameObject planeBulletGo;
    public GameObject DestroyGo;
    public GameObject LaunchedBombGo;
    private PlaneBulletController planeBulletController;
    private GameDirectorController gameDirectorController;

    public GameObject enemyAGo;
    private EnemyAController enemyAController;

    private Rigidbody2D rg2D;
    private Animator animator;

    private float h;
    private float v;
    private Vector3 planeVectorNormalize;
    private int planeDirection;

    public int hp = 3;
    private int maxHp = 3;
    public int BombCount;
    public int CoinCount;
    public int PowerCount;
    public bool BombLaunched;

    void Start()
    {
        hp = 3;
        BombCount = 0;
        CoinCount = 0;
        PowerCount = 0;
        animator = planeGo.GetComponent<Animator>();
        rg2D = planeGo.GetComponent<Rigidbody2D>();
        planeBulletController = planeBulletGo.GetComponent<PlaneBulletController>();
        enemyAController = enemyAGo.GetComponent<EnemyAController>();
        gameDirectorController = gameDirectorGo.GetComponent<GameDirectorController>();
        planeBulletController.damage = 40;
    }
    void Update()
    {
        Move();

        Fire();
        
        Die();

        BombLaunch();
    }

    private void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        planeVectorNormalize = new Vector3(h, v, 0);
        planeVectorNormalize.Normalize();
        this.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.6f, 2.6f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f), 0);
        this.rg2D.velocity = new Vector3(planeVectorNormalize.x * 250f * Time.deltaTime, planeVectorNormalize.y * 250f * Time.deltaTime);
        
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
        }
    }
    
    private void BombLaunch()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (BombCount == 0)
            {
                Debug.Log("폭탄이 없습니다.");
            }
            else
            {
                BombCount--;
                LaunchedBombGo.transform.position = this.transform.position;
                Instantiate(LaunchedBombGo);
                BombLaunched = true;
            }
        }
    }

    private void Die()
    {
        if (this.hp <= 0)
        {
            this.hp = 0;
            Debug.Log("비행기가 파괴되었습니다.");
            DestroyGo.transform.position = this.transform.position;
            Instantiate(DestroyGo);
            Object.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            this.hp--;
            Debug.Log($"Plane의 남은 체력 : {this.hp}/{this.maxHp}");
            Object.Destroy(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Power(Clone)")
        {
            PowerCount++;
            planeBulletController.damage += 10;
            Object.Destroy(collision.gameObject);
        }
        else if (collision.name == "Coin(Clone)")
        {
            CoinCount++;
            gameDirectorController.Score += 50;
            Object.Destroy(collision.gameObject);
        }
        else if (collision.name == "Bomb(Clone)")
        {
            BombCount++;
            if (BombCount >= 3)
            {
                BombCount = 3;
            }
            Object.Destroy(collision.gameObject);
        }
        else if (collision.name == "Boss(Clone)" ||collision.name == "LaunchedBomb(Clone)")
        {

        }
        else
        {
            this.hp--;
            Object.Destroy(collision.gameObject);

        }

    }
}