using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBase {

    public readonly int id;
    public readonly string name;

    //public Sprite sprite;

    public ResourceBase(Dictionary<string, object> jsonRaw) {
        //
        if (jsonRaw.ContainsKey("id")) {
            id = int.Parse(jsonRaw["id"].ToString());
        }

        //
        if (jsonRaw.ContainsKey("name")) {
            name = jsonRaw["name"].ToString();
        }

        //if (jsonRaw.ContainsKey("sprite")) {
        //    var _path = jsonRaw["sprite"].ToString();
        //    imgStage = Utility.LoadResource<Sprite>(_path);
        //}
    }
}
