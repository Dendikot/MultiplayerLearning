using UnityEngine;

public class CheckFly : MonoBehaviour
{
    public bool isFly { get; private set; }

    [SerializeField] private LayerMask _layerMaskGround;
    [SerializeField] private float _radius;
    [SerializeField] private float _coyoteTime = .25f;
    private float _flyTimer = 0;

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, _radius, _layerMaskGround))
        {
            isFly = false;
            _flyTimer = 0;
        }
        else
        {
            _flyTimer += Time.deltaTime;
            if(_flyTimer > _coyoteTime)
            {
                isFly = true;
            }
        }

    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, _radius);
    }
#endif
}
