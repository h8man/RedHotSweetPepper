using NavMeshPlus.Extensions;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    class RuntimeUpdateMeshCache: MonoBehaviour
    {
        public CollectSourcesCache2d cacheSources2D;

        private void Update()
        {
            if (cacheSources2D.IsDirty)
            {
                cacheSources2D.UpdateNavMesh();
            }
        }
    }
}
