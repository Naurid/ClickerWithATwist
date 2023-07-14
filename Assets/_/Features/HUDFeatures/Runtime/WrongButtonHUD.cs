using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HUDFeature.Runtime
{
    public class WrongButtonHUD : MonoBehaviour
    {
        #region Public Members
        #endregion


        #region Unity API

        private void Start()
        {
            SetRandomImage();
            SetRandomText();
            
            _basePos = transform.position;
            _baseRot = transform.rotation;
        }

        private void OnGUI()
        {
            if (GUILayout.Button("DoShake")) Animation();
        }

        #endregion

        
        #region Main Methods

        private void SetRandomText()
        {
            int randText = Random.Range(0, _wrongTexts.Count);
            _buttonText.text = _wrongTexts[randText];
        }

        private void SetRandomImage()
        {
            int randImage = Random.Range(0, _wrongSprites.Count);
            _buttonObject.image.sprite = _wrongSprites[randImage];
        }
        
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

        [SerializeField] private Button _buttonObject;
        [SerializeField] private TMP_Text _buttonText;
        [SerializeField] private List<Sprite> _wrongSprites;
        [SerializeField] private List<string> _wrongTexts;

        #endregion
    }
}
