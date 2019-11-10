using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : BaseUnit {

    public BoxCollider2D _Collider = null;

    Color color;
    public Color Color {
        get {
            return color;
        }
    }

    PlayerModel playerModel = null;

    Vector2 movement;

    InteractiveObject enableInteractiveObject = null;

    bool isMyPlayer = false;
    public bool IsMyPlayer {
        get {
            return isMyPlayer;
        }
    }

    //InputManager로 옮기자
    private void Update() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v, moveSpeed);
        Battlemap.Instance.TileUpColor(transform.position, Color.red);

        CheckInteractive();

        if (Input.GetKeyDown(KeyCode.Space)) {
            Interact();
        }

        if (IsSprint()) {
            Sprint(h, v);
        }
    }

    void Move(float h, float v, float speed) {

        movement = new Vector2(h, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        _RigidBody.MovePosition((Vector2)transform.position + movement);
    }


    //조작 더블클릭?
    bool IsSprint() {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            return true;
        }

        return false;
    }


    void Sprint(float h, float v) {
        Move(h, v, sprintSpeed);
    }

    void CheckInteractive() {
        if (enableInteractiveObject != null) {
            float distance = Vector2.Distance(enableInteractiveObject.transform.position, transform.position);

            if (_Collider.size.x < distance) {
                ResetInteractive();
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        InteractiveObject colObj = collision.gameObject.GetComponent<InteractiveObject>();
        if (colObj != null) {

            ResetInteractive();

            enableInteractiveObject = colObj;
            enableInteractiveObject.InteractOn(this);
        }
    }

    void ResetInteractive() {
        if (enableInteractiveObject != null) {
            enableInteractiveObject.InteractOff();
            enableInteractiveObject = null;
        }
    }


    void Interact() {
        if (enableInteractiveObject) {
            enableInteractiveObject.Interact(this);
        }
    }

    public override void HandleAttacked() {

    }
}
