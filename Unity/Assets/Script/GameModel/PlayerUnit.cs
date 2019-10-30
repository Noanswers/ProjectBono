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

    Vector2 movement;

    InteractiveObject interactiveObject = null;

    private void Update() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Battlemap.Instance.TileUpColor(transform.position, Color.red);

        CheckInteractive();

        if (Input.GetKeyDown(KeyCode.Space)) {
            Interact();
        }
    }

    void Move(float h, float v) {

        movement = new Vector2(h, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        _RigidBody.MovePosition((Vector2)transform.position + movement);
    }

    void CheckInteractive() {
        if (interactiveObject != null) {
            float distance = Vector2.Distance(interactiveObject.transform.position, transform.position);

            if (_Collider.size.x < distance) {
                ResetInteractive();
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        InteractiveObject colObj = collision.gameObject.GetComponent<InteractiveObject>();
        if (colObj != null) {

            ResetInteractive();

            interactiveObject = colObj;
            interactiveObject.InteractOn(this);
        }
    }

    void ResetInteractive() {
        if (interactiveObject != null) {
            interactiveObject.InteractOff();
            interactiveObject = null;
        }
    }


    void Interact() {
        if (interactiveObject) {
        
        }
    }

    public override void HandleAttacked() {

    }
}
