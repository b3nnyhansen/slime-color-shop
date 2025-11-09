using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeColorShop
{
    public abstract class BaseSceneManager : MonoBehaviour
    {
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void LoadScene(SceneNameEnum sceneNameEnum)
        {
            LoadScene((int)sceneNameEnum);
        }
    }
}
