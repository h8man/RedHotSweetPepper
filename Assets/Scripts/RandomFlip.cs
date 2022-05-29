using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlip : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        transform.localScale = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), 1);
        if (transform.localScale.x == 0 || transform.localScale.y == 0)
        {
            gameObject.SetActive(false);
        }
    }

}
