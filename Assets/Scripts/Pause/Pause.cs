using UnityEngine;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.Pause
{
    public sealed class Pause : MonoBehaviour
    {
        [SerializeField] private GameEvent onGamePaused = default;
        [SerializeField] private GameEvent onResumeGame = default;

        private void OnEnable() 
        {
            onGamePaused.onGameListener += PauseGame;
            onResumeGame.onGameListener += ResumeGame;
        }

        private void OnDisable() 
        {
            onGamePaused.onGameListener -= PauseGame;
            onResumeGame.onGameListener -= ResumeGame;
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
        }

        private void ResumeGame()
        {
            Time.timeScale = 1;
        }
    }
}