using NavMeshPlus.Components;
using System.Collections.Generic;
using UnityEngine;

public class WarpOnNavMeshEvent : MonoBehaviour
{
    public List<GameObject> objects;
    public Vector3 offset;
    public void WarpObjects(NavMeshLink link)
    {
        if (gameObject == link.gameObject)
        {
            Debug.Log("Warp");
            foreach (var obj in objects)
            {
                obj.transform.position += offset;
            }
        }
    }
}
