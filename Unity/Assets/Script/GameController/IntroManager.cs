using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

    public CanvasGroup imgLogoCG;

    private Sequence _introSeq;

    public void Awake() {
        _introSeq = GetFadeSeq();
        _introSeq.Play();
    }

    private Sequence GetFadeSeq() {
        return DOTween.Sequence()
            .OnStart(() => {
                //
                imgLogoCG.gameObject.SetActive(true);
                imgLogoCG.alpha = 0.0f;
            })
            .Append(imgLogoCG.DOFade(1.0f, 2.0f))
            .Append(imgLogoCG.DOFade(0.0f, 1.0f))
            .AppendCallback(() => {
                imgLogoCG.gameObject.SetActive(false);
                SceneManager.LoadScene(1);
            });
    }
}
