using UnityEngine;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.Manager
{
    public sealed class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioEvent onAudioSfx = default;

        private void OnEnable() 
        {
            onAudioSfx.onAudioClip += PlaySfx;
        }

        private void OnDisable() 
        {
            onAudioSfx.onAudioClip -= PlaySfx;
        }

        private void PlaySfx(AudioClip clip)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}