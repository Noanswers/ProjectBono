﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleController : MonoSingleton<BattleController>
{
    public Text CommandLog;

    public Camera UICamera;



    public PlayerUnit PlayerUnit = new PlayerUnit();
    public List<Unit> EnemyUnits = new List<Unit>();

    Queue<BattleCommand> CommandQueue = new Queue<BattleCommand>(); //전체 실행 커맨드 순서
    List<BattleCommand> WaitCommand = new List<BattleCommand>(); //AI가 다음에 실행할 커맨드들
    
    bool isBattle = false;


    private void Update()
    {
        if (!isBattle)
            return;

        if(WaitCommand.Count>0)
        {
            ProcessWaitCommand();
        }

        if(CommandQueue.Count>0)
        {
            BattleCommand doCommand = CommandQueue.Dequeue();
            CommandResult result = DoCommand(doCommand);
            PrintCommand(doCommand, result);
        }
    }

    void ProcessWaitCommand()
    {
        float waitTime = Time.deltaTime;
        for(int i=0; i<WaitCommand.Count; i++)
        {
            WaitCommand[i].WaitTotalTime += waitTime;
            if(WaitCommand[i].WaitTotalTime >= WaitCommand[i].WaitLeftTIme)
            {
                AddCommand(WaitCommand[i]);
                WaitCommand.RemoveAt(i);
                i--;
            }
        }
    }

    //일반적으로 유저의 입력 & 발동되는 AI의 입력
    public void AddCommand(BattleCommand command)
    {
        CommandQueue.Enqueue(command);
    }

    //일반적으로 AI의 입력
    public void AddWaitCommand(BattleCommand command)
    {
        WaitCommand.Add(command);
    }

    CommandResult DoCommand(BattleCommand command)
    {
        CommandResult result = new CommandResult();

        switch (command.Type)
        {
            case BattleCommand.CommandType.attack:
                break;
            case BattleCommand.CommandType.defence:
                break;
            case BattleCommand.CommandType.swap:
                break;
            case BattleCommand.CommandType.swing:
                break;
            case BattleCommand.CommandType.fireball:
                break;
            default:
                break;
        }
        return result;
    }

    void PrintCommand(BattleCommand command, CommandResult result)
    {

    }
    
    public BattleCommand MakeUserCommand(string commandString)
    {
        BattleCommand command = new BattleCommand(commandString, PlayerUnit);

        return command;
    }


    CommandResult Attack(BattleCommand command)
    {
        string targetUnitString = command.TargetValue1;
        Unit unit = GetUnit(targetUnitString);

        CommandResult result = new CommandResult();
        result.SetAttackResult(command, unit);
        return result;
    }



    Unit GetUnit(string name)
    {
        Unit unit = null;
        for(int i=0; i<EnemyUnits.Count; i++)
        {
            if (EnemyUnits[i].UnitName == name)
                unit = EnemyUnits[i];
        }

        if (PlayerUnit.UnitName == name)
            unit = PlayerUnit;

        return unit;
    }
}
