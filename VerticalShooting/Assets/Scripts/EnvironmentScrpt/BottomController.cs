using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomController : MonoBehaviour
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
        this.transform.Translate(0, -1 * 1f * Time.deltaTime, 0);
        if (this.transform.position.y <= -11.5f)
        {
            gameDirectorGoController.bottomGoNeedInstantiate = true;
            Object.Destroy(this.gameObject);

        }
    }
}
