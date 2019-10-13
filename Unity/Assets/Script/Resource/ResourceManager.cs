using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ResourceManager {

    private static ResourceManager singleton = new ResourceManager();
    private bool inited = false;
    const string PATCH_FOLDER_NAME = "Patches";
    const string DIR_PATCHES = "Assets/" + PATCH_FOLDER_NAME + "/";

    //
    private Dictionary<long, ResourceUnit> units = new Dictionary<long, ResourceUnit>();

    //
    public ResourceUnit GetUnitByID(long unitID) {
        if (!units.ContainsKey(unitID))
            return null;

        return units[unitID];
    }

    public static ResourceManager Get() {
        if (singleton == null)
            singleton = new ResourceManager();

        return singleton;
    }

    public void Initialize() {
        if (singleton.inited)
            return;

        //
        ReloadAll();

        //
        singleton.inited = true;
    }

    private void ReloadAll() {
        ReloadFolder<ResourceUnit>("Unit", units);
    }

    private void ReloadFolder<T>(string folderName, Dictionary<long, T> container) where T : ResourceBase, new() {
        container.Clear();

        //
        foreach (string textAssetName in Utility.GetFileNamesAtPath("Patches/" + folderName)) {
            var ta = Utility.LoadPatches<TextAsset>(folderName + "/" + textAssetName);
            var parsed = Utility.ParseJSONfromTextAsset(ta);

            //
            foreach (var jRes in parsed) {
                //
                var _res = new T();
                _res.SetData(jRes);
                container.Add(_res.id, _res);
            }

            //
            Resources.UnloadAsset(ta);
            Debug.Log(textAssetName + " : " + parsed.Count);
        }
    }
}