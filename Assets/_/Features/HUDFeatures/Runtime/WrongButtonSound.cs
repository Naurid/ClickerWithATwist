using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HUDFeature.Runtime
{
    public class WrongButtonSound : MonoBehaviour
    {
        #region Public Members
        #endregion


        #region Main Methods

        public void PlayRandomSound()
        {
            int randSound = Random.Range(0, _audioClips.Count);

            _audioSource.clip = _audioClips[randSound];
            _audioSource.Play();
        }
        #endregion


        #region Private and Protected

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private List<AudioClip> _audioClips;

        #endregion
    }
}
