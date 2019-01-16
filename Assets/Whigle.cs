using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whigle : MonoBehaviour
{
    public float magnitude = 1f;
    public float speed = 0.1f;
    Vector3 pos;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if ((transform.position - pos).magnitude > magnitude)
        {
            speed *= -1;
        }
        dir.y = speed;
        transform.Translate(dir);
    }
}
