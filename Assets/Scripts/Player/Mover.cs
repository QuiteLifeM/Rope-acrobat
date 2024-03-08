using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;
    
    private bool _isMoving = false;
    
    public void SetMove()
    {
        if (!_isMoving)
        {
            _isMoving = true;
            StartCoroutine(MoveStraight());
        }
    }
    
    public void StopMove()
    {
        if (_isMoving)
        {
            _isMoving = false;
        }
    }

    private IEnumerator MoveStraight()
    {
        while (_isMoving)
        {
            transform.Translate(_direction * (_speed * Time.deltaTime), Space.Self);
            yield return null;
        }
    }
}