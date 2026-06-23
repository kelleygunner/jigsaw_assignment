using System;
using UnityEngine;
using UnityEngine.UI;

namespace Features.StartLevelScreen
{
    public class PreviewPatternView : MonoBehaviour
    {
        [SerializeField] private Image _patterPreview;
        [SerializeField] private Sprite[] _patterns;

        public void Setup(int patternIndex)
        {
            if (patternIndex >= _patterns.Length)
                throw new Exception("Index is out of range");
            _patterPreview.sprite = _patterns[patternIndex];
        }
    }
}
