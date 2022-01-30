using UnityEngine;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.Manager
{
    public sealed class SceneManager : MonoBehaviour
    {
        private enum SceneGame { Menu = 0, Game = 1 };
        [SerializeField] private GameEvent onMenuToGame = default;
        [SerializeField] private GameEvent onRestartGame = default;
        [SerializeField] private GameEvent onBackToMenu = default;

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
            ChangeScene(SceneGame.Game);
        }

        private void RestartScene()
        {
            Time.timeScale = 1;
            ChangeScene(SceneGame.Game);
        }

        private void ToMenu()
        {
            Time.timeScale = 1;
            ChangeScene(SceneGame.Menu);
        }

        private void ChangeScene(SceneGame scene)
        {
            int index = (int)scene;
            UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        }
    }
}
