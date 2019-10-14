using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleController : MonoSingleton<BattleController> {
    [Header("Scene")]
    public Camera UICamera;

    [Header("UI - logs")]
    public VerticalLayoutGroup vBoxLogs;
    public GameObject prefabCommand;

    [Header("UI - input")]
    public InputField inputField;

    // private
    private PlayerUnit _player = new PlayerUnit();
    private List<BaseUnit> _units = new List<BaseUnit>();

    public void Initialize() {
        // 데이터 입력 필요
        _player.Initialize(null);
        _units.Clear();

        // 커맨드 입력 처리
        inputField.onEndEdit.RemoveAllListeners();
        inputField.onEndEdit.AddListener((value) => {
            _player.AppendCommand(new BattleCommand(value, _player));
            Debug.Log(value);

            inputField.text = string.Empty;
        });
    }

    public void Awake() {
        Initialize();
    }
}
