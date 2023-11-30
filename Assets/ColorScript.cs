using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{

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
