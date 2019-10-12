using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCommand
{
    public enum CommandType
    {
        none = 0,
        attack, // 일반 공격
        defence, // 방어
        swap, // 회피
        swing, // 전체 공격

        fireball, // 화염구


    }

    CommandType type = CommandType.none;
    string originalFullSentence = string.Empty;
    int useUnitGameID = 0;
    bool swapping = false; // 회피 등으로 무효화된 커맨드인지 여부

    //AICommand (클래스를 따로 두는게 맞겠지만 아직 어떻게 될지 모르므로 임시로 같이 처리)
    float waitLeftTime; // Command 실행까지 남은 시간
    public float WaitLeftTIme
    {
        get { return waitLeftTime; }
    }
    public float WaitTotalTime { get; set; } = 0;

    public BattleCommand() { }
    public BattleCommand(string commandString) { }
}


public class CommandResult
{

}