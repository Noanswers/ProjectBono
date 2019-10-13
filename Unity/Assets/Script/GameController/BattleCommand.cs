﻿using System.Collections;
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

    CommandType type = CommandType.NONE;
    public CommandType Type {
        get {
            return type;
        }
    }
    string originalFullSentence = string.Empty;
    Unit useUnit = null;
    public Unit UseUnit {
        get {
            return useUnit;
        }
    }
    bool swapping = false; // 회피 등으로 무효화된 커맨드인지 여부
    public bool Swapping {
        get {
            return swapping;
        }
    }
    bool textError = false;
    string targetValue1;
    public string TargetValue1 {
        get {
            return targetValue1;
        }
    }
    string targetValue2;

    //AICommand (클래스를 따로 두는게 맞겠지만 아직 어떻게 될지 모르므로 임시로 같이 처리)
    float waitLeftTime; // Command 실행까지 남은 시간
    public float WaitLeftTIme {
        get {
            return waitLeftTime;
        }
    }
    public float WaitTotalTime { get; set; } = 0;
    public BattleCommand() {
    }

    public BattleCommand(string commandString, Unit useUnit) {
        textError = true;
        if (string.IsNullOrWhiteSpace(commandString) || string.IsNullOrEmpty(commandString))
            return;

        originalFullSentence = commandString;

        string[] commands = commandString.Split(' ');
        if (commands != null && commands.Length > 0) {
            type = GetCommandType(commands[0], useUnit);

            if (commands.Length > 1)
                targetValue1 = commands[1];
            if (commands.Length > 2)
                targetValue2 = commands[2];
        }

        if (type != CommandType.NONE)
            textError = false;
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


public class CommandResult {
    string resultString;
    public bool success;

    public void SetAttackResult(BattleCommand command, Unit targetUnit) {
        if (command.Swapping) {
            resultString = "공격이 빗나갔다";
            success = false;
        } else {
            int damage = targetUnit.Damage(command.UseUnit.GetAttackValue());
        }
    }
}