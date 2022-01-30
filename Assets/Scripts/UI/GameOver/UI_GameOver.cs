using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.UI.GameOver
{
    public sealed class UI_GameOver : MonoBehaviour
    {
        [SerializeField] private IntEvent onPizzaDeliveredChange = default;
        [SerializeField] private IntEvent onPizzaDeliveredMaximumChange = default;
        [SerializeField] private GameEvent onGameOver = default;
        [SerializeField] private GameEvent onRestartGame = default;
        [SerializeField] private GameEvent onBackToMenu = default;
        [SerializeField] private GameObject panelGameOver;
        private TextMeshProUGUI pizzaDeliveredText;
        private TextMeshProUGUI maximumPizzaDeliveredText;
        private int pizzaDelivered = 0;
        private int pizzaDeliveredMaximum = 0;

        private void OnEnable() 
        {
            onGameOver.onGameListener += EndGame;
            onPizzaDeliveredChange.onInt += SetPizzaDelivered;
            onPizzaDeliveredMaximumChange.onInt += SetPizzaDeliveredMaximum;
        }

        private void OnDisable() 
        {
            onGameOver.onGameListener -= EndGame;
            onPizzaDeliveredChange.onInt -= SetPizzaDelivered;
            onPizzaDeliveredMaximumChange.onInt -= SetPizzaDeliveredMaximum;
        }

        private void Awake() 
        {
            panelGameOver.SetActive(true);
            Button playAgainButton = GameObject.FindGameObjectWithTag("playAgainButton").GetComponent<Button>();
            playAgainButton.onClick.AddListener(PlayAgain);

            Button quitToMenuButton = GameObject.FindGameObjectWithTag("quitToMenuButton").GetComponent<Button>();
            quitToMenuButton.onClick.AddListener(QuitToMenu);

            pizzaDeliveredText = GameObject.FindGameObjectWithTag("pizzaDeliveredGameOverText").GetComponent<TextMeshProUGUI>();
            maximumPizzaDeliveredText = GameObject.FindGameObjectWithTag("maximumPizzaDeliveredText").GetComponent<TextMeshProUGUI>();
            panelGameOver.SetActive(false);
        }

        private void EndGame()
        {
            panelGameOver.SetActive(true);
            pizzaDeliveredText.text = string.Concat("Você entregou ", pizzaDelivered, " pizzas");
        }

        private void PlayAgain() => onRestartGame.Raise();

        private void QuitToMenu() => onBackToMenu.Raise();

        private void SetPizzaDelivered(int delivered)
        {
            pizzaDelivered = delivered;
        }

        private void SetPizzaDeliveredMaximum(int maximum)
        {
            pizzaDeliveredMaximum = maximum;
            maximumPizzaDeliveredText.text = string.Concat("Seu máximo foi ", pizzaDeliveredMaximum, " pizzas");
        }
    }
}