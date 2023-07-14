using System;
using System.Collections;
using System.Collections.Generic;
using GameManagerFeature.Runtime;
using UnityEngine;

namespace HUDFeature.Runtime
{
    public class FakeEndScreen : MonoBehaviour
    {
        #region Public Members
        #endregion


        #region Unity API

        private void Start()
        {
            _manager = GameManager.m_instance;
            _manager.m_onEnd += OnEndEventHandler;
        }

        private void OnEndEventHandler()
        {
            transform.GetComponentInChildren<GameObject>().SetActive(true);
        }

        private void OnDisable()
        {
            _manager.m_onEnd -= OnEndEventHandler;
        }

        #endregion


        #region Main Methods

        

        #endregion


        #region Private and Protected

        private GameManager _manager;

        #endregion
    }
}
