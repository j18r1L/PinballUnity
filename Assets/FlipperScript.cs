using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    

    Vector3 m_EulerAngleVelocity = new Vector3(0.0f, 1000.0f, 0.0f);
    Quaternion defaultRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

    public bool bRight = false;
    bool bPressed = false;
    bool bNeedUpdate = false;

    // Start is called before the first frame update
    void Start()
    {
        defaultRotation = transform.rotation;
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)
        if (!bRight)
        {
            m_EulerAngleVelocity = -m_EulerAngleVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        KeyCode key = KeyCode.A;
        if (bRight)
        {
            key = KeyCode.D;
        }
        

        if (Input.GetKeyDown(key))
        {
            
            bPressed = true;
            bNeedUpdate = true;
        }

        if (Input.GetKeyUp(key))
        {
            bPressed = false;
            bNeedUpdate = true;
        }
    }

    void FixedUpdate()
    {
        if (bPressed && bNeedUpdate)
        {
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
            m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);

        }
        if (!bPressed && bNeedUpdate)
        {
            transform.rotation = defaultRotation;
            //Quaternion deltaRotation = Quaternion.Euler(-m_EulerAngleVelocity * Time.fixedDeltaTime);
            //m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        }
        bNeedUpdate = false;
    }
}
