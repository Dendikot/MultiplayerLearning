using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 2f;
    private float _inputH;
    private float _inputV;

    public void SetInput(float h, float v)
    {
        _inputV = v;
        _inputH = h;
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(_inputH, 0, _inputV).normalized;
        transform.position += direction * Time.deltaTime * _speed;
    }

    public void GetMoveInfo(out Vector3 position, out Vector3 velocity)
    {
        position = transform.position;
        velocity = _rigidbody.linearVelocity;
    }
}
