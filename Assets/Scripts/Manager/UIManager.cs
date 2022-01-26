using UnityEngine;
using TMPro;

using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.Manager
{
    public sealed class UIManager : MonoBehaviour
    {
        [SerializeField] private IntEvent onCoinChange = default;
        [SerializeField] private IntEvent onPizzaChange = default;
        [SerializeField] private IntEvent onPizzaDeliveredChange = default;
        private TextMeshProUGUI coinText;
        private TextMeshProUGUI pizzaText;
        private TextMeshProUGUI pizzaDeliveredText;

        private void OnEnable() 
        {
            onCoinChange.onInt += UpdateCoinText;
            onPizzaChange.onInt += UpdatePizzaText;
            onPizzaDeliveredChange.onInt += UpdatePizzaDeliveredText;
        }

        private void OnDisable() 
        {
            onCoinChange.onInt -= UpdateCoinText;
            onPizzaChange.onInt -= UpdatePizzaText;
            onPizzaDeliveredChange.onInt -= UpdatePizzaDeliveredText;
        }

        private void Awake() 
        {
            coinText = GameObject.FindGameObjectWithTag("coinText").GetComponent<TextMeshProUGUI>();
            pizzaText = GameObject.FindGameObjectWithTag("pizzaText").GetComponent<TextMeshProUGUI>();
            pizzaDeliveredText = GameObject.FindGameObjectWithTag("pizzaDeliveredText").GetComponent<TextMeshProUGUI>();
        }

        private void UpdateCoinText(int total)
        {
            coinText.text = total.ToString();
        }

        private void UpdatePizzaText(int total)
        {
            pizzaText.text = string.Concat("x", total.ToString());
        }

        private void UpdatePizzaDeliveredText(int total)
        {
            pizzaDeliveredText.text = string.Concat("Pizzas entregues: ", total);
        }
    }
}