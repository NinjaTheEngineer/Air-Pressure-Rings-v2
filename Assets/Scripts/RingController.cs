using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    private float force = 0.5f;
    [SerializeField]
    private Vector3 dir;

    public GameObject rayCastObjectToShootFrom;
    public GameObject rayCastObjectToShootFromRight;
    private Vector3 rayOriginObjectPosition;
    private Vector3 rayOriginObjectPositionRight;
    private LineRenderer laserLine;
    private Rigidbody myRigidbody;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Bubbles_Left"))
        {
            CastRayLeft();
            if(force < 2.5f)
                force += 0.005f;
        } 
        else if (other.gameObject.CompareTag("Bubbles_Right"))
        {
            CastRayRight();
            if(force < 2.5f)
                force += 0.005f;
        }
    }   

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bubbles_Left"))
        {
            CastRayLeft();
            force = 0.5f;
        }
        else if (other.gameObject.CompareTag("Bubbles_Right"))
        {
            CastRayRight();
            force = 0.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bubbles_Left"))
        {
            force = 0.5f;
        }
        else if (other.gameObject.CompareTag("Bubbles_Right"))
        {
            force = 0.5f;
        }
    }

    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        myRigidbody = GetComponent<Rigidbody>();
        rayOriginObjectPosition = rayCastObjectToShootFrom.transform.position;
        rayOriginObjectPositionRight = rayCastObjectToShootFromRight.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CastRayLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CastRayRight();
        }
    }
    public void CastRayLeft()
    {
        //laserLine.SetPosition(0, transform.position);
        Vector3 dir = (rayOriginObjectPosition - transform.position).normalized;
        Debug.DrawLine(transform.position, transform.position + dir * 100, Color.red, Mathf.Infinity);
        
        if (Physics.Raycast(transform.position, dir))
        {
            //laserLine.SetPosition(1, raycastHit.point);

            myRigidbody.AddForce(-dir * force);
        }

    }
    public void CastRayRight()
    {
        //laserLine.SetPosition(0, transform.position);
        Vector3 dir = (rayOriginObjectPositionRight - transform.position).normalized;
        Debug.DrawLine(transform.position, transform.position + dir * 100, Color.red, Mathf.Infinity);
        
        if (Physics.Raycast(transform.position, dir))
        {
            //laserLine.SetPosition(1, raycastHit.point);

            myRigidbody.AddForce(-dir * force);
        }

    }
}
