using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PerlinTerrain))]
public class PerlinTerrainEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PerlinTerrain map = (PerlinTerrain)target;
        if (GUILayout.Button("Generate"))
        {
            map.Generate();
        }
    }

}
