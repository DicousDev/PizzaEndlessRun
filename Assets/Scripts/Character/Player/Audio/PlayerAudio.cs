using UnityEngine;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.Character.Player.Audio
{
    public sealed class PlayerAudio : MonoBehaviour
    {
        [SerializeField] private GameEvent onPlayerIsJump = default;
        [SerializeField] private AudioEvent onAudioSfx = default;
        [SerializeField] private AudioClip jumpSfx = default;

        private void OnEnable() 
        {
            onPlayerIsJump.onGameListener += Jump;
        }

        private void OnDisable() 
        {
            onPlayerIsJump.onGameListener -= Jump;
        }

        private void Jump()
        {
            onAudioSfx.Raise(jumpSfx);
        }
    }
}
