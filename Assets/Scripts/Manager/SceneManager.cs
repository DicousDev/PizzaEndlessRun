using System.Collections;
using UnityEngine;
using EndlessRunner.Utils;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.Manager
{
    public sealed class SceneManager : MonoBehaviour
    {
        private enum SceneGame { Menu = 0, Game = 1 };
        public static SceneManager instance;
        [SerializeField] private GameEvent onMenuToGame = default;
        [SerializeField] private GameEvent onRestartGame = default;
        [SerializeField] private GameEvent onBackToMenu = default;
        [SerializeField] private Fade fade;

        private void Awake() 
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void OnEnable() 
        {
            onMenuToGame.onGameListener += ToGame;
            onRestartGame.onGameListener += RestartScene;
            onBackToMenu.onGameListener += ToMenu;
        }

        private void OnDisable() 
        {
            onMenuToGame.onGameListener -= ToGame;
            onRestartGame.onGameListener -= RestartScene;
            onBackToMenu.onGameListener -= ToMenu;
        }

        private void ToGame()
        {
            StartCoroutine(ChangeScene(SceneGame.Game));
        }

        private void RestartScene()
        {
            StartCoroutine(ChangeScene(SceneGame.Game));
        }

        private void ToMenu()
        {
            StartCoroutine(ChangeScene(SceneGame.Menu));
        }

        private IEnumerator ChangeScene(SceneGame scene)
        {
            int index = (int)scene;
            yield return StartCoroutine(LoadSceneAsync(index));
            Time.timeScale = 1;
        }

        private IEnumerator LoadSceneAsync(int index)
        {
            yield return StartCoroutine(fade.FadeIn());
            AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(index);
            
            while(operation.isDone == false)
            {
                yield return null;
            }

            yield return StartCoroutine(fade.FadeOut());
        }
    }
}
