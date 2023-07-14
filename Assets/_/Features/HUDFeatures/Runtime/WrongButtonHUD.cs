using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.Commands.TransformerRule;
using DG.Tweening;
using UnityEngine;


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

        private void OnGUI()
        {
            if (GUILayout.Button("DoShake")) Animation();
        }

        #endregion

        
        #region Main Methods

        private void Animation()
        {
            _sequence?.Kill();
            
            transform.position = _basePos;
            transform.rotation = _baseRot;

            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOShakeRotation(1f, 10f));
            _sequence.Insert(0, transform.DOShakePosition(1f, 10f));
        }
        
        #endregion

        #region Private and Protected

        private Sequence _sequence;
        
        private Vector3 _basePos;
        private Quaternion _baseRot;

        #endregion
    }
}
