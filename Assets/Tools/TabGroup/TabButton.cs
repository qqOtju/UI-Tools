using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TabGroup
{
    [RequireComponent(typeof(Image))]
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField] private UnityEvent onTabSelected;
        [SerializeField] private UnityEvent onTabDeselected;
        private TabGroup _tabGroup;
    
        public Image Background { get; private set; }

        public void Init(TabGroup tabGroup)
        {
            if(_tabGroup)
                throw new System.NotImplementedException();
            Background = GetComponent<Image>();
            _tabGroup = tabGroup;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _tabGroup.OnTabEnter(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _tabGroup.OnTabSelected(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _tabGroup.OnTabExit(this);
        }

        public void Select()
        {
            onTabSelected?.Invoke();
        }

        public void Deselect()
        {
            onTabDeselected?.Invoke();
        }
    }
}
