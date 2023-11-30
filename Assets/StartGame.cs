using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class StartGame : MonoBehaviour
{
    public float powerCoef = 100.0f;
    public float speedCoef = 1.0f;
    public float maxPower = 1000.0f;

    float addedForce = 0.0f;


    bool canBePushed = false;
    bool spaceDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canBePushed)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spaceDown = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                float clampedForce = Mathf.Max(maxPower, addedForce * powerCoef);
                Vector3 forceVector = new Vector3(0.0f, 0.0f, 1.0f) * clampedForce;
                gameObject.GetComponent<Rigidbody>().AddForce(forceVector);
                addedForce = 0.0f;
                spaceDown = false;
            }

            if (spaceDown)
            {
                addedForce += speedCoef;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // Restart the game if endgame trigger
        if (collider.tag == "StartGame")
        {
            canBePushed = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        // Restart the game if endgame trigger
        if (collider.tag == "StartGame")
        {
            canBePushed = false;
        }
    }
}