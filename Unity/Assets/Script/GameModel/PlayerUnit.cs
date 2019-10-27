using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : BaseUnit {

    Vector2 movement;
    private void Update() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Battlemap.Instance.TileUp(transform.position);
    }

    public void Move(float h, float v) {

        movement = new Vector2(h, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        _RigidBody.MovePosition((Vector2)transform.position + movement);
    }

    public override void HandleAttacked() {

    }
}
