using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private float explosionTime = 0.333f;
    float del = 0;

    void Start()
    {

    }

    void Update()
    {
        del += Time.deltaTime;

        if (del >= explosionTime)
        {
            Destroy(this.gameObject);
            del = 0;
        }
    }
    public void SetPosition(Vector3 targetPos)
    {
        this.transform.position = targetPos;
    }
}
