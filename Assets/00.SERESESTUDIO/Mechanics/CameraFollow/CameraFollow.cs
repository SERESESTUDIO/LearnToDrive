using SERESESTUDIO.Systems.ControlSystem;
using SERESESTUDIO.Systems.PhaseSystem;
using UnityEngine;
namespace SERESESTUDIO.Mechanics.Camera
{
    public class CameraFollow : PhaseManager
    {
        public Vector2 offset => _offset;
        public Vector2 lookOffset => _lookOffset;
        public float smooth => _smooth;
        public float sideOffset => _sideOffset;

        private Vector3 _saveLookTarget;
        private ControlManager _controlManager;
        private bool _reverse;
        private bool _lookLeft;
        private bool _lookRight;
        private Vector3 _saveOffsetLook;
        private Transform _target;
        [SerializeField]
        private Vector2 _offset;
        [SerializeField]
        private Vector2 _lookOffset;
        [SerializeField][Range(0f, 10f)]
        private float _smooth;
        [SerializeField]
        private float _sideOffset;
        public override void Gameplay()
        {
            base.Gameplay();
            if(!_target && GameObject.FindGameObjectWithTag("Player"))
            {
                _target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            if(!_controlManager && GameObject.FindAnyObjectByType<ControlManager>())
            {
                _controlManager = GameObject.FindAnyObjectByType<ControlManager>();
            }
            if(_controlManager)
            {
                _reverse = _controlManager.GetReverseDirection();
                _lookLeft = _controlManager.GetLookLeft();
                _lookRight = _controlManager.GetLookRight();
            }
        }
        public override void FixedGameplay()
        {
            base.FixedGameplay();
            if(_target)
            {
                Vector3 positionMultiply = _target.transform.forward * _offset.x;
                Vector3 lookPositionMultiply = _target.transform.forward * _lookOffset.x;
                if (_lookLeft)
                {
                    _saveOffsetLook = Vector3.Lerp(_saveOffsetLook, _target.transform.right * _sideOffset, Time.fixedDeltaTime * _smooth);
                }
                else if(_lookRight)
                {
                    _saveOffsetLook = Vector3.Lerp(_saveOffsetLook, -_target.transform.right * _sideOffset, Time.fixedDeltaTime * _smooth);
                }
                else
                {
                    _saveOffsetLook = Vector3.Lerp(_saveOffsetLook, Vector3.zero, Time.fixedDeltaTime * _smooth);
                }
                Vector3 target = _target.position + new Vector3(positionMultiply.x, _offset.y, positionMultiply.z);
                Vector3 lookTarget = _target.position + new Vector3(lookPositionMultiply.x + _saveOffsetLook.x, _lookOffset.y, lookPositionMultiply.z + _saveOffsetLook.z);
                if(_reverse)
                {
                    target = _target.position - new Vector3(positionMultiply.x, -_offset.y, positionMultiply.z);
                    lookTarget = _target.position - new Vector3(lookPositionMultiply.x + _saveOffsetLook.x, -_lookOffset.y, lookPositionMultiply.z + _saveOffsetLook.z);
                }
                _saveLookTarget = lookTarget;
                transform.position = Vector3.Lerp(transform.position, target, _smooth * Time.fixedDeltaTime);
                transform.LookAt(Vector3.Lerp(_saveLookTarget, lookTarget, _smooth * Time.fixedDeltaTime));
            }
        }
    }
}