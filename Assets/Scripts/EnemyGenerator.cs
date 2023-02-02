using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemys;
    private GameObject enemy;
    private float span = 1f;
    private float del = 0;
    private bool flag = false;
    private float speed;


    void Start()
    {
        SetParameter(span, 0.4f);
    }

    void Update()
    {
        if(flag == false)
        {
            del += Time.deltaTime;
        }
        int randEnemy = Random.Range(1, 11);
        float randPos = Random.Range(-0.65f, 0.65f);
        Vector3 pos = new Vector3(randPos, 1.7f, 0);

        if (randEnemy <= 2) enemy = enemys[0];
        else if (randEnemy <=4) enemy = enemys[1];
        else enemy = enemys[2];

        if (del >= span)
        {
            del = 0;
            Instantiate(enemy);
            enemy.transform.position = pos;
        }
    }

    private void SetParameter(float span, float speed)
    {
        this.span = span;
        this.speed = speed;
    }
}
