using System;
using UnityEngine;

namespace Tooltip
{
    public class TooltipSystem : MonoBehaviour
    {
        [SerializeField] private Tooltip tooltip;
        private static TooltipSystem _instance;

        public void Awake()
        {
            _instance = this;
        }

        public static void Show(string content, string header = "")
        {
            _instance.tooltip.SetText(content,header);
            _instance.tooltip.gameObject.SetActive(true);
        }
        
        public static void Hide()
        {
            _instance.tooltip.gameObject.SetActive(false);
        }
    }
}