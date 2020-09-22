using System.Collections;
using UnityEngine;
using UnityEditor;

//MapGeneratorEditor Class will give the ability to work with the map generator within the editor
[CustomEditor (typeof (MapGenerator))]
public class MapGeneratorEditor : Editor
{
    //This override is used to create a "Generate" button in the inspector
    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;

        if (DrawDefaultInspector())
        {
            if (mapGen.autoUpdate)
            {
                mapGen.GenerateMap();
            }
        }

        if (GUILayout.Button ("Generate"))
        {
            mapGen.GenerateMap();
        }
    }
}
