using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class SplashScene : MonoBehaviour
    {
        // [SerializeField]
        // private float holdSceneForSeconds = 2.0f;
        
        [SerializeField]
        private string nextScene = "GameScreen";

        private UIDocument _uiDocument;
        private ProgressBar _progressBar;

        void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
            _progressBar = _uiDocument.rootVisualElement.Q<ProgressBar>("progress-bar");
        }
        
        void Start() {
            StartCoroutine(ShowSplashScreen());
        }

        IEnumerator ShowSplashScreen() {
            // yield return new WaitForSeconds(holdSceneForSeconds);
            // SceneManager.LoadScene(nextScene);
            
            AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Single);
            operation.allowSceneActivation = false;
            
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                 _progressBar.value = progress * 100f;
                 _progressBar.title = $"Loading: {Mathf.RoundToInt(progress * 100)}%";
                 
                if (operation.progress >= 0.9f)
                {
                    operation.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}

