using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBall : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        //transform.position += Vector3.down * Time.deltaTime * 2;

        if (transform.position.y < -5.5f)
        {
            transform.position = new Vector3(0, 8, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
