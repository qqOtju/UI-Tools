using System;
using System.Collections.Generic;
using UnityEngine;

namespace TabGroup
{
    public class TabGroup : MonoBehaviour
    {
        [SerializeField] public List<TabButton> tabButtons;
        [SerializeField] private TabGroupMode groupMode;
        [SerializeField] private Color colorIdle;
        [SerializeField] private Color colorHover;
        [SerializeField] private Color colorActive;
        [SerializeField] private Sprite tabIdle;
        [SerializeField] private Sprite tabHover;
        [SerializeField] private Sprite tabActive;
        [SerializeField] private List<GameObject> objectsToSwap;
        private TabButton _selectedTab;

        public TabGroupMode Mode
        {
            get => groupMode;
            set => groupMode = value;
        }

        private void Start()
        {
            if(tabButtons == null)
                throw new System.NotImplementedException();
            foreach (var button in tabButtons)
            {
                button.Init(this);
            }
        }

        public void OnTabEnter(TabButton button)
        {
            RestTabs();
            if(button != _selectedTab || button == null)
                switch (Mode)
                {
                    case TabGroupMode.Color:
                        button.Background.color = colorHover;
                        break;
                    case TabGroupMode.Image:
                        button.Background.sprite = tabHover;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
        }

        public void OnTabSelected(TabButton button)
        {
            if (_selectedTab != null)
            {
                _selectedTab.Deselect();
            }
            _selectedTab = button;
            _selectedTab.Select();
            RestTabs();
            switch (Mode)
            {
                case TabGroupMode.Color:
                    button.Background.color = colorActive;
                    break;
                case TabGroupMode.Image:
                    button.Background.sprite = tabActive;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            var index = button.transform.GetSiblingIndex();
            for (int i = 0; i < objectsToSwap.Count; i++)
            {
                objectsToSwap[i].SetActive(i == index);
            }
        }

        public void OnTabExit(TabButton button)
        {
            RestTabs();
        }

        private void RestTabs()
        {
            foreach (var button in tabButtons)
            {
                if(_selectedTab != null && button == _selectedTab) continue;
                switch (Mode)
                {
                    case TabGroupMode.Color:
                        button.Background.color = colorIdle;
                        break;
                    case TabGroupMode.Image:
                        button.Background.sprite = tabIdle;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
