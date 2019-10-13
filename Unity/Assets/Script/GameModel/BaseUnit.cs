using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnit : MonoBehaviour {
    
    private List<Constants.UnitState> states;    // 유닛 상태이상 목록
    private List<BattleCommand> _commandLogs;   // 전체 실행 커맨드
    private Dictionary<Constants.UnitStat, float> _unitStat;    // 유닛 스텟
    private char[] _customMemory;   // 커맨드 입력에 따른 저장값이 필요할 때 해당 공간을 사용

    // 유닛 데이터 초기화
    public void Initialize(ResourceUnit resUnit) {
        states = new List<Constants.UnitState>();
        _commandLogs = new List<BattleCommand>();
        _unitStat = new Dictionary<Constants.UnitStat, float>();

        // 커스텀 메모리 초기화
        _customMemory = new char[resUnit.memSize];
        for (int i = 0; i < _customMemory.Length; ++i) {
            _customMemory[i] = (char) 0;
        }

        // 명령어 로그 삭제
        _commandLogs.Clear();
    }

    public abstract void HandleAttacked();
    public void AppendCommand(BattleCommand command) {
        _commandLogs.Add(command);
    }
}
