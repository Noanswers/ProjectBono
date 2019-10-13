using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ResourceUnit : ResourceBase {
    //
    //public readonly GameObject prefab;

    public int hp;
    public int sp;
    public int dex;
    public int def;
    public int attack_physical;
    public int attack_magical;

    public int memSize;

    public override void SetData(Dictionary<string, object> jsonRaw) {
        base.SetData(jsonRaw);
    
        //
        if (jsonRaw.ContainsKey("hp")) {
            int.TryParse(jsonRaw["hp"].ToString(), out hp);
        }                                           
        if (jsonRaw.ContainsKey("sp")) {            
            int.TryParse(jsonRaw["sp"].ToString(), out sp);
        }                                           
        if (jsonRaw.ContainsKey("dex")) {            
            int.TryParse(jsonRaw["dex"].ToString(), out dex);
        }                                           
        if (jsonRaw.ContainsKey("def")) {            
            int.TryParse(jsonRaw["def"].ToString(), out def);
        }                                           
        if (jsonRaw.ContainsKey("attack_physical")) {            
            int.TryParse(jsonRaw["attack_physical"].ToString(), out attack_physical);
        }                                           
        if (jsonRaw.ContainsKey("attack_magical")) {            
            int.TryParse(jsonRaw["attack_magical"].ToString(), out attack_magical);
        }

        if (jsonRaw.ContainsKey("memSize")) {
            int.TryParse(jsonRaw["memSize"].ToString(), out memSize);
        }
    }

    public static ResourceUnit Get(long unitID) {
        return ResourceManager.Get().GetUnitByID(unitID);
    }
}
