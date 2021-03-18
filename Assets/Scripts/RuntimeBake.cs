using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    class RuntimeBake: MonoBehaviour
    {
        public NavMeshSurface2d Surface2D;

        void Start()
        {
            Surface2D.BuildNavMesh();
        }
    }
}
