using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject startPosition;
    public GameObject cameraObject;

    void OnTriggerEnter(Collider collider)
    {
        // Restart the game if endgame trigger
        if (collider.tag == "EndGame")
        {
            GameObject newball = Instantiate(gameObject, startPosition.transform.position, Quaternion.identity);
            cameraObject.GetComponent<CameraFollow>().ball = newball;
            Destroy(gameObject);
        }
    }
}
