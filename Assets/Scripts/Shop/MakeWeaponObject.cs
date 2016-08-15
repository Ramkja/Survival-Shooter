using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeWeaponObject {

    [MenuItem("Assets/Create/Weapon Object")]
    public static void Create() 
    {
        //Create the asset and save it
        WeaponObject asset = ScriptableObject.CreateInstance<WeaponObject>();
        AssetDatabase.CreateAsset(asset, "Assets/NewWeaponObject.asset");
        AssetDatabase.SaveAssets();

        //Focus in the new asset
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
