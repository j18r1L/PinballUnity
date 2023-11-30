using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyScript : MonoBehaviour
{
    public float coef = 1000.0f;
    public float maxVelocity = 1000.0f;
    bool bNeedAddForceC = false;
    bool bNeedAddForce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!bNeedAddForceC && (collision.gameObject.tag == "StrikerReciver" || collision.gameObject.tag == "StrikerGiver"))
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            Vector3 reflectedVelocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
            Vector3 addedForce = Vector3.Normalize(reflectedVelocity) * coef;

            Vector3 oldAddedForce = -rb.velocity * coef;

            addedForce = Vector3.ClampMagnitude(addedForce, maxVelocity);
            rb.AddForce(addedForce);
            bNeedAddForceC = true;
        }
        
    }

    void OnCollisionExit(Collision collision)
    {
        bNeedAddForceC = false;
    }
    /*
    void OnTriggerEnter(Collider collider)
    {
        if (!bNeedAddForce && (collider.gameObject.tag == "StrikerReciver" || collider.gameObject.tag == "StrikerGiver"))
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            Vector3 oldAddedForce = -rb.velocity * coef;
            oldAddedForce = Vector3.ClampMagnitude(oldAddedForce, maxVelocity);
            Debug.Log("oldAddedForce: " + oldAddedForce.ToString());
            rb.AddForce(oldAddedForce);
            bNeedAddForce = true;
        }

    }

    void OnTriggerExit(Collider collider)
    {
        bNeedAddForce = false;
    }
    */
}
