using UnityEngine;
namespace SERESESTUDIO.Systems.PhaseSystem
{
    public class PhaseManager : MonoBehaviour
    {
        private static PhaseMode _PhaseMode;
        public enum PhaseMode { Init, Cinematic, Gameplay, Pause, GameOver }
        /// <summary>
        /// Cambia el modo de fase del juego.
        /// </summary>
        /// <param name="phaseMode"></param>
        public void SetPhaseMode(PhaseMode phaseMode)
        {
            _PhaseMode = phaseMode;
        }
        private void Update()
        {
            switch (_PhaseMode)
            {
                case PhaseMode.Init:
                    Init();
                    break;
                case PhaseMode.Cinematic:
                    Cinematic();
                    break;
                case PhaseMode.Gameplay:
                    Gameplay();
                    break;
                case PhaseMode.Pause:
                    Pause();
                    break;
                case PhaseMode.GameOver:
                    GameOver();
                    break;
            }
        }
        private void FixedUpdate()
        {
            if (_PhaseMode == PhaseMode.Gameplay)
            {
                FixedGameplay();
            }
        }
        public virtual void Init() {}
        public virtual void Cinematic() {}
        public virtual void Gameplay() {}
        public virtual void FixedGameplay () {}
        public virtual void Pause() {}
        public virtual void GameOver() {}
    }
}