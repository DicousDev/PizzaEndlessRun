using UnityEngine;
using UnityEngine.UI;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.UI.Pause
{
    public sealed class UI_Pause : MonoBehaviour
    {
        [SerializeField] private GameEvent onGamePaused = default;
        [SerializeField] private GameEvent onResumeGame = default;
        [SerializeField] private GameObject panelPause;

        private void Awake()
        {
            panelPause.SetActive(true);

            Button pauseButton = GameObject.FindGameObjectWithTag("pauseButton").GetComponent<Button>();
            pauseButton.onClick.AddListener(PauseGame);

            Button resumeButton = GameObject.FindGameObjectWithTag("resumeButton").GetComponent<Button>();
            resumeButton.onClick.AddListener(ResumeGame);

            panelPause.SetActive(false);
        }

        private void PauseGame() 
        {
            panelPause.SetActive(true);
            onGamePaused.Raise();
        }

        private void ResumeGame()
        {
            panelPause.SetActive(false);
            onResumeGame.Raise();
        }
    }
}