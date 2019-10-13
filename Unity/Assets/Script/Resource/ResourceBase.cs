using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBase {

    public int id;
    public string name;

    public ResourceBase() {

    }

    public virtual void SetData(Dictionary<string, object> jsonRaw) {
        ResourceBase _data = new ResourceBase();

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
