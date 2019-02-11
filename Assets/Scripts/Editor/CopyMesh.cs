using UnityEditor;
using UnityEngine;

namespace Assets {

    /// <summary>
    /// 
    /// </summary>
    public class CopyMesh : MonoBehaviour {

        [MenuItem("Assets/CopyMesh")]
        static void DoCopyMesh() {
            Mesh mesh = Selection.activeObject as Mesh;
            Mesh newmesh = new Mesh();
            newmesh.vertices = mesh.vertices;
            newmesh.triangles = mesh.triangles;
            newmesh.uv = mesh.uv;
            newmesh.normals = mesh.normals;
            newmesh.colors = mesh.colors;
            newmesh.tangents = mesh.tangents;
            AssetDatabase.CreateAsset(newmesh, AssetDatabase.GetAssetPath(mesh) + " copy.asset");
        }

        [MenuItem("Assets/CopyMeshGameObject")]
        static void DoCopyMeshGameObject() {
            Mesh mesh = (Selection.activeGameObject.GetComponent<MeshFilter>()).sharedMesh;
            Mesh newmesh = new Mesh();
            newmesh.vertices = mesh.vertices;
            newmesh.triangles = mesh.triangles;
            newmesh.uv = mesh.uv;
            newmesh.normals = mesh.normals;
            newmesh.colors = mesh.colors;
            newmesh.tangents = mesh.tangents;
            print(AssetDatabase.GetAllAssetPaths()[0]);
            AssetDatabase.CreateAsset(newmesh, AssetDatabase.GetAllAssetPaths()[0] + "/mesh_copy.asset");
        }
    }
}