using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleController : MonoBehaviour
{
    public GameObject gameDirectorGo;
    public GameDirectorController gameDirectorGoController;
    public bool NeedInstantiate;
    void Start()
    {
        gameDirectorGo = GameObject.Find("GameDirector");
        gameDirectorGoController = gameDirectorGo.GetComponent<GameDirectorController>();
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        this.transform.Translate(0, -1 * 2f * Time.deltaTime, 0);
        if (this.transform.position.y <= -11.5f)
        {
            gameDirectorGoController.middleGoNeedInstantiate = true;
            Object.Destroy(this.gameObject);

        }
    }
}
