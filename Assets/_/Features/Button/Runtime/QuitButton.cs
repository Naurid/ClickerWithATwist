using GameManagerFeature.Runtime;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ButtonFeature.Runtime
{
    public class QuitButton : MonoBehaviour
    {
        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
        }

        private void Start()
        {
            _position = _rect.position;
        }

        private void Update()
        {
            _rect.position = Vector3.Lerp(_rect.position, _position, _evadeSpeed);
        }

        public void QuitGame()
        {
            if (_currentEvadeCount < _evadeCount)
            {
                _currentEvadeCount++;
                
                Vector2 pos;
                pos.x = Random.Range(_deadZoneEvade.x, Screen.width - _deadZoneEvade.x);
                pos.y = Random.Range(_deadZoneEvade.y, Screen.height - _deadZoneEvade.y);
                _position = pos;
            }
            else
            {
                GameManager.m_instance.CanQuit = true;
                Application.Quit();
            }
        }

        [SerializeField] private Vector2 _deadZoneEvade;
        [SerializeField] private int _evadeCount;
        [Range(0,1)]
        [SerializeField] private float _evadeSpeed;
        
        private Vector3 _position;
        private int _currentEvadeCount;
        private RectTransform _rect;
        private Camera _camera;
        private BoxCollider2D _collider;
    }
}