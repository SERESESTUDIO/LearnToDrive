using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace SERESESTUDIO.UI.Monitor
{
    public class OpenMonitorSystem : MonoBehaviour
    {
        public GameObject container => _container;
        public GameObject topObject => _topObject;
        public GameObject bottomObject => _bottomObject;
        public InputActionReference controlInput => _controlInput;
        public InputActionReference altInput => _altInput;
        public InputActionReference monitorInput => _monitorInput;

        [SerializeField]
        private int _touchCounter = 0;
        private bool _active = false;

        [SerializeField]
        private GameObject _container;
        [SerializeField]
        private GameObject _topObject;
        [SerializeField]
        private GameObject _bottomObject;
        [SerializeField]
        private InputActionReference _controlInput;
        [SerializeField]
        private InputActionReference _altInput;
        [SerializeField]
        private InputActionReference _monitorInput;

        private void Update()
        {
            if (_controlInput.action.IsPressed() && _altInput.action.IsPressed() && _monitorInput.action.IsPressed())
            {
                _container.SetActive(true);
                _topObject.SetActive(false);
                _bottomObject.SetActive(false);
            }

            if(_touchCounter >= 10)
            {
                _container.SetActive(true);
                _topObject.SetActive(false);
                _bottomObject.SetActive(false);
                _touchCounter = 0;
            }
        }
        public void TopTouch()
        {
            if (!_active)
            {
                _touchCounter++;
                _active = !_active;
            }
            else
            {
                _touchCounter = 0;
                _active = false;
            }
        }
        public void BottomTouch()
        {
            if (_active)
            {
                _touchCounter++;
                _active = !_active;
            }
            else
            {
                _touchCounter = 0;
                _active = false;
            }
        }
    }
}
