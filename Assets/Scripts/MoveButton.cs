using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;

public class MoveButton : MonoBehaviour
{
    // 監視用
    private Subject<bool> onButtonDownSubject = new Subject<bool>();
    public IObservable<bool> OnButtonDown => onButtonDownSubject;

    private bool buttonDown = false;

    [SerializeField] Sprite defaultImage;
    [SerializeField] Sprite pushImage;

    void Start()
    {
        // EventTriggerを追加してボタン押され/離され(PointerDown/PointerUp)を拾う
        var eventTrigger = this.gameObject.AddComponent<ObservableEventTrigger>();
        eventTrigger.OnPointerDownAsObservable()
            .Subscribe(_ =>
            {
                buttonDown = true;
                PushButton(true);
            })
        .AddTo(this);
        eventTrigger.OnPointerUpAsObservable()
            .Subscribe(_ =>
            {
                buttonDown = false;
                PushButton(false);
            })
            .AddTo(this);

        // Updateタイミングで現在のボタン押され状況を発行する
        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                onButtonDownSubject.OnNext(buttonDown);
            })
            .AddTo(this);
    }

    void PushButton(bool startPush)
    {
        // 表示画像変更
        if (startPush)
        {
            // 押され画像があればそれにする
            if (pushImage) this.GetComponent<Image>().sprite = pushImage;
        }
        else
        {
            // 離され(デフォルト)画像があればそれにする
            if (defaultImage) this.GetComponent<Image>().sprite = defaultImage;
        }
    }

}
