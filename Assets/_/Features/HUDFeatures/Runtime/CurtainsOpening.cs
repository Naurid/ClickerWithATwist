using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.Commands.TransformerRule;
using DG.Tweening;
using GameManagerFeature.Runtime;
using UnityEngine;

namespace HUDFeature.Runtime
{
    public class CurtainsOpening : MonoBehaviour
    {
        #region Public Members
        #endregion


        #region Unity API

        private void Start()
        {
            _manager = GameManager.m_instance;
        }

        #endregion


        #region Main Methods

        private void OpenCurtains()
        {
            _leftCurtain.DOMove()
            _rightCurtain.DOMove()
        }

        #endregion

        #region Private and Protected

        [SerializeField] private Transform _leftCurtain;
        [SerializeField] private Transform _rightCurtain;

        [SerializeField] private Transform _leftAnchor;
        [SerializeField] private Transform _rightAnchor;
        
        private GameManager _manager;



        #endregion
    }
}
