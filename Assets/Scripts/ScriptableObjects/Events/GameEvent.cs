using System;
using UnityEngine;

namespace EndlessRunner.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "ScriptableObjects/Events/GameEvent")]
    public sealed class GameEvent : ScriptableObject
    {
        public event Action onGameListener;

        public void Raise()
        {
            onGameListener?.Invoke();
        }
    }
}
