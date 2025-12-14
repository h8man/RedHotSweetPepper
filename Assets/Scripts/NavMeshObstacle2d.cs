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
    public bool WalkableOnDisable = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cacheSources2D.UpdateSource(gameObject);
    }

    private void OnDisable()
    {
        if (WalkableOnDisable)
        {
            cacheSources2D.UpdateSource(gameObject, 0);
        }
        else
        {
            cacheSources2D.RemoveSource(gameObject);
        }
    }

    private void OnEnable()
    {
        if (WalkableOnDisable)
        {
            cacheSources2D.UpdateSource(gameObject, 1);
        }
        else
        {
            cacheSources2D.AddSource(gameObject);
        }
    }
}
