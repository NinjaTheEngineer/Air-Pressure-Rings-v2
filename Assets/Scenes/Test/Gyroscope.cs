using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    float coolDown = 0.33f;
    float elapsedTime = 0f;
    bool gyroEnabled = false;

    Vector3 invertZ;

    public float forceToMultiply = 9f;
    
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            gyroEnabled = true;
            invertZ = new Vector3(1, 1, -1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= coolDown && gyroEnabled)
        {
            elapsedTime = 0f;
            ChangeGravity();
        }
    }
    private void ChangeGravity()
    {
        Vector3 gyroPos = Input.gyro.gravity;
        if (gyroPos.y < 0.0f)
        {
            Vector3 newGrav = gyroPos * forceToMultiply;
            Physics.gravity = Vector3.Scale(newGrav, invertZ);
            //Debug.Log("New Gravity Vector = " + newGrav);
        }
        else
        {
            //Debug.Log("Tracked Gyro Vector = " + gyroPos);
        }
    }

    private Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
