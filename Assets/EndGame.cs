using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject startPosition;

    void OnTriggerEnter(Collider collider)
    {
        // Restart the game if endgame trigger
        if (collider.tag == "EndGame")
        {
            Instantiate(gameObject, startPosition.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
