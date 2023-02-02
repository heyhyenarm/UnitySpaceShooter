using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject playerGo;
    private bool isPlayerDie = false;
    private float delPlayer = 0;
    private float genPlayer = 2f;

    void Start()
    {
        var playerController = playerGo.GetComponent<PlayerController>();
        this.isPlayerDie = playerController.isPlayerDie;
    }

    void Update()
    {
        if (isPlayerDie)
        {
            delPlayer += Time.deltaTime;
            if (delPlayer >= genPlayer)
            {
                Instantiate(playerGo.gameObject);
                //if (playerGo.transform.position.y < -1.225f)
                //    playerGo.transform.Translate(playerGo.transform.up * 1f * Time.deltaTime);
                isPlayerDie = false;
                delPlayer = 0;
            }
        }
    }
}
