using UnityEngine;
namespace SERESESTUDIO.Definitions
{
    [CreateAssetMenu(fileName = "GameOverDefinition", menuName = "SERESESTUDIO/Definitions/GameOverDefinition")]
    public class GameOverDefinition : ScriptableObject
    {
        public bool lineal;
        public int maxScore;
    }
}
