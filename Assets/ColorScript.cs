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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.tag == "StrikerReciver")
        {
            Debug.Log("StrikerReciver");
            other.gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
        }

        if (other.tag == "StrikerGiver")
        {
            Debug.Log("StrikerGiver");
            gameObject.GetComponent<Renderer>().material.color = other.gameObject.GetComponent<Renderer>().material.color;
        }
    }
}
