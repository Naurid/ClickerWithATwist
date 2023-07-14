using System;
using GameManagerFeature.Runtime;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ButtonFeature.Runtime
{
    public class ButtonMovement : MonoBehaviour
    {
        public static ButtonMovement m_instance;

        private void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;
            }
            else
            {
                Debug.LogError("There is more than one <color=cyan>ButtonMovement</color> in the scene");
                Destroy(gameObject);
            }
            
            _rect = GetComponent<RectTransform>();
        }

        public void Click()
        {
            if (!GameManager.m_instance.CheckNumberOfClick())
            {
                Destroy(gameObject);
                return;
            }
            Move();
        }

        private void Move()
        {
            Vector2 pos;
            pos.x = Random.Range(_deadZone.x, Screen.width - _deadZone.x);
            pos.y = Random.Range(_deadZone.y, Screen.height - _deadZone.y);
            _rect.position = pos;

            float scale = Random.Range(_randomScale.x, _randomScale.y);
            _rect.localScale = Vector3.one * scale;
        }
        
        [SerializeField] private Vector2 _randomScale;
        [Tooltip("In pixels")]
        [SerializeField] private Vector2 _deadZone;
        private RectTransform _rect;
    }
}