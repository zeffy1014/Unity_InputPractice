using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection
{
    Right = 0,
    Left
};

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.0f;

    // Playerを移動させる
    public void MovePlayer(MoveDirection direction)
    {
        Vector2 position = this.transform.position;
        Vector2 directionVector = Vector2.zero;

        if (MoveDirection.Right == direction)
        {
            directionVector = new Vector2(1.0f, 0.0f);
        }
        else if (MoveDirection.Left == direction)
        {
            directionVector = new Vector2(-1.0f, 0.0f);
        }
        else { };

        //this.GetComponent<Rigidbody2D>().velocity = directionVector * moveSpeed;
        position += directionVector * moveSpeed * Time.deltaTime; // 移動距離 = 速度 * 時間
        this.transform.position = position;

        return;

    }

}
