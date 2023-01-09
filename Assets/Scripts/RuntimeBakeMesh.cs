using NavMeshPlus.Components;
using NavMeshPlus.Extensions;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    class RuntimeBakeMesh: MonoBehaviour
    {
        public NavMeshSurface Surface2D;

        public IEnumerator Start()
        {
            if (Surface2D.useGeometry == NavMeshCollectGeometry.PhysicsColliders)
            {
                yield return new WaitForFixedUpdate();
            }
            Surface2D.BuildNavMesh();
            yield return null;
        }
    }
}
