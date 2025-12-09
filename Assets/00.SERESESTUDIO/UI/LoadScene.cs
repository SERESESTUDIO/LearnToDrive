using UnityEngine;

namespace SERESESTUDIO.UI
{
    public class LoadScene : MonoBehaviour
    {
        public void LoadSceneByName(string sceneName)
        {
            Debug.Log("load scene");
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
