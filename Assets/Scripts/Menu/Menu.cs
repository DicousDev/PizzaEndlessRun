using UnityEngine;
using UnityEngine.UI;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.Menu
{
    public sealed class Menu : MonoBehaviour
    {
        [SerializeField] private GameEvent onMenuToGame = default;

        private void Awake()
        {
            Button playGame = GameObject.FindGameObjectWithTag("playGame").GetComponent<Button>();
            playGame.onClick.AddListener(PlayGame);

            Button quitGame = GameObject.FindGameObjectWithTag("quitGame").GetComponent<Button>();
            quitGame.onClick.AddListener(QuitGame);
        }

        public void PlayGame() => onMenuToGame.Raise();

        public void QuitGame() => Application.Quit();
    }
}
