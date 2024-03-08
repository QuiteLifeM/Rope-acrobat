using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private RopeAbility _ropeAbility;

    private void Start()
    {
        _mover.SetMove();
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("пробел нажат");
            _mover.StopMove();
            _ropeAbility.StartSpin();
        }
    }
}