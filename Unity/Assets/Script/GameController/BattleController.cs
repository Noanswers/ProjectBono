using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleController : MonoSingleton<BattleController> {
    //[Header("Scene")]
    //public Camera UICamera;

    [Header("UI - logs")]
    public VerticalLayoutGroup vBoxLogs;
    public GameObject prefabCommand;

    [Header("UI - input")]
    public InputField inputField;
    public Text txtInputed;
    public ParticleSystem typeParticle;

    // private
    private PlayerUnit _player;
    private List<BaseUnit> _units = new List<BaseUnit>();

    public void Initialize() {
        // 데이터 입력 필요
        //_player.Initialize(null);
        _units.Clear();

        // 입력칸 초기화
        inputField.text = string.Empty;
        txtInputed.text = inputField.text;

        // 커맨드 효과 처리
        inputField.onValueChanged.RemoveAllListeners();
        inputField.onValueChanged.AddListener((value) => {
            // UI 버그 우회
            txtInputed.text = inputField.text;

            if (!typeParticle.gameObject.activeSelf)
                typeParticle.gameObject.SetActive(true);

            typeParticle.Play();
        });

        // 커맨드 입력 처리
        inputField.onEndEdit.RemoveAllListeners();
        inputField.onEndEdit.AddListener((value) => {
            //_player.AppendCommand(new BattleCommand(value, _player));
            //Debug.Log(value);

            inputField.text = string.Empty;
            txtInputed.text = inputField.text;

            if (!inputField.isFocused)
                inputField.Select();
        });
    }

    public void Awake() {
        typeParticle.Stop();

        Initialize();

        //
        if (!inputField.isFocused)
            inputField.Select();
    }
}
