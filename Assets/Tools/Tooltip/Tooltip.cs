using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tooltip
{
[ExecuteInEditMode()]
    public class Tooltip : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI headerField;
        [SerializeField] private TextMeshProUGUI contentField;
        [SerializeField] private LayoutElement layoutElement;
        [SerializeField] private int characterWrapLimit;
        private RectTransform _rectTransform;
        private int _screenW;
        private int _screenH;
        
        public void SetText(string content, string header = "")
        {
            if(!_rectTransform)
            {
                _rectTransform = GetComponent<RectTransform>();
                _screenH = Screen.width;
                _screenW = Screen.height;
            }
            if (string.IsNullOrEmpty(header))
                headerField.gameObject.SetActive(false);
            else
            {
                headerField.gameObject.SetActive(true);
                headerField.text = header;
            }

            contentField.text = content;
            var headerLength = headerField.text.Length;
            var contentLength = contentField.text.Length;
            layoutElement.enabled =
                headerLength > characterWrapLimit || contentLength > characterWrapLimit;
            var pos = Input.mousePosition;
            float pivotX = pos.x > _screenW / (float) 2 ? 1 : 0;
            float pivotY = pos.y > _screenH / (float)2 ? 1 : 0;            

            _rectTransform.pivot = new Vector2(pivotX,pivotY);
            transform.position = pos;
        }

    }
}