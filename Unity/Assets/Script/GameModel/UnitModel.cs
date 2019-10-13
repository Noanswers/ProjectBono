using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitModel : MonoBehaviour {

}

public class UnitBattleStat {
    public int HP;
    public int SP;
    public int Atk;
    public int Mtk;
    public int Def;
    public int Dex;
    public int Swap;
    public List<BattleCommand.CommandType> EnableCommands;
}

public class UnitAbState {

}