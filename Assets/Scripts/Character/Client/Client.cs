using UnityEngine;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.Character.Client
{
    public sealed class Client : MonoBehaviour
    {
        [SerializeField] private IntEvent onCoinCollect = default;
        [SerializeField] private IntEvent onPizzaChange = default;
        [SerializeField] private int coinMinimum = 20;
        [SerializeField] private int coinMaximum = 50;
        private int pizzas = 0;

        private void OnEnable() 
        {
            onPizzaChange.onInt += SetPizza;
        }

        private void OnDisable() 
        {
            onPizzaChange.onInt -= SetPizza;
        }

        private void SetPizza(int total)
        {
            pizzas = total;
        }

        private int GetRandomCoin()
        {
            int coin = Random.Range(coinMinimum, coinMaximum);
            return coin;
        }

        private void OnTriggerEnter(Collider other) 
        {
            if(other.CompareTag("Player") && pizzas > 0)
            {
                int coin = GetRandomCoin();
                onCoinCollect.Raise(coin);
            }
        }
    }
}