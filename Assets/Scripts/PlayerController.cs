using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject explosionGo;

    private float genTime = 0.5f;
    private float del = 0;
    private bool flag = false;
    public bool isPlayerDie = false;

    void Start()
    {
        this.transform.position = new Vector3(0, -1.225f, 0);
        flag = true;
    }

    void Update()
    {
        //Input.GetAxis     -1, 0.9, 0.8,...1
        var dirx = Input.GetAxisRaw("Horizontal");
        var diry = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(dirx, diry, 0);
        //이동: 방향*속도*시간
        this.transform.Translate(dir.normalized * 1f * Time.deltaTime);

        if (del >= genTime)
            flag = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flag)
            {
                var laserGo = Instantiate(laserPrefab);
                laserGo.transform.position = this.transform.position;
                del = 0;
                flag = false;
            }
        }
        del += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var explosionController = explosionGo.GetComponent<ExplosionController>();

        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(explosionGo);
            explosionController.SetPosition(other.gameObject.transform.position);
            Destroy(gameObject);

            isPlayerDie = true;
        }
    }
}
