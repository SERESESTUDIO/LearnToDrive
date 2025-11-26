using System;
using UnityEngine;
using UnityEngine.Events;

namespace SERESESTUDIO.Systems.PhaseSystem
{
    public class PhaseEvents : PhaseManager
    {
        public PhaseEvent init => _init;
        public PhaseEvent cinematic => _cinematic;
        public PhaseEvent gameplay => _gameplay;
        public PhaseEvent pause => _pause;
        public PhaseEvent gameover => _gameover;
        public PhaseEvent fixedGameplay => _fixedGameplay;

        [SerializeField]
        private PhaseEvent _init;
        [SerializeField]
        private PhaseEvent _cinematic;
        [SerializeField]
        private PhaseEvent _gameplay;
        [SerializeField]
        private PhaseEvent _pause;
        [SerializeField]
        private PhaseEvent _gameover;
        [SerializeField]
        private PhaseEvent _fixedGameplay;

        public override void Init()
        {
            base.Init();
            if(!_init.isTrigger) _init.events.Invoke();
            else
            {
                if(!_init.active)
                {
                    _init.events.Invoke();
                    _init.active = true;
                }
            }
            _cinematic.active = false;
            _gameplay.active = false;
            _pause.active = false;
            _gameover.active = false;
            _fixedGameplay.active = false;
        }
        public override void Cinematic()
        {
            base.Cinematic();
            if(!_cinematic.isTrigger) _cinematic.events.Invoke();
            else
            {
                if(!_cinematic.active)
                {
                    _cinematic.events.Invoke();
                    _cinematic.active = true;
                }
            }
            _init.active = false;
            _gameplay.active = false;
            _pause.active = false;
            _gameover.active = false;
            _fixedGameplay.active = false;
        }
        public override void Gameplay()
        {
            base.Gameplay();
            if(!_gameplay.isTrigger) _gameplay.events.Invoke();
            else
            {
                if(!_gameplay.active)
                {
                    _gameplay.events.Invoke();
                    _gameplay.active = true;
                }
            }
            _init.active = false;
            _cinematic.active = false;
            _pause.active = false;
            _gameover.active = false;
        }
        public override void Pause()
        {
            base.Pause();
            if(!_pause.isTrigger) _pause.events.Invoke();
            else
            {
                if(!_pause.active)
                {
                    _pause.events.Invoke();
                    _pause.active = true;
                }
            }
            _init.active = false;
            _cinematic.active = false;
            _gameplay.active = false;
            _gameover.active = false;
            _fixedGameplay.active = false;
        }
        public override void GameOver()
        {
            base.GameOver();
            if(!_gameover.isTrigger) _gameover.events.Invoke();
            else
            {
                if(!_gameover.active)
                {
                    _gameover.events.Invoke();
                    _gameover.active = true;
                }
            }
            _init.active = false;
            _cinematic.active = false;
            _gameplay.active = false;
            _pause.active = false;
            _fixedGameplay.active = false;
        }
        public override void FixedGameplay()
        {
            base.FixedGameplay();
            if(!_fixedGameplay.isTrigger) _fixedGameplay.events.Invoke();
            else
            {
                if(!_fixedGameplay.active)
                {
                    _fixedGameplay.events.Invoke();
                    _fixedGameplay.active = true;
                }
            }
            _init.active = false;
            _cinematic.active = false;
            _pause.active = false;
            _gameover.active = false;
        }
    }
    [Serializable]
    public class PhaseEvent
    {
        public bool isTrigger;
        public UnityEvent events;
        [HideInInspector]
        public bool active;
    }
}
