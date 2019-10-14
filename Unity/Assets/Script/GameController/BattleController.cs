using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleController : MonoSingleton<BattleController> {
    [Header("Scene")]
    public Camera UICamera;

    [Header("UI")]
    public Text CommandLog;
    public InputField field;

    //
    private PlayerUnit _player = new PlayerUnit();
    private List<BaseUnit> _units = new List<BaseUnit>();

    public void Initialize() {
        // 데이터 입력 필요
        _player.Initialize(null);
        _units.Clear();

        // 커맨드 입력 처리
        field.onEndEdit.RemoveAllListeners();
        field.onEndEdit.AddListener((value) => {
            _player.AppendCommand(new BattleCommand(value, _player));
            Debug.Log(value);

            field.text = string.Empty;
        });
    }

    public void Awake() {
        Initialize();
    }
}
