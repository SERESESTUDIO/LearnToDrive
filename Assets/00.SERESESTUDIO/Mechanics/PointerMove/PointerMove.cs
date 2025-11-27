using SERESESTUDIO.Systems.ControlSystem;
using SERESESTUDIO.Systems.DrawSystem;
using UnityEngine;

public class PointerMove : MonoBehaviour
{
    public Rigidbody rBody => _rBody;
    public float smoothAcceleration => _smoothAcceleration;
    public float smoothBrake => _smoothBrake;
    public float smoothRotation => _smoothRotation;
    public float range => _range;

    private ControlManager _controlManager;
    private DrawSystem _drawSystem;
    private bool _reverse;
    private bool _brake;
    private float _rotation;
    [SerializeField]
    private float _acceleration = 0f;

    [SerializeField]
    private Rigidbody _rBody;
    [SerializeField]
    private float _smoothAcceleration;
    [SerializeField]
    private float _smoothBrake;
    [SerializeField]
    private float _smoothRotation;
    [SerializeField]
    private float _range;
    public void Action()
    {
        if(!_controlManager && GameObject.FindAnyObjectByType<ControlManager>())
        {
            _controlManager = GameObject.FindAnyObjectByType<ControlManager>();
        }
        if(!_drawSystem && GameObject.FindAnyObjectByType<DrawSystem>())
        {
            _drawSystem = GameObject.FindAnyObjectByType<DrawSystem>();
        }
        if(_controlManager && _drawSystem)
        {
            _controlManager.setRawAcceleration(_acceleration);
            _reverse = _controlManager.GetReverseDirection();
            _brake = _controlManager.GetBrake();
        }
    }
    public void FixedAction()
    {
        if(_controlManager)
        {
            if(_reverse)
            {
                _acceleration = Mathf.Lerp(_acceleration, -_controlManager.GetRawSpeed() / 6f, Time.fixedDeltaTime * _smoothAcceleration);
            }
            else
            {
                _acceleration = Mathf.Lerp(_acceleration, _controlManager.GetRawSpeed() / 6f, Time.fixedDeltaTime * _smoothAcceleration);
            }
            if(_brake)
            {
                _acceleration = Mathf.Lerp(_acceleration, 0, Time.fixedDeltaTime * _smoothBrake);
            }
            _rBody.transform.Translate(-Vector3.forward * _acceleration * Time.fixedDeltaTime, Space.Self);

            Vector3 lastPoint = _drawSystem.GetLastPoint();
            if(lastPoint != Vector3.zero && _acceleration > 1 && !_reverse)
            {
                Vector3 direction = _rBody.transform.position - lastPoint;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                Vector3 rotation = Quaternion.Lerp(_rBody.transform.rotation, lookRotation, Time.fixedDeltaTime * _smoothRotation).eulerAngles;
                _rBody.transform.rotation = Quaternion.Euler(0, rotation.y, 0);

                float distance = (_rBody.transform.position - lastPoint).magnitude;
                if(distance < _range)
                {
                    _drawSystem.RemoveLastPoint();
                }
            }
            else if (lastPoint != Vector3.zero && _acceleration < -1 && _reverse)
            {
                Vector3 direction = lastPoint - _rBody.transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                Vector3 rotation = Quaternion.Lerp(_rBody.transform.rotation, lookRotation, Time.fixedDeltaTime * _smoothRotation).eulerAngles;
                _rBody.transform.rotation = Quaternion.Euler(0, rotation.y, 0);

                float distance = (_rBody.transform.position - lastPoint).magnitude;
                if(distance < _range)
                {
                    _drawSystem.RemoveLastPoint();
                }
            }
        }
    }
}
