using System;
using System.Collections;
using System.Collections.Generic;
using GameManagerFeature.Runtime;
using UnityEngine;

namespace HUDFeature.Runtime
{
    public class StartTextDestroy : MonoBehaviour
    {
        #region Public Members
        #endregion


        #region Unity API

        private void Start()
        {
            _manager = GameManager.m_instance;
            _manager.m_onNumberOfClickChanged += OnTextDisable;
        }

        private void OnDestroy()
        {
            _manager.m_onNumberOfClickChanged -= OnTextDisable;
        }

        private void OnTextDisable(OnNumberOfClickChangeArgs obj)
        {
            Destroy(gameObject);
        }

        #endregion
        

        #region Private and Protected

        private GameManager _manager;

        #endregion
    }
}
