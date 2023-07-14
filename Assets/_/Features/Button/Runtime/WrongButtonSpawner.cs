using System;
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
        }

        private void OnNumberOfClickChangedEvent(OnNumberOfClickChangeArgs e)
        {
            SpawnButton((int)(e.m_currentNumberOfClick * _numberOfSpawnMultiplier));
        }

        private void SpawnButton(int number = 1)
        {
            for (int i = 0; i < number; i++)
            {
                GameObject prefab =
                    _references._wrongButtonPrefabs[Random.Range(0, _references._wrongButtonPrefabs.Length - 1)];
                Move(Instantiate(prefab, Vector3.forward, Quaternion.identity, _references._canvasParent).GetComponent<RectTransform>());
            }
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
        [SerializeField] private float _numberOfSpawnMultiplier = 1;

        [Serializable]
        private struct References
        {
            public RectTransform _canvasParent;
            public GameObject[] _wrongButtonPrefabs;
        }
    }
}