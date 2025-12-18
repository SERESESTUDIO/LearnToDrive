using UnityEngine;
namespace  SERESESTUDIO.Systems.PhaseSystem
{
    public class ChangePhaseMode : MonoBehaviour
    {
        public PhaseController phaseController => _phaseController;
        [SerializeField]
        private PhaseController _phaseController;
        public void SetModeByString(string phaseMode)
        {
            switch(phaseMode)
            {
                case "Init":
                _phaseController.SetPhaseMode(PhaseManager.PhaseMode.Init);
                    break;
                case "Cinematic":
                    _phaseController.SetPhaseMode(PhaseManager.PhaseMode.Cinematic);
                    break;
                case "Gameplay":
                    _phaseController.SetPhaseMode(PhaseManager.PhaseMode.Gameplay);
                    break;
                case "Pause":
                    _phaseController.SetPhaseMode(PhaseManager.PhaseMode.Pause);
                    break;
                case "GameOver":
                    _phaseController.SetPhaseMode(PhaseManager.PhaseMode.GameOver);
                    break;
            }
        }
    }
}