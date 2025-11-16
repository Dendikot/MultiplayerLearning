using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class EnemyCharacter : Character
{
    [SerializeField] private Transform _head;
    public Vector3 targetPosition { get; private set; } = Vector3.zero;
    private float _velocityMagnitude = 0;

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (_velocityMagnitude > .1f)
        {
            float maxDistance = _velocityMagnitude * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, maxDistance);
        } 
        else
        {
            transform.position = targetPosition;
        }
    }

    public void SetMovement(in Vector3 position, in Vector3 velocity, in float averageInterval)
    {
        targetPosition = position + (velocity * averageInterval);
        _velocityMagnitude = velocity.magnitude;
        this.velocity = velocity;
    }

    public void SetRotateXY(float x, float y)
    {
        _head.localEulerAngles = new Vector3(x, y, 0);
    }

    public void SetRotateX(float x)
    {
        
        _head.localEulerAngles = new Vector3(x, 0, 0);
    }

    public void SetRotateY(float y)
    {
        _head.localEulerAngles = new Vector3(0, y, 0);
    }

    public void SetSpeed(float value) => speed = value;
}
