using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshObstacle2d : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshSurface2d surface;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        surface.UpdateNavMesh(surface.navMeshData);
    }
}
