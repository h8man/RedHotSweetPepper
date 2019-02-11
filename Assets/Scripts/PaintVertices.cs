using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Put this script in Editor mode to some object
/// </summary>
[ExecuteInEditMode]
public class PaintVertices : MonoBehaviour
{
    /// <summary>
    /// Consider such close vertices as one welded point of geometry.
    /// </summary>
    public float DistThreshold = 0.1f;

    /// <summary>
    /// Highlight welded points
    /// </summary>
    public bool ShowPoints = true;

    /// <summary>
    /// Prefix for handles' names
    /// </summary>    
    public string HandlePrefix = "Handle_";

    /// <summary>
    /// When work is done remove this script and handles from the hierarchy of the current object 
    /// </summary>
    public bool DestroyMe = true;

    /// <summary>
    /// Array of handles' transforms
    /// </summary>
    List<Transform> HandlesTr;

    // internal values
    Mesh m_mesh;
    Vector3[] m_verts;
    Vector3 m_vertPos;
    List<GameObject> m_groups;
    MeshFilter m_meshFilter;
    MeshCollider m_meshCollider;

    void Awake()
    {
        Debug.Log("Awake " + Application.isPlaying);
        if (Application.isPlaying)
        {
            Debug.Log("DO NOT USE ME IN PLAY MODE!");
            enabled = false;
            ShowPoints = false;
        }

        DestroyMe = false; // usually, we do not want to be destroyed from the beginning ;)
    }

    void OnEnable()
    {
        // after switch from the Play mode we should clear old handles, try not to use this script in the play mode
        Transform tt;
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            tt = transform.GetChild(i);
            if (tt.name.IndexOf(HandlePrefix) == 0)
                DestroyImmediate(tt.gameObject);
        }

        // init arrays
        m_groups = new List<GameObject>();
        HandlesTr = new List<Transform>();

        // make some steps in order to avoid error: "Instantiating mesh due to calling MeshFilter.mesh during edit mode. This will leak meshes. Please use MeshFilter.sharedMesh instead."
        m_meshFilter = GetComponent<MeshFilter>();
        m_mesh = Instantiate(m_meshFilter.sharedMesh);
        m_meshFilter.mesh = m_mesh;

        m_verts = m_mesh.vertices;

        // Make groups vertices these closer than DistTreshold to each other
        GameObject handle;
        foreach (Vector3 vert in m_verts)
        {
            m_vertPos = transform.TransformPoint(vert);
            handle = new GameObject();
            handle.transform.position = m_vertPos;
            handle.transform.parent = transform;

            int index = m_groups.FindIndex(var => Vector3.Distance(var.transform.position, m_vertPos) < DistThreshold);
            if (index > -1)
            {
                handle.transform.parent = m_groups[index].transform;
                handle.name = HandlePrefix + index;
            }
            else
            {
                m_groups.Add(handle); // some new vertex that to far from each previous, make the group for it
                handle.name = HandlePrefix + (m_groups.Count - 1);
            }

            HandlesTr.Add(handle.transform); // memo this handle
        }
    }

    /// <summary>
    /// Draw draggable points
    /// </summary>
    void OnDrawGizmos()
    {
        if (ShowPoints)
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < m_groups.Count; i++)
            {
                Gizmos.DrawSphere(m_groups[i].transform.position, 0.03f);
            }
        }
    }

    void Update()
    {
        if (DestroyMe)
        {
            // cleanup and destroy
            for (int i = 0; i < m_groups.Count; i++)
            {
                DestroyImmediate(m_groups[i]);
            }
            DestroyImmediate(this);
            return;
        }

        // Trace handlers position
        for (int i = 0; i < HandlesTr.Count; i++)
        {
            m_verts[i] = transform.InverseTransformPoint(HandlesTr[i].position);
        }

        // update the mesh according to last changes
        m_mesh.vertices = m_verts;
        m_mesh.RecalculateBounds();
        m_mesh.RecalculateNormals();
    }
}