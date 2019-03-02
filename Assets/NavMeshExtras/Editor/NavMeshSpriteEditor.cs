using UnityEngine;
using UnityEditor;
using NavMesh.Extras;

namespace NavMeshEditor.Extras
{
    [CustomEditor(typeof(NavMeshSprite))]
    public class SpriteMeshEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var navsprite = (NavMeshSprite)target;
            if (GUILayout.Button("Load Object"))
            {
                var mesh = new Mesh();
                sprite2mesh(navsprite.sprite, mesh);
                var meshFilter = navsprite.GetComponent<MeshFilter>();
                meshFilter.mesh = mesh;
            }
        }
        static void sprite2mesh(Sprite sprite, Mesh mesh)
        {
            Vector3[] vert = new Vector3[sprite.vertices.Length];
            for (int i = 0; i < sprite.vertices.Length; i++)
            {
                vert[i] = new Vector3(sprite.vertices[i].x, sprite.vertices[i].y, 0);
            }
            mesh.vertices = vert;
            mesh.uv = sprite.uv;
            int[] tri = new int[sprite.triangles.Length];
            for (int i = 0; i < sprite.triangles.Length; i++)
            {
                tri[i] = sprite.triangles[i];
            }
            mesh.triangles = tri;
            mesh.name = sprite.name;
        }
    }
}
