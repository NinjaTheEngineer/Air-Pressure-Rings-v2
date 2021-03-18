using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour, IPooledObject
{
#region Variables

    public float Speed;
    public float AngularSpeed;

    protected new Rigidbody rigidbody;

    public float gravityMultiplier = 1;
    public float floatMultiplier = 1;
    public float gravityDrag = 1;
    public float floatDrag = 1;

    public float maxElevation = 40f;

    public float timeAlive;

    private Vector3 Gravity;


    #endregion

    #region Main Methods
    public void OnObjectSpawn()
    {
        Gravity = Vector3.up * 10;
        timeAlive = UnityEngine.Random.Range(1f, 5f);
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(Explode());
    }

    void Update()
    {
        if(transform.position.y > 45f)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        //For Physics
        Speed = rigidbody.velocity.magnitude;
        AngularSpeed = rigidbody.angularVelocity.magnitude;

        ApplyFloatingForce();
    }
    #endregion


    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(timeAlive);
        gameObject.SetActive(false);
    }
    public void ApplyFloatingForce()
    {
        if(rigidbody.position.y > maxElevation)
        {
            rigidbody.AddForce(Gravity * gravityMultiplier);
            rigidbody.drag = gravityDrag;
        }
        else
        {
            rigidbody.AddForce(-1 * Vector3.down * 10 * floatMultiplier);
            rigidbody.drag = floatDrag;

        }
    }
}
