using System;
using UnityEngine;

public class BoltTriggerZone : MonoBehaviour
{
    [SerializeField] private float _sphereRadius;
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _boltMask;

    private Vector3 _origin;
    private Collider[] _boltZone;

    public event Action<Bolt> BoltFound;
    
    private void Update()
    {
        CheckBolt();
    }

    private void CheckBolt()
    {
        _boltZone = Physics.OverlapSphere(transform.position, _sphereRadius, _boltMask);

        foreach (var collider in _boltZone)
        {
            if (collider == null)
            {
                continue;
            }

            if (collider.gameObject.TryGetComponent(out Bolt bolt))
            {
                print("Invoke Bolt");
                BoltFound?.Invoke(bolt);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sphereRadius);
    }
}