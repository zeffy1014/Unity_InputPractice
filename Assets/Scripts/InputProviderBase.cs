using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class InputProviderBase
{
    // 移動操作監視
    protected Subject<MoveDirection> onMoveSubject = new Subject<MoveDirection>();
    public IObservable<MoveDirection> OnMove => onMoveSubject;

    // 具体的な操作発行は継承先にて実施
}
