using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyScript : MonoBehaviour
{
    public float coef = 1000.0f;
    bool bNeedAddForce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!bNeedAddForce)
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            Vector3 addedForce = -rb.velocity * coef;
            rb.AddForce(addedForce);
            bNeedAddForce = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        bNeedAddForce = false;
    }
}
