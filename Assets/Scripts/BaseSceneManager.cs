using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SlimeColorShop
{
    public abstract class BaseSceneManager : MonoBehaviour
    {
        private AspectRatioFitter aspectRatioFitter;
        

        void Start()
        {
            DoStartEvent();
        }

        protected virtual void DoStartEvent()
        {
            float screenRatio = (float) Screen.width / Screen.height;

            aspectRatioFitter = GetComponent<AspectRatioFitter>();
            aspectRatioFitter.aspectRatio = screenRatio;
        }

        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void LoadScene(SceneNameEnum sceneNameEnum)
        {
            LoadScene((int)sceneNameEnum);
        }

        public virtual void UpdateSceneLanguage()
        {
            
        }
    }
}
