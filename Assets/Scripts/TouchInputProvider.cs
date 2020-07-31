using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Zenject;

// 左右のuGUIボタンから左右移動操作を発行する
public class TouchInputProvider : InputProviderBase
{
    private MoveButton rightButton;
    private MoveButton leftButton;

    TouchInputProvider(
        [Inject(Id = MoveDirection.Right)] MoveButton rightButton,
        [Inject(Id = MoveDirection.Left)] MoveButton leftButton)
    {
        this.rightButton = rightButton;
        this.leftButton = leftButton;

        // 各ボタンの押されを監視
        this.rightButton.OnButtonDown
            .Where(isPush => true == isPush)
            .Subscribe(isPush => onMoveSubject.OnNext(MoveDirection.Right));

        this.leftButton.OnButtonDown
            .Where(isPush => true == isPush)
            .Subscribe(_ => onMoveSubject.OnNext(MoveDirection.Left));
    }

}

