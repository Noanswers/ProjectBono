using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public UnitBattleStat BattleStat;
    public UnitBattleStat OriginBattleStat;

    //유닛 상태이상 목록
    public List<UnitAbState> AbStates = new List<UnitAbState>();
    int teamIndex;
    bool isPlayerUnit;
    string unitName;
    public string UnitName {
        get {
            return unitName;
        }
    }

    int unitGameID;
    public int UnitGameID {
        get {
            return unitGameID;
        }
    }

    public int GetAttackValue() {
        int value = BattleStat.Atk;
        // 상태이상 처리
        // Def 처리
        // 빗나감!처리
        return value;
    }

    public int Damage(int originDamage) {
        BattleStat.HP -= originDamage;
        // 상태이상 처리
        // Def 처리
        // 빗나감!처리
        return originDamage;
    }

    private void Start() {

    }

}
