using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _cameraPoint;
    [SerializeField] private float _minHeadAngle = -90f;
    [SerializeField] private float _maxHeadAngle = 90f;
    [SerializeField] private float _jumpForce = 50;
    [SerializeField] private CheckFly _checkFly;
    [SerializeField] private float _jumpDelay = .2f;

    private float _inputH;
    private float _inputV;
    private float _rotateY;
    private float _currentRotateX;
    private float _jumpTime;

    private void Start()
    {
        Transform camera = Camera.main.transform;
        camera.parent = _cameraPoint;
        camera.localRotation = Quaternion.identity;
        camera.localPosition = Vector3.zero;
    }


    public void SetInput(float h, float v, float rotateY)
    {
        _inputV = v;
        _inputH = h;
        _rotateY += rotateY;
    }

    void FixedUpdate()
    {
        Move();
        RotateY();
    }

    private void Move()
    {
        //Vector3 direction = new Vector3(_inputH, 0, _inputV).normalized;
        //transform.position += direction * Time.deltaTime * _speed;

        Vector3 velocity = (transform.forward * _inputV + transform.right * _inputH).normalized * speed;
        velocity.y = _rigidbody.linearVelocity.y;
        base.velocity = velocity;

        _rigidbody.linearVelocity = base.velocity;
    }

    private void RotateY()
    {
        _rigidbody.angularVelocity = new Vector3(0, _rotateY, 0);
        _rotateY = 0;
    }

    public void RotateX(float value)
    {
        _currentRotateX = Mathf.Clamp(_currentRotateX + value, _minHeadAngle, _maxHeadAngle);
        _head.localEulerAngles = new Vector3(_currentRotateX, 0, 0);
    }

    public void GetMoveInfo(out Vector3 position, out Vector3 velocity)
    {
        position = transform.position;
        velocity = _rigidbody.linearVelocity;
    }

    public void Jump() {
        if (_checkFly.isFly) return;
        if(Time.time - _jumpTime < _jumpDelay) return;

        _jumpTime = Time.time;
        _rigidbody.AddForce(0,_jumpForce,0, ForceMode.VelocityChange);
    }
}
