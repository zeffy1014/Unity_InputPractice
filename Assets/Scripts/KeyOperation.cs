using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class KeyOperation : MonoBehaviour
{
    // 監視用
    Subject<Unit> onRightKeySubject = new Subject<Unit>();
    public IObservable<Unit> OnRightKey => onRightKeySubject;
    Subject<Unit> onLeftKeySubject = new Subject<Unit>();
    public IObservable<Unit> OnLeftKey => onLeftKeySubject;

    void Start()
    {
        IObservable<Unit> updateAsObserbable = this.UpdateAsObservable();

        // Updateタイミングで各キーの入力を監視する
        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                if (Input.GetKey(KeyCode.RightArrow)) onRightKeySubject.OnNext(Unit.Default);
                if (Input.GetKey(KeyCode.LeftArrow)) onLeftKeySubject.OnNext(Unit.Default);
            })
            .AddTo(this);
    }

}
