using UnityEngine;
using System.Collections;
using UnityEditor;

//just a test custom inspector thing
[CustomEditor(typeof(GameObject))]
public class WorldPositionInspector : Editor {

    public override void OnInspectorGUI()
    {
        GameObject myTarget = (GameObject)target;
        EditorGUILayout.Vector3Field("Global Position", myTarget.transform.position);
    }
}
