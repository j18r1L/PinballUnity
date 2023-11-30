using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float offset = 2.0f;
    public Vector3 angle = new Vector3(85.0f, 0.0f, 0.0f);
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        Quaternion rotation = Quaternion.Euler(angle);
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = ball.transform.position;
        pos.y += offset;
        transform.position = pos;

    }

}
