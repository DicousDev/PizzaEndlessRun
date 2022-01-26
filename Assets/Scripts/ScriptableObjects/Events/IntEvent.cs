using System;
using UnityEngine;

namespace EndlessRunner.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "IntEvent", menuName = "ScriptableObjects/Events/IntEvent")]
    public sealed class IntEvent : ScriptableObject
    {
        public event Action<int> onInt;

        public void Raise(int value)
        {
            onInt?.Invoke(value);
        }
    }
}
