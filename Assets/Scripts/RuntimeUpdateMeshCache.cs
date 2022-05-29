using NavMeshComponents.Extensions;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    class RuntimeUpdateMeshCache: MonoBehaviour
    {
        public NavMeshCacheSources2d cacheSources2D;

        private void Update()
        {
            if (cacheSources2D.IsDirty)
            {
                cacheSources2D.UpdateNavMesh();
            }
        }
    }
}
