using NavMeshPlus.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshObstacle2d : MonoBehaviour
{
    // Start is called before the first frame update
    public CollectSourcesCache2d cacheSources2D;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cacheSources2D.UpdateSource(gameObject);
    }
}
