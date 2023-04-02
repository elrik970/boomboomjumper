using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class CursorPointer : MonoBehaviour
{
    // Start is called before the first frame update
    public Material ThisMaterial;
    public Color color; 
    public float CursorCircleSize = 10f;
    public PlayerMovement movement;
    public PlayerController PlayerController;
    void Awake() {
        movement = new PlayerMovement();
    }
    void OnEnable() {
        movement.Enable();
    }

    void OnDisable() {
        if (movement != null) movement.Disable();
    }
    Vector2 move;
    void Start()
    {
        Cursor.visible = false; 
        movement.ControllerGround.CursorControls.performed += ctx => move = ctx.ReadValue<Vector2>();
        // movement.ControllerGround.RunRightPress.performed += IsActivate;
        
    }
    public Vector2 mousePosition;
    void Update()
    {
        
        move = movement.ControllerGround.CursorControls.ReadValue<Vector2>();
        // bool s = move == Vector2.zero;
        // if (!(s)) {
            // Debug.Log(move);
        // }
        
        // mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // transform.position = new Vector2 (mousePosition.x, mousePosition.y);
        Vector2 PlayerPos = PlayerController.transform.position;
        Vector2 shouldBePos;
        move = move * CursorCircleSize;
        shouldBePos.x = PlayerPos.x + move.x; 
        shouldBePos.y = PlayerPos.y + move.y;
        transform.position = shouldBePos;
        bool PressNowhere = move == Vector2.zero;
        if (PressNowhere) {
            SpriteRenderer AttackSprite = GetComponent<SpriteRenderer>();
            AttackSprite.enabled = false;
        }
        else {
            SpriteRenderer AttackSprite = GetComponent<SpriteRenderer>();
            AttackSprite.enabled = true;
        }
    }
}
