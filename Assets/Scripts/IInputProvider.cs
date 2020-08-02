using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

// 本当はInterfaceにしたいけれども監視用メンバが置けないのでBaseクラスという扱いにする
public interface IInputProvider
{
    // 移動操作監視
    IObservable<MoveDirection> OnMove { get; }

    // 具体的な操作発行は継承先にて実施
}
