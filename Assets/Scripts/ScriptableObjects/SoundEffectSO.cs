using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewSoundEffect", menuName = "Audio/New Sound Effect")]
    public class SoundEffectSO : ScriptableObject
    {
        [SerializeField] private AudioClip[] clips;
        public float volume = 1.0f;
        public float pitch = 1.0f;

        public AudioSource Play(AudioSource audioSource = null)
        {
            if(clips.Length == 0)
            {
                return null;
            }

            var source = audioSource;

            if(source == null)
            {
                var _obj = new GameObject("Sound", typeof(AudioSource));
                source = _obj.GetComponent<AudioSource>();
            }
            
            source.clip = clips[0];
            source.volume = volume;
            source.pitch = Random.Range(pitch-0.2f, pitch+0.2f);

            source.Play();

            Destroy(source.gameObject, source.clip.length / source.pitch);

            return source;
        }

    }

}