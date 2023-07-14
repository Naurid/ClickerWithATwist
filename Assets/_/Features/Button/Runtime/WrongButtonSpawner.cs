using System;
using System.Collections;
using System.Collections.Generic;
using GameManagerFeature.Runtime;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ButtonFeature.Runtime
{
    public class WrongButtonSpawner : MonoBehaviour
    {
        private static WrongButtonSpawner m_instance;

        private void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;
            }
            else
            {
                Debug.LogError("There is more than one <color=cyan>WrongButtonSpawner</color> in the scene");
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            GameManager.m_instance.m_onNumberOfClickChanged += OnNumberOfClickChangedEvent;
            GameManager.m_instance.m_onEnd += OnEndEvent;
        }
        

        private void OnNumberOfClickChangedEvent(OnNumberOfClickChangeArgs e)
        {
            SpawnButton((int)(e.m_currentNumberOfClick * _spawnMultiplier));
        }

        private void OnEndEvent()
        {
            StartCoroutine(DestroyButtons());
        }
        
        private void SpawnButton(int number = 1)
        {
            for (int i = 0; i < number; i++)
            {
                GameObject prefab =
                    _references._wrongButtonPrefabs[Random.Range(0, _references._wrongButtonPrefabs.Length)];
                GameObject current = Instantiate(prefab, Vector3.forward, Quaternion.identity, _references._canvasParent);
                Move(current.GetComponent<RectTransform>());
                _wrongButtonList.Add(current);
            }
        }

        private IEnumerator DestroyButtons()
        {
            float time = 1;
            foreach (var obj in _wrongButtonList)
            {
                yield return new WaitForSeconds(time);
                Destroy(obj);
                
                if (!(time > _minTimeToDestroy)) continue;
                
                time -= _timeToDestroyMultiplier;
                if (time < _minTimeToDestroy) time = _minTimeToDestroy;
            }
            _wrongButtonList.Clear();
        }

        private void Move(RectTransform rect)
        {
            Vector2 pos;
            pos.x = Random.Range(0, Screen.width);
            pos.y = Random.Range(0, Screen.height);
            rect.position = pos;

            float scale = Random.Range(_randomScale.x, _randomScale.y);
            rect.localScale = Vector3.one * scale;
        }
        
        [SerializeField] private References _references;
        [Space]
        [SerializeField] private Vector2 _randomScale;
        [SerializeField] private float _spawnMultiplier = 1;
        [Space]
        [SerializeField] private float _timeToDestroyMultiplier = 0.2f;
        [SerializeField] private float _minTimeToDestroy = 0.05f;

        private readonly List<GameObject> _wrongButtonList = new();
        
        [Serializable]
        private struct References
        {
            public RectTransform _canvasParent;
            public GameObject[] _wrongButtonPrefabs;
        }
    }
}