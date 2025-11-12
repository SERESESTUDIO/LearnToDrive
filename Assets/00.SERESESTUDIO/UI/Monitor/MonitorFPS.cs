using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SERESESTUDIO.UI.Monitor
{
    public class MonitorFPS : MonoBehaviour
    {
        public TMP_Text fpsText => _fpsText;
        public float fpsInterval => _fpsInterval;

        private int _lowFpsCounter = 100000;
        private int _mediumFpsCounter = 0;
        private int _highFpsCounter = 0;
        private List<int> _fpsList = new List<int>();

        private float _timer = 0f;

        [SerializeField]
        private TMP_Text _fpsText;
        [SerializeField]
        private float _fpsInterval;

        private void Update()
        {
            /*float fps = 1.0f / Time.unscaledDeltaTime;
            _fpsText.text = "FPS: " + Mathf.Ceil(fps).ToString();*/
            if(_timer == 0)
            {
                float fps = 1.0f / Time.unscaledDeltaTime;
                _fpsList.Add(int.Parse(Mathf.Ceil(fps).ToString()));

                int totalFPS = 0;
                foreach(int frameRate in _fpsList)
                {
                    totalFPS += frameRate;
                }
                _mediumFpsCounter = totalFPS / _fpsList.Count;

                if (_lowFpsCounter > Mathf.CeilToInt(fps))
                {
                    _lowFpsCounter = Mathf.CeilToInt(fps);
                }
                
                if( _highFpsCounter < Mathf.CeilToInt(fps))
                {
                    _highFpsCounter = Mathf.CeilToInt(fps);
                }
                // Escribe el valor en texto
                _fpsText.text = "act-FPS: " + Mathf.Ceil(fps).ToString() + "\n" +
                                "low-FPS: " + _lowFpsCounter.ToString() + "\n" +
                                "med-FPS: " + _mediumFpsCounter.ToString() + "\n" +
                                "high-FPS: " + _highFpsCounter.ToString();
            }
            _timer += Time.deltaTime;
            if(_timer >= _fpsInterval)
            {
                _timer = 0f;
            }
        }
    }
}
