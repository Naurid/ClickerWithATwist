using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HUDFeature.Runtime
{
    public class WrongButtonHUD : MonoBehaviour
    {
        #region Public Members
        #endregion


        #region Unity API

        private void Start()
        {
            _basePos = transform.position;
            _baseRot = transform.rotation;
        }

        #endregion

        
        #region Main Methods
        
        public void Animation()
        {
            _sequence?.Kill();
            
            transform.position = _basePos;
            transform.rotation = _baseRot;

            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOShakeRotation(_shakeDuration, _shakeStrength));
            _sequence.Insert(0, transform.DOShakePosition(_shakeDuration, _shakeStrength));
        }
        
        #endregion

        #region Private and Protected

        private Sequence _sequence;
        
        private Vector3 _basePos;
        private Quaternion _baseRot;

        [SerializeField] private float _shakeDuration;
        [SerializeField] private float _shakeStrength;

        #endregion
    }
}
