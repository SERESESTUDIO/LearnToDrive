using System;
using UnityEngine;
namespace SERESESTUDIO.UI
{
    public class CameraMenu : MonoBehaviour
    {
        public Transform cameraIn => _camera;
        public Transform container => _container;
        public Vector2 ocilationRange => _ocilationRange;
        public CameraMenuRoute[] routes => _routes;

        [SerializeField]
        private int _index;
        private int _saveInt;
        private int _indexRoute;
        private bool _active;

        [SerializeField]
        private Transform _camera;
        [SerializeField]
        private Transform _container;
        [SerializeField]
        private Vector2 _ocilationRange = new Vector2(0.1f, 0.1f);
        [SerializeField]
        private CameraMenuRoute[] _routes;
        private void FixedUpdate()
        {
            SetOcilation();
            if(_active) SetRoute(_index);
            if(_index != _saveInt)
            {
                _active = true;
                _indexRoute = 0;
                _saveInt = _index;
            }
        }
        private void SetRoute(int index)
        {
            if(_indexRoute < _routes[index].points.Length)
            {
                float distance = (routes[index].points[_indexRoute].transform.position - _container.transform.position).magnitude;
                float finalRange = (_indexRoute == routes[index].points.Length - 1) ? routes[index].lastRange : routes[index].range;
                if(distance <= finalRange)
                {
                    if(_indexRoute == routes[index].points.Length - 1)
                    {
                        _active = false;
                    }
                    _indexRoute += (_indexRoute + 1 < routes[index].points.Length) ? 1 : 0;
                }
                else 
                {
                    _container.transform.position = Vector3.LerpUnclamped(_container.transform.position, routes[index].points[_indexRoute].transform.position, Time.fixedDeltaTime * routes[index].smooth);
                    _container.transform.rotation = Quaternion.Slerp(_container.transform.rotation, routes[index].points[_indexRoute].transform.rotation, Time.fixedDeltaTime * routes[index].smooth);
                }
            } else
            {
                _indexRoute = 0;
            }
        }

        private void SetOcilation()
        {
            _camera.localPosition = new Vector3(
                Mathf.Sin(Time.time) * _ocilationRange.x * 0.1f,
                Mathf.Sin(Time.time * 1.5f) * _ocilationRange.y * 0.1f,
                _camera.localPosition.z
            );
        }
        public void SetIndex(int index)
        {
            _index = index;
        }
        public void setPosition()
        {
            if(_index == 1)
            {
                _index = 0;
            }
            else if(_index == 2)
            {
                _index = 3;
            }
            else if(_index == 4)
            {
                _index = 5;
            }
        }
    }
    [Serializable]
    public class CameraMenuRoute
    {
        public string name;
        public float smooth;
        public float range;
        public float lastRange;
        public Transform[] points;
    }
}
