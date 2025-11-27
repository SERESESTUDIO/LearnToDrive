using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace SERESESTUDIO.Systems.ControlSystem
{
    public class ControlManager : MonoBehaviour
    {
        public TMP_Text speedText => _speedText;
        public TMP_Text reverseText => _reverseText;
        public GameObject changeDirectionObj => _changeDirectionObject;
        public RectTransform speedIndicator => _speedIndicator;
        public float totalSpeed => _totalSpeed;
        public float totalIndicatorRange => _totalIndicatorRange;
        private int _rawSpeed;
        private float _rawAcceleration;
        private bool _reverse;
        private bool _brake;
        private float _saveRawSpeed;
        private bool _activeControls;

        [SerializeField]
        private TMP_Text _speedText;
        [SerializeField]
        private TMP_Text _reverseText;
        [SerializeField]
        private GameObject _changeDirectionObject;
        [SerializeField]
        private RectTransform _speedIndicator;
        [SerializeField]
        private float _totalSpeed;
        [SerializeField]
        private float _totalIndicatorRange;
        private void Update()
        {
            if(_brake)
            {
                _saveRawSpeed = _rawAcceleration - 10f;
                if(_saveRawSpeed < 0)
                {
                    _saveRawSpeed = 0;
                }
                _rawSpeed = (int)_saveRawSpeed;
            }
            if(_rawAcceleration < 0)
            {
                _rawAcceleration = -_rawAcceleration;
            }
            if(_speedIndicator && _rawAcceleration != 0)
            {
                Vector3 rotation = new Vector3(0,0,-(_rawAcceleration * (_totalIndicatorRange / _totalSpeed)));
                _speedIndicator.rotation = Quaternion.Euler(rotation);
                _speedText.text = _rawAcceleration.ToString("0");
                if(_rawAcceleration <= 2)
                {
                    _changeDirectionObject.SetActive(true);
                }
                else
                {
                    _changeDirectionObject.SetActive(false);
                }
            }
        }
        public void setActiveControls(bool active)
        {
            _activeControls = active;
        }
        /// <summary>
        /// Establece el valor de freno.
        /// </summary>
        /// <param name="brake"></param>
        public void setBrake(bool brake)
        {
            _brake = brake;
        }
        /// <summary>
        /// Obtiene el valor de freno.
        /// </summary>
        /// <returns></returns>
        public bool GetBrake()
        {
            return _brake;
        }
        /// <summary>
        /// Invierte la dirección del control.
        /// </summary>
        public void ReverseDirection()
        {
            _reverse = !_reverse;
            if(_reverseText)
            {
                _reverseText.text = _reverse ? "D" : "R";
            }
        }
        /// <summary>
        /// Obtiene el valor de dirección invertida.
        /// </summary>
        /// <returns></returns>
        public bool GetReverseDirection()
        {
            return _reverse;
        }
        /// <summary>
        /// Establece el valor de aceleración.
        /// </summary>
        /// <param name="acceleration"></param>
        public void setRawAcceleration(float acceleration)
        {
            _rawAcceleration = acceleration * 6f;
        }
        /// <summary>
        /// Establece el valor de velocidad.
        /// </summary>
        /// <param name="speed"></param>
        public void SetRawSpeed(int speed)
        {
            if(_activeControls) _rawSpeed = speed;
        }
        /// <summary>
        /// Obtiene el valor de velocidad sin modificar.
        /// </summary>
        /// <returns></returns>
        public int GetRawSpeed()
        {
            return _rawSpeed;
        }
    }
}