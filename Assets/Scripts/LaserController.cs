using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(new Vector3(0, 1, 0) *speed* 1f);
        if (this.transform.position.y >= 1.6)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
