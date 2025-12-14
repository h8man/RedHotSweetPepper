using UnityEngine;

public class PolygonMeshGenerator : MonoBehaviour
{
    void Start()
    {

        var points = new Vector3[3];
        points[0] = new Vector3(0, 0, 0);
        points[1] = new Vector3(10, 0, 0);
        points[2] = new Vector3(10, 10, 0);
        // Create a new mesh
        Mesh mesh = new Mesh();
        // Define triangles (assuming the polygon is convex)
        int[] triangles = new int[3];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        // Assign data to the mesh
        mesh.vertices = points;
        mesh.triangles = triangles;

        // Optionally, calculate normals and bounds
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        // Assign the mesh to the MeshFilter
        GetComponent<MeshFilter>().mesh = mesh;

        // Assign a material for rendering (you can adjust this to your liking)
        GetComponent<MeshRenderer>().material = new Material(Shader.Find("Sprites/Default"));
    }
}