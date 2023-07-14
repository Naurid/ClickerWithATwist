using System;
using System.Collections;
using System.Collections.Generic;
using ButtonFeature.Runtime;
using DG.Tweening;
using UnityEngine;

namespace HUDFeature.Runtime
{
    public class ButtonBoing : MonoBehaviour
    {
        #region Public Members
        #endregion


        #region Unity API

        private void OnGUI()
        {
            if (GUILayout.Button("do the boing"))
            {
                DoTheBoing();
            }
        }

        #endregion


        #region Main Methods

        public void DoTheBoing()
        {
            float x = transform.localScale.x;
            float y = transform.localScale.y;
            transform.DOPunchScale(Vector3.one * (_boingSize/100f), _boingDuration).OnComplete(ButtonMovement.m_instance.Click);
        }

        #endregion


        #region Private and Protected

        [SerializeField] private float _boingSize;
        [SerializeField] private float _boingDuration;

        #endregion
    }
}
