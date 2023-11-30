using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{

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
        Debug.Log("OnTriggerEnter");
        if (collision.gameObject.tag == "StrikerReciver")
        {
            Debug.Log("StrikerReciver");
            collision.gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
        }

        if (collision.gameObject.tag == "StrikerGiver")
        {
            Debug.Log("StrikerGiver");
            gameObject.GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Renderer>().material.color;
        }
    }
}
