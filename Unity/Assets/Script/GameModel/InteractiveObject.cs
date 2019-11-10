using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public SpriteRenderer _MainSprite;
    public BoxCollider2D _Collider;


    private void Awake() {
        if (_MainSprite == null)
            _MainSprite = GetComponent<SpriteRenderer>();
        if (_Collider == null)
            _Collider = GetComponent<BoxCollider2D>();
    }

    public void Interact(PlayerUnit unit) {
    
    }

    public void InteractOn(PlayerUnit unit) {
        _MainSprite.color = unit.Color;

    }

    public void InteractOff() {
        _MainSprite.color = Color.white;
    }
}
