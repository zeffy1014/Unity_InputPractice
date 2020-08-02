using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

// マウスやキーボード入力から左右移動操作を発行する
public class PCInputProvider : IInputProvider
{
    // 移動操作監視(OnMoveをoverride)
    protected Subject<MoveDirection> onMoveSubject = new Subject<MoveDirection>();
    public IObservable<MoveDirection> OnMove => onMoveSubject;

    private KeyOperation key;

    PCInputProvider(KeyOperation key)
    {
        this.key = key;

        // 左右キー操作を監視して移動操作を発行
        this.key.OnRightKey.Subscribe(_ => onMoveSubject.OnNext(MoveDirection.Right));
        this.key.OnLeftKey.Subscribe(_ => onMoveSubject.OnNext(MoveDirection.Left));
    }
}
