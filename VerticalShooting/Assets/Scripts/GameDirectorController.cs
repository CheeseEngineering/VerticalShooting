using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameDirectorController : MonoBehaviour
{
    public GameObject planeGo;
    public GameObject enemyAGo;
    public GameObject enemyADeadGo;

    public GameObject Bomb1Go;
    public GameObject Bomb2Go;
    public GameObject Bomb3Go;

    public GameObject Life1Go;
    public GameObject Life2Go;
    public GameObject Life3Go;

    public GameObject topGo;
    public GameObject middleGo;
    public GameObject bottomGo;

    public GameObject textGo;
    public Text textCompo;
    public float Score;

    public GameObject bossGo;

    private EnemyAController enemyAController;
    private PlaneController planeController;
    private TopController topGoController;
    private MiddleController middleGoController;
    private BottomController bottomGoController;
    public BossController bossGoController;

    private float timer;
    private float BossTimer;

    private List<GameObject> BombBay;
    private List<GameObject> LifeBay;
    private bool setTimer;
    private bool BombLaunched;

    public bool topGoNeedInstantiate;
    public bool middleGoNeedInstantiate;
    public bool bottomGoNeedInstantiate;
    private bool IsBossExist=false;
    public bool BossDead;

    private int PosX;
    private int PosY;
    private float enemyAPosX;
    private float enemyAPosY;
    private int planeHp;
    void Start()
    {
        BombBay = new List<GameObject>();
        BombBay.Add(Bomb1Go);
        BombBay.Add(Bomb2Go);
        BombBay.Add(Bomb3Go);
        LifeBay = new List<GameObject>();
        LifeBay.Add(Life1Go);
        LifeBay.Add(Life2Go);
        LifeBay.Add(Life3Go);

        topGo.transform.position = new Vector3(0, 11.5f, 0);
        middleGo.transform.position = new Vector3(0, 11.5f, 0);
        bottomGo.transform.position = new Vector3(0, 11.5f, 0);

        topGoController = topGo.GetComponent<TopController>();
        middleGoController = middleGo.GetComponent<MiddleController>();
        bottomGoController = bottomGo.GetComponent<BottomController>();

        enemyAController = enemyAGo.GetComponent<EnemyAController>();
        planeController = planeGo.GetComponent<PlaneController>();
        bossGoController = bossGo.GetComponent<BossController>();
    }

    // Update is called once per frame
    void Update()
    {
        BackGroundInstantiate();

        EnemyASpawner();

        Scoring();

        PlaneBombDirecting();

        BossSpawner();

        LifeCounting();
    }

    private void PlaneBombDirecting()
    {
        this.BombLaunched = planeController.BombLaunched;
        int Bombnumber = planeController.BombCount;
        if (Bombnumber > 0)
        {
            BombBay[Bombnumber-1].SetActive(true);

        }
        if (BombLaunched)
        {
            BombBay[Bombnumber].SetActive(false);
        }
    }
    private void LifeCounting()
    {
        planeHp = planeController.hp;
        if (planeController.hp < 3)
        {
            LifeBay[planeHp].SetActive(false);
        }
    }
    private void BackGroundInstantiate()
    {
        if (topGoNeedInstantiate == true)
        {
            Instantiate(topGo);
            Debug.Log("积己");
            topGoNeedInstantiate = false;
        }
        if (middleGoNeedInstantiate == true)
        {
            Instantiate(middleGo);
            Debug.Log("积己");
            middleGoNeedInstantiate = false;
        }
        if (bottomGoNeedInstantiate == true)
        {
            Instantiate(bottomGo);
            Debug.Log("积己");
            bottomGoNeedInstantiate = false;
        }
    }
    private void Scoring()
    {
        textCompo = textGo.GetComponent<Text>();
        textCompo.text = $"Score : {this.Score:0}";
    }

    private void EnemyASpawner()
    {
        timer += Time.deltaTime;
        if (timer >= 2.5 && !IsBossExist)
        {
            PosX = Random.Range(-3, 4);
            enemyAPosX = PosX / 1;
            PosY = Random.Range(-1, 5);
            enemyAPosY = PosY / 1;
            enemyAPosX = Mathf.Clamp(enemyAPosX, -2.5f, 2.5f);
            enemyAPosX = Mathf.Clamp(enemyAPosX, -4.5f, 4.5f);
            enemyAGo.transform.position = new Vector3 (enemyAPosX,enemyAPosY, 0);
            Instantiate(enemyAGo);
            timer = 0;
        }
        else if(timer >= 4 && IsBossExist)
        {
            PosX = Random.Range(-3, 3);
            enemyAPosX = PosX / 1;
            PosY = Random.Range(-1, 5);
            enemyAPosY = PosY / 1;
            enemyAPosX = Mathf.Clamp(enemyAPosX, -2.5f, 2.5f);
            enemyAPosX = Mathf.Clamp(enemyAPosX, -4.5f, 4.5f);
            enemyAGo.transform.position = new Vector3(enemyAPosX, enemyAPosY, 0);
            Instantiate(enemyAGo);
            timer = 0;
        }

    }
    private void BossSpawner()
    {
        if (!IsBossExist)
        {
            BossTimer += Time.deltaTime;
        }

        if(BossTimer>30&& !IsBossExist)
        {
            IsBossExist = true;
            bossGo.transform.position = new Vector3(0, 6, 0);
            Instantiate(bossGo);
            Debug.Log("焊胶 积己");
        }
        if (BossDead)
        {
            Debug.Log("焊胶 府哩 矫累");
            bossGoController.isDead = false;
            BossDead = false;
            IsBossExist = false;
            BossTimer = 0;
        }
    }
}
