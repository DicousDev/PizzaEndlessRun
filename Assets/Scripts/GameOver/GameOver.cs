using UnityEngine;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.GameOver
{
    public sealed class GameOver : MonoBehaviour
    {   
        [SerializeField] private GameEvent onGameOver = default;

        private void OnEnable() 
        {
            onGameOver.onGameListener += EndGame;
        }

        private void OnDisable() 
        {
            onGameOver.onGameListener -= EndGame;
        }

        private void EndGame() => PauseGame();

        private void PauseGame()
        {
            Time.timeScale = 0;
        }
    }
}