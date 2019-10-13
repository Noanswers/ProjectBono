using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCommand {
    public enum CommandType {
        NONE = 0,
        ATTACK, // 일반 공격
        DEFENCE, // 방어
        SWAP, // 회피
        SWING, // 전체 공격

        FIREBALL, // 화염구

        TOTAL,
    }

    public readonly CommandType type;
    public readonly string originalFullSentence;
    public readonly Unit useUnit;

    //bool textError = false;
    //string targetValue1;
    //public string TargetValue1 {
    //    get {
    //        return targetValue1;
    //    }
    //}
    //string targetValue2;

    ////AICommand (클래스를 따로 두는게 맞겠지만 아직 어떻게 될지 모르므로 임시로 같이 처리)
    //float waitLeftTime; // Command 실행까지 남은 시간
    //public float WaitLeftTIme {
    //    get {
    //        return waitLeftTime;
    //    }
    //}
    //public float WaitTotalTime { get; set; } = 0;
    //public BattleCommand() {
    //}

    public BattleCommand(string commandString, Unit useUnit) {
        if (string.IsNullOrEmpty(commandString.Trim()))
            return;

        //
        this.originalFullSentence = commandString;
        string[] commands = commandString.Split(' ');

        //
        // 명령어 해석기 하나 만들어서 string list 보내서 판단하도록 해야함
        // command는 명령어 자체에 대한 정보만 포함하는 것이 깔끔
        // 명령어가 발사된 시간, 명령어, 명령 주체 정도만 갖는 것이 깔끔해보임
    }

    CommandType GetCommandType(string str, Unit useUnit) {
        CommandType command = CommandType.NONE;

        if (!string.IsNullOrWhiteSpace(str) && !string.IsNullOrEmpty(str)) {
            if (str.Equals("attack", System.StringComparison.OrdinalIgnoreCase))
                command = CommandType.ATTACK;
            else if (str.Equals("defence", System.StringComparison.OrdinalIgnoreCase))
                command = CommandType.DEFENCE;
            else if (str.Equals("swap", System.StringComparison.OrdinalIgnoreCase))
                command = CommandType.SWAP;
            else if (str.Equals("swing", System.StringComparison.OrdinalIgnoreCase))
                command = CommandType.SWING;
            else if (str.Equals("fireball", System.StringComparison.OrdinalIgnoreCase))
                command = CommandType.FIREBALL;
        }
        return command;
    }
}