using UnityEngine;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.Character.Player.Collision
{
    public sealed class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private IntEvent onAddPizza = default;
        [SerializeField] private GameEvent onPizzaDelivered = default;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("pizza"))
            {
                onAddPizza.Raise(1);
                other.gameObject.SetActive(false);
            }

            if(other.CompareTag("cliente"))
            {
                onPizzaDelivered.Raise();
            }
        }
    }
}
