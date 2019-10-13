using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleController : MonoSingleton<BattleController> {
    public Text CommandLog;
    public Camera UICamera;

    public InputField field;

    public PlayerUnit playerUnit;
    public List<Unit> enemyUnits;

    private Queue<BattleCommand> commandQueue = new Queue<BattleCommand>(); //전체 실행 커맨드 순서
    private List<BattleCommand> waitCommand = new List<BattleCommand>(); //AI가 다음에 실행할 커맨드들

    //
    bool isBattle = false;

    public void Initialize() {
        playerUnit = new PlayerUnit();
        enemyUnits = new List<Unit>();

        //
        field.onEndEdit.RemoveAllListeners();
        field.onEndEdit.AddListener((value) => {
            commandQueue.Enqueue(new BattleCommand(value, playerUnit));
            Debug.Log(value);

            field.text = string.Empty;
        });
    }

    public void Awake() {
        Initialize();
    }

    private void Update() {
        if (!isBattle)
            return;

        if (waitCommand.Count > 0) {
            ProcessWaitCommand();
        }

        if (commandQueue.Count > 0) {
            BattleCommand doCommand = commandQueue.Dequeue();
            CommandResult result = DoCommand(doCommand);
            PrintCommand(doCommand, result);
        }
    }


    void ProcessWaitCommand() {
        float waitTime = Time.deltaTime;
        for (int i = 0; i < waitCommand.Count; i++) {
            waitCommand[i].WaitTotalTime += waitTime;
            if (waitCommand[i].WaitTotalTime >= waitCommand[i].WaitLeftTIme) {
                AddCommand(waitCommand[i]);
                waitCommand.RemoveAt(i);
                i--;
            }
        }
    }

    //일반적으로 유저의 입력 & 발동되는 AI의 입력
    public void AddCommand(BattleCommand command) {
        commandQueue.Enqueue(command);
    }

    //일반적으로 AI의 입력
    public void AddWaitCommand(BattleCommand command) {
        waitCommand.Add(command);
    }

    CommandResult DoCommand(BattleCommand command) {
        CommandResult result = new CommandResult();
        
        switch (command.Type) {
            case BattleCommand.CommandType.NONE:
                break;
            case BattleCommand.CommandType.ATTACK:
                break;
            case BattleCommand.CommandType.DEFENCE:
                break;
            case BattleCommand.CommandType.SWAP:
                break;
            case BattleCommand.CommandType.SWING:
                break;
            case BattleCommand.CommandType.FIREBALL:
                break;
            case BattleCommand.CommandType.TOTAL:
                break;
            default:
                break;
        }
        return result;
    }

    void PrintCommand(BattleCommand command, CommandResult result) {

    }

    public BattleCommand MakeUserCommand(string commandString) {
        BattleCommand command = new BattleCommand(commandString, playerUnit);

        return command;
    }


    CommandResult Attack(BattleCommand command) {
        string targetUnitString = command.TargetValue1;
        Unit unit = GetUnit(targetUnitString);

        CommandResult result = new CommandResult();
        result.SetAttackResult(command, unit);
        return result;
    }

    Unit GetUnit(string name) {
        Unit unit = null;
        for (int i = 0; i < enemyUnits.Count; i++) {
            if (enemyUnits[i].UnitName == name)
                unit = enemyUnits[i];
        }

        if (playerUnit.UnitName == name)
            unit = playerUnit;

        return unit;
    }
}
