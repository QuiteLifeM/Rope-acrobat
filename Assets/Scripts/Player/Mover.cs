using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;
    
    public void SetMove()
    {
        transform.Translate(_direction * (_speed * Time.deltaTime), Space.Self);
    }

    public void StopMove()
    {
        transform.Translate(Vector3.zero);
    }
}