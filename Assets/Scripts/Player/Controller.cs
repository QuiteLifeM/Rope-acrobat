using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private RopeAbility _ropeAbility;

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _mover.StopMove();
            _ropeAbility.StartSpin();
        }
        else
        {
            _mover.SetMove();
            _ropeAbility.StopSpin();
        }
    }
}