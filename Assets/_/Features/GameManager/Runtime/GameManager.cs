using System;
using UnityEngine;

namespace GameManagerFeature.Runtime
{
    public struct OnNumberOfClickChangeArgs
    {
        public int m_currentNumberOfClick;
        public int m_numberOfClickLeft;
    }
    
    public class GameManager : MonoBehaviour
    {
        public static GameManager m_instance;
        
        public event Action m_onStart;
        public event Action m_onEnd;
        
        public event Action<OnNumberOfClickChangeArgs> m_onNumberOfClickChanged;

        public bool CanQuit
        {
            get => _canQuit;
            set => _canQuit = value;
        }

        private void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;
            }
            else
            {
                Debug.LogError("There is more than one <color=cyan>GameManager</color> in the scene");
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            m_onStart?.Invoke();
        }

        private void OnApplicationQuit()
        {
            if(!CanQuit) Application.CancelQuit();
            else
            {
                print("JustQuit");
            }
        }

        public bool CheckNumberOfClick(int value = 1)
        {
            _numberOfClick += value;
            m_onNumberOfClickChanged?.Invoke(new OnNumberOfClickChangeArgs {m_currentNumberOfClick = _numberOfClick, m_numberOfClickLeft = _numberOfClickGoal - _numberOfClick} );
            return !IsEndGame();
        }

        private bool IsEndGame()
        {
            if (_numberOfClick < _numberOfClickGoal) return false;
            m_onEnd?.Invoke();
            return true;
        }

        [SerializeField] private int _numberOfClickGoal;
        private int _numberOfClick;
        private bool _canQuit;
    }
}