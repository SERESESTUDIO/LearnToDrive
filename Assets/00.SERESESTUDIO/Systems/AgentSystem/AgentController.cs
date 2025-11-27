using UnityEngine;
using SERESESTUDIO.Systems.PhaseSystem;
using UnityEngine.Events;
using System;
namespace SERESESTUDIO.Systems.AgentSystem
{
    public class AgentController : PhaseManager
    {
        public AgentMode agentMode => _agentMode;
        public AgentEvent updateEvents => _updateEvents;
        public AgentEvent fixedUpdateEvents => _fixedUpdateEvents;

        [SerializeField]
        private AgentMode _agentMode;
        [SerializeField]
        private AgentEvent _updateEvents;
        [SerializeField]
        private AgentEvent _fixedUpdateEvents;
        public enum AgentMode { Static, Move, Crash, Reset }
        public override void Gameplay()
        {
            base.Gameplay();
            switch(_agentMode)
            {
                case AgentMode.Static:
                    _updateEvents.staticEvent.Invoke();
                    break;
                case AgentMode.Move:
                    _updateEvents.moveEvent.Invoke();
                    break;
                case AgentMode.Crash:
                    _updateEvents.crashEvent.Invoke();
                    break;
                case AgentMode.Reset:
                    _updateEvents.resetEvent.Invoke();
                    break;
            }
        }
        public override void FixedGameplay()
        {
            base.FixedGameplay();
            switch(_agentMode)
            {
                case AgentMode.Static:
                    _fixedUpdateEvents.staticEvent.Invoke();
                    break;
                case AgentMode.Move:
                    _fixedUpdateEvents.moveEvent.Invoke();
                    break;
                case AgentMode.Crash:
                    _fixedUpdateEvents.crashEvent.Invoke();
                    break;
                case AgentMode.Reset:
                    _fixedUpdateEvents.resetEvent.Invoke();
                    break;
            }
        }
    }
    [Serializable]
    public class AgentEvent
    {
        public UnityEvent staticEvent;
        public UnityEvent moveEvent;
        public UnityEvent crashEvent;
        public UnityEvent resetEvent;
    }
}