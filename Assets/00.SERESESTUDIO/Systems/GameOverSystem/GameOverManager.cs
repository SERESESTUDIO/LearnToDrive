using SERESESTUDIO.Definitions;
using SERESESTUDIO.Systems.ControlSystem;
using SERESESTUDIO.Systems.PhaseSystem;
using UnityEngine;
using UnityEngine.Events;
namespace SERESESTUDIO.Systems.GameOverSystem
{
    public class GameOverManager : PhaseManager
    {
        public GameOverDefinition definition => _definition;
        public CheckPoint[] checkPoints => _checkPoints;
        public UnityEvent onFinished => _onFinished;

        private int _progress;
        [SerializeField]
        private float _monitor;
        private ControlManager _controlManager;

        [SerializeField]
        private GameOverDefinition _definition;
        [SerializeField]
        private CheckPoint[] _checkPoints;
        [SerializeField]
        private UnityEvent _onFinished;
        private void Awake()
        {
            _progress = 0;
            for (int i = 0; i < _checkPoints.Length; i++)
            {
                _checkPoints[i].SetGameOverManager(this);
                _checkPoints[i].SetIndex(i);
            }
        }
        public override void Gameplay()
        {
            base.Gameplay();
            if (_controlManager)
            {
                _monitor = _controlManager.GetRawAceleration();
                if (_progress == _checkPoints.Length - 1 && _controlManager.GetRawAceleration() <= 0.9)
                {
                    _onFinished.Invoke();
                }
            }
            else
            {
                _controlManager = FindAnyObjectByType<ControlManager>();
            }
        }
        public void SetCheckActive(int index)
        {
            if (_definition.lineal)
            {
                if (index == _progress + 1)
                {
                    _progress = index;
                }
            }
            else
            {
                _progress = index;
            }
        }
    }
}