using NavMeshPlus.Components;
using NavMeshPlus.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

class ClearNavMesh: MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface navMesh;


    public void Clear()
    {
        navMesh.RemoveData();
    }
}
