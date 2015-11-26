using UnityEngine;
using UnityEditor;
using System.Collections;

static class CreateScriptableObject {

	[MenuItem("Assets/Create/Scriptable Object")]
    public static void Create()
    {
        Stats asset = ScriptableObject.CreateInstance<Stats>();
        AssetDatabase.CreateAsset(asset, "Assets/ScriptableObj/Checkpoint.asset");
    }
}
