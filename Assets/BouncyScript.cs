using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyScript : MonoBehaviour
{
    public float coef = 1000.0f;
    public float maxVelocity = 1000.0f;
    bool bNeedAddForce = false;


    void HandleEnter(Vector3 reflected, GameObject collidedGameObject)
    {
        Rigidbody rb = collidedGameObject.GetComponent<Rigidbody>();
        Vector3 addedForce = Vector3.Normalize(reflected) * coef;

        addedForce = Vector3.ClampMagnitude(addedForce, maxVelocity);
        rb.AddForce(addedForce);
        bNeedAddForce = true;
    }

    void HandleExit()
    {
        bNeedAddForce = false;
    }



    void OnCollisionEnter(Collision collision)
    {
        if (!bNeedAddForce)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 reflectedVelocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
            HandleEnter(reflectedVelocity, collision.gameObject);
        }
        
    }
    
    void OnTriggerEnter(Collider collider)
    {
        if (!bNeedAddForce)
        {
            Rigidbody rb = collider.gameObject.GetComponent<Rigidbody>();
            Vector3 reflectedVelocity = -rb.velocity * coef;
            HandleEnter(reflectedVelocity, collider.gameObject);
        }

    }

    void OnTriggerExit(Collider collider)
    {
        HandleExit();
    }
    void OnCollisionExit(Collision collision)
    {
        HandleExit();
    }

}
