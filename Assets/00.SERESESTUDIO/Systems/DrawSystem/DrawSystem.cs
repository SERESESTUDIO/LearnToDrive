using System.Collections.Generic;
using SERESESTUDIO.Systems.PhaseSystem;
using UnityEngine;
using UnityEngine.InputSystem;
namespace SERESESTUDIO.Systems.DrawSystem
{
    public class DrawSystem : PhaseManager
    {
        public InputActionReference positionAction => _positionAction;
        public InputActionReference touchAction => _touchAction;
        public LineRenderer lineRenderer => _lineRenderer;
        public float screenOffset => _screenOffset;
        public float yOffset => _yOffset;
        [SerializeField]
        private List<Vector3> _points = new List<Vector3>();

        private Vector2 _touchPosition;
        private bool _touchScreen;
        private bool _touchTrigger;

        [SerializeField]
        private InputActionReference _positionAction;
        [SerializeField]
        private InputActionReference _touchAction;
        [SerializeField]
        private LineRenderer _lineRenderer;
        [SerializeField][Range(0f,1f)]
        private float _screenOffset;
        [SerializeField]
        private float _yOffset;
        public override void Gameplay()
        {
            base.Gameplay();
            _touchPosition = _positionAction.action.ReadValue<Vector2>();
            _touchScreen = _touchAction.action.IsPressed();
            Vector2 screenSize = new Vector2(Screen.width, Screen.height);
            if(_touchScreen && _touchPosition.y > screenSize.y * _screenOffset)
            {
                if(!_touchTrigger) 
                {
                    _points.Clear();
                    _touchTrigger = true;
                }
                AddPoints();
            }
            else
            {
                _touchTrigger = false;
            }
            _lineRenderer.positionCount = _points.Count;
            _lineRenderer.SetPositions(_points.ToArray());
        }
        private void AddPoints()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(_touchPosition);
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 point = hit.point + new Vector3(0,_yOffset,0);
                _points.Add(point);
            }
        }
        /// <summary>
        /// Obtiner el último punto dibujado
        /// </summary>
        /// <returns></returns>
        public Vector3 GetLastPoint()
        {
            if(_points.Count > 0)
            {
                return _points[0];
            }
            return Vector3.zero;
        }
        /// <summary>
        /// Eliminar el último punto dibujado
        /// </summary>
        public void RemoveLastPoint()
        {
            if(_points.Count > 0)
            {
                _points.RemoveAt(0);
            }
        }
    }
}