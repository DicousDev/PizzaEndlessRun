using UnityEngine;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.Manager
{
    public sealed class GameManager : MonoBehaviour
    {
        private int coin = 0;
        [SerializeField] private IntEvent onCoinCollect = default;
        [SerializeField] private IntEvent onCoinChange = default;


        private int pizzas = 0;
        [SerializeField] private IntEvent onAddPizza = default;
        [SerializeField] private IntEvent onRemovePizza = default;
        [SerializeField] private IntEvent onPizzaChange = default;


        private int pizzasDelivered = 0;
        [SerializeField] private GameEvent onPizzaDelivered = default;
        [SerializeField] private IntEvent onPizzaDeliveredChange = default;

        private void OnEnable() 
        {
            onCoinCollect.onInt += AddCoin;
            onAddPizza.onInt += AddPizza;
            onRemovePizza.onInt += RemovePizza;
            onPizzaDelivered.onGameListener += DeliveredPizza;
        }

        private void OnDisable() 
        {
            onCoinCollect.onInt -= AddCoin;
            onAddPizza.onInt -= AddPizza;
            onRemovePizza.onInt -= RemovePizza;
            onPizzaDelivered.onGameListener -= DeliveredPizza;
        }

        private void Start() 
        {
            onCoinChange.Raise(coin);
            onPizzaChange.Raise(pizzas);
            onPizzaDeliveredChange.Raise(pizzasDelivered);
        }

        private void AddCoin(int amount)
        {
            coin += amount;
            onCoinChange.Raise(coin);
        }

        private void AddPizza(int amount)
        {
            pizzas += amount;
            onPizzaChange.Raise(pizzas);
        }

        private void RemovePizza(int amount)
        {
            pizzas -= amount;

            if(pizzas < 0)
            {
                pizzas = 0;
            }

            onPizzaChange.Raise(pizzas);
        }

        private void AddPizzaDelivered(int amount)
        {
            pizzasDelivered += amount;
            onPizzaDeliveredChange.Raise(pizzasDelivered);
        }

        private void DeliveredPizza()
        {
            if(pizzas <= 0) return;

            RemovePizza(1);
            AddPizzaDelivered(1);
        }
    }
}