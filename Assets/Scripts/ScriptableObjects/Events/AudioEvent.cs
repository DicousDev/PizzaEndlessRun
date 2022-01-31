using System;
using UnityEngine;

namespace EndlessRunner.ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "AudioEvent", menuName = "ScriptableObjects/Events/AudioEvent")]
    public sealed class AudioEvent : ScriptableObject
    {
        public event Action<AudioClip> onAudioClip;

        public void Raise(AudioClip clip)
        {
            onAudioClip?.Invoke(clip);
        }
    }
}
