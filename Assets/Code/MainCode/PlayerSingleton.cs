using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSingleton : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    private Vector3 _direction;

    public void SetPosition(Vector3 position)
    {
        gameObject.transform.position = position;
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
            MoveVertical(1);
        if(Input.GetKey(KeyCode.S))
            MoveVertical(-1);
        if(Input.GetKey(KeyCode.D))
            MoveHorizontal(1);
        if(Input.GetKey(KeyCode.A))
            MoveHorizontal(-1);
        
        if (!Input.GetMouseButton(0))
            return;

        var screenSize = new Vector2(Screen.width / 2, Screen.height/2);

        var x = (Input.mousePosition.x - screenSize.x) / screenSize.x;
        var y = (Input.mousePosition.y - screenSize.y) / screenSize.y;

        if (Mathf.Abs(x)/Screen.width > Mathf.Abs(y)/Screen.height)
        {
            MoveHorizontal(x);
        }
        else if (Mathf.Abs(y)/Screen.height > Mathf.Abs(x)/Screen.width)
        {
            MoveVertical(y);
        }
    }

    private void MoveVertical(float y)
    {
        _direction.x = 0;
        _direction.y = y / Mathf.Abs(y);
        gameObject.transform.position += _direction * (_speed * Time.deltaTime);
    }

    private void MoveHorizontal(float x)
    {
        _direction.y = 0;
        _direction.x = x / Mathf.Abs(x);
        gameObject.transform.position += _direction * (_speed * Time.deltaTime);
    }
}