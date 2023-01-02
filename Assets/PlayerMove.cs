using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionReference _move;
    [SerializeField] float _speed;

    // Version 1
    //Vector2 _joystickDirection;
    //public Vector2 MonJoystick
    //{
    //    get => _joystickDirection;
    //    set
    //    {
    //        if (value != _joystickDirection) return;
    //        _joystickDirection = value;
    //    }
    //}
    // Version 2
    public Vector2 JoystickDirection { get; private set; }

    Coroutine MovementRoutine { get; set; }

    private void Start()
    {
        _move.action.started += StartMove;
        _move.action.performed += UpdateMove;
        _move.action.canceled += StopMove;
    }


    private void OnDestroy()
    {
        _move.action.started -= StartMove;
        _move.action.performed -= UpdateMove;
        _move.action.canceled -= StopMove;
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            transform.Translate(new Vector3(JoystickDirection.x, 0, JoystickDirection.y) * _speed * Time.fixedDeltaTime);
        }
    }


    private void StartMove(InputAction.CallbackContext obj)
    {
        JoystickDirection = obj.ReadValue<Vector2>();
        MovementRoutine = StartCoroutine(MoveRoutine());
    }
    private void UpdateMove(InputAction.CallbackContext obj)
    {
        JoystickDirection = obj.ReadValue<Vector2>();
        Debug.Log($"Update Move : {obj.ReadValue<Vector2>()}");
    }
    private void StopMove(InputAction.CallbackContext obj)
    {
        StopCoroutine(MovementRoutine);
        JoystickDirection = Vector2.zero;
        Debug.Log($"Stop Move : {obj.ReadValue<Vector2>()}");
    }




    private void FixedUpdate()
    {
        //transform.Translate(new Vector2( Input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime, 0));
    }






}
