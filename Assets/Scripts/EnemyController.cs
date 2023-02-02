using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public GameObject explosionGo;

    void Start()
    {

    }

    void Update()
    {
        this.transform.Translate(-transform.up * speed * Time.deltaTime);

        if (this.transform.position.y < -1.75f)
        {
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var explosionController = explosionGo.GetComponent<ExplosionController>();
        if (other.gameObject.tag == "Laser")
        {
            Instantiate(explosionGo);
            explosionController.SetPosition(this.transform.position);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            Instantiate(explosionGo);
            explosionController.SetPosition(this.transform.position);

            Destroy(gameObject);
        }
    }
}
