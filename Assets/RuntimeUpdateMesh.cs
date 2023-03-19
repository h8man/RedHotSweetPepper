using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeUpdateMesh : MonoBehaviour
{
    public NavMeshSurface Surface2D;

    public void Update()
    {
        if (Time.frameCount % 60 == 0)
        {
            Surface2D.UpdateNavMesh(Surface2D.navMeshData);
        }
    }
}
