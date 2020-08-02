using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InputPresenter
{
    private Player player;
    private IInputProvider input;

    InputPresenter(IInputProvider input, Player player)
    {
        this.player = player;
        this.input = input;

        // 操作を監視してPlayerを動かす
        this.input.OnMove.Subscribe(dist => player.MovePlayer(dist));
    }
}
