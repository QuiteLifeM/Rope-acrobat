using System.Collections;
using UnityEngine;

public class RopeAbility : MonoBehaviour
{
    [SerializeField] private BoltTriggerZone _triggerZone;
    [SerializeField] private float _spinSpeed;
    [SerializeField] private Rigidbody _rigidbody;

    private Bolt _targetBolt;
    private bool _isSpinning;

    private void OnEnable()
    {
        _triggerZone.BoltFound += OnBoltFound;
    }

    private void OnDisable()
    {
        _triggerZone.BoltFound -= OnBoltFound;
    }

    private void OnBoltFound(Bolt bolt)
    {
        _targetBolt = bolt;
    }

    public void StartSpin()
    {
        if (!_isSpinning)
        {
            _isSpinning = true;
            StartCoroutine(Spin());
        }

        _rigidbody.useGravity = false;
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    public void StopSpin()
    {
        if (_isSpinning)
        {
            _isSpinning = false;
        }

        _rigidbody.useGravity = true;
        _rigidbody.constraints = RigidbodyConstraints.None;
    }

    private IEnumerator Spin()
    {
        while (_isSpinning)
        {
            if (_targetBolt != null)
            {
                Vector3 targetPosition = _targetBolt.transform.position;
                Vector3 axis = Vector3.up;
                transform.RotateAround(targetPosition, axis, _spinSpeed * Time.deltaTime);
            }

            yield return null;
        }
    }
}