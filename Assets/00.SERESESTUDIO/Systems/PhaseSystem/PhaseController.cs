using UnityEngine;
namespace SERESESTUDIO.Systems.PhaseSystem
{
    public class PhaseController : MonoBehaviour
    {
        public PhaseManager PhaseManager => _PhaseManager;
        public PhaseManager.PhaseMode phaseMode => _phaseMode;
        [SerializeField]
        private PhaseManager _PhaseManager;
        [SerializeField]
        private PhaseManager.PhaseMode _phaseMode;
        private void Update()
        {
            _PhaseManager.SetPhaseMode(_phaseMode);
        }
        /// <summary>
        /// Cambia el modo de fase del juego.
        /// </summary>
        /// <param name="phaseMode"></param>
        public void SetPhaseMode(PhaseManager.PhaseMode phaseMode)
        {
            _phaseMode = phaseMode;
            _PhaseManager.SetPhaseMode(phaseMode);
        }
        /// <summary>
        /// Cambia el modo de fase del juego usando un string.
        /// </summary>
        /// <param name="phaseMode"></param>
        public void setPhaseModeByString(string phaseMode)
        {
            switch(phaseMode)
            {
                case "Init":
                    _phaseMode = PhaseManager.PhaseMode.Init;
                    SetPhaseMode(PhaseManager.PhaseMode.Init);
                    break;
                case "Cinematic":
                    _phaseMode = PhaseManager.PhaseMode.Cinematic;
                    SetPhaseMode(PhaseManager.PhaseMode.Cinematic);
                    break;
                case "Gameplay":
                    _phaseMode = PhaseManager.PhaseMode.Gameplay;
                    SetPhaseMode(PhaseManager.PhaseMode.Gameplay);
                    break;
                case "Pause":
                    _phaseMode = PhaseManager.PhaseMode.Pause;
                    SetPhaseMode(PhaseManager.PhaseMode.Pause);
                    break;
                case "GameOver":
                    _phaseMode = PhaseManager.PhaseMode.GameOver;
                    SetPhaseMode(PhaseManager.PhaseMode.GameOver);
                    break;
            }
        }

    }
}
