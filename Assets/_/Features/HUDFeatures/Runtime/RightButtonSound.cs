using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HUDFeature.Runtime
{
    public class RightButtonSound : MonoBehaviour
    {
        #region Public Members
        #endregion


        #region Unity API

        public void PlayWinSound()
        {
            int randInt = Random.Range(0, _audioClips.Count);
            _audioSource.clip = _audioClips[randInt];
            _audioSource.Play();
        }
        #endregion


        #region Private and Protected

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private List<AudioClip> _audioClips;

        #endregion
    }
}
