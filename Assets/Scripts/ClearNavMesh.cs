using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ClearNavMesh: MonoBehaviour
{
    [SerializeField]
    private NavMeshObstacle2d navMeshObstacle;

    public NavMeshObstacle2d NevMeshObstacle { get => navMeshObstacle; set => navMeshObstacle = value; }

    public void Clear()
    {
        navMeshObstacle.enabled = false;
        navMeshObstacle?.surface.RemoveData();
    }
}
