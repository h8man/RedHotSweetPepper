using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float maxSpeed;
    private Vector2 velocity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 0, transform.position.z) + (Vector3)Vector2.SmoothDamp(transform.position, target.position,ref velocity, speed ,maxSpeed, Time.deltaTime);
    }
}
