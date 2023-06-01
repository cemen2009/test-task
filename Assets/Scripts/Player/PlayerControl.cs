using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Transform cameraTransform;
    private PlayerInput _playerInput;
    private Vector2 input;
    private Vector3 move = Vector3.zero;
    [SerializeField] private float speed = 4f;
    private Vector2 look;
    private Vector3 deltaLook = Vector3.zero;
    private Vector3 cameraRotate = Vector3.zero;
    [Range(30f, 180f)]
    [SerializeField] private float sensetive = 90f;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        input = _playerInput.actions["Move"].ReadValue<Vector2>();
        move = new Vector3(input.x, 0f, input.y);

        move = move.x * cameraTransform.right + move.z * cameraTransform.forward;
        move.y = 0f;
        this.transform.position += move * Time.deltaTime * speed;    

        look = _playerInput.actions["Look"].ReadValue<Vector2>();
        cameraRotate.x = look.y;
        deltaLook.y = look.x;
        this.transform.localEulerAngles += deltaLook * Time.deltaTime * sensetive;
        cameraTransform.localEulerAngles -= cameraRotate * Time.deltaTime * sensetive;
    }
}
