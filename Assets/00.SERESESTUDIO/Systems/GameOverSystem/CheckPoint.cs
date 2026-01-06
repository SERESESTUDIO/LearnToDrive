using UnityEngine;

namespace SERESESTUDIO.Systems.GameOverSystem
{
    public class CheckPoint : MonoBehaviour
    {
        private GameOverManager _gameOverManager;
        private int _myIndex;

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.tag == "Player")
            {
                _gameOverManager.SetCheckActive(_myIndex);
            }
        }
        public void SetGameOverManager(GameOverManager manager)
        {
            _gameOverManager = manager;
        }
        public void SetIndex(int index)
        {
            _myIndex = index;
        }
    }
}