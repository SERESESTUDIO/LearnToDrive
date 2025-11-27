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

        private Vector3 _saveLookTarget;
        private ControlManager _controlManager;
        [SerializeField]
        private bool _reverse;
        private Transform _target;
        [SerializeField]
        private Vector2 _offset;
        [SerializeField]
        private Vector2 _lookOffset;
        [SerializeField][Range(0f, 10f)]
        private float _smooth;
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
            }
        }
        public override void FixedGameplay()
        {
            base.FixedGameplay();
            if(_target)
            {
                Vector3 positionMultiply = _target.transform.forward * _offset.x;
                Vector3 lookPositionMultiply = _target.transform.forward * _lookOffset.x;
                Vector3 target = _target.position + new Vector3(positionMultiply.x, _offset.y, positionMultiply.z);
                Vector3 lookTarget = _target.position + new Vector3(lookPositionMultiply.x, _lookOffset.y, lookPositionMultiply.z);
                if(_reverse)
                {
                    target = _target.position - new Vector3(positionMultiply.x, -_offset.y, positionMultiply.z);
                    lookTarget = _target.position - new Vector3(lookPositionMultiply.x, -_lookOffset.y, lookPositionMultiply.z);
                }
                _saveLookTarget = lookTarget;
                transform.position = Vector3.Lerp(transform.position, target, _smooth * Time.fixedDeltaTime);
                transform.LookAt(Vector3.Lerp(_saveLookTarget, lookTarget, _smooth * Time.fixedDeltaTime));
            }
        }
    }
}