using System;
using UnityEngine;

namespace Inventory
{
    [ExecuteInEditMode]
    public class GridLayout : MonoBehaviour
    {
        [Min(1)] [SerializeField] private int columnCount;
        [Min(1)] [SerializeField] private int rowCount;
        [SerializeField] private GameObject itemPrefab;
        //[SerializeField] private Vector2 padding;
        [SerializeField] private Vector2 spacing;
        private Transform _transform;
        private float _cellHeight;
        private float _cellWidth;
        private int _childCount;

        protected int ColumnNum;
        protected int RowNum;
        
        private Vector2 Spacing => spacing / 1000;
        protected void Start()
        {
            _transform = transform;
            _childCount = _transform.childCount;
            Align();
        }
        private void Update()
        {
            if(!Application.isPlaying )
                Start();
        }
        private void Align()
        {
            if(_childCount == 0)
                throw new ArgumentOutOfRangeException();
            
            var exit = false;
            _cellWidth = 1 / (float)columnCount - Spacing.x + Spacing.x/columnCount;
            _cellHeight = 1 / (float)rowCount - Spacing.y + Spacing.y / rowCount;
            
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if(i * columnCount + j >= _childCount)
                    {
                        exit = true;
                        break;
                    }
                    
                    var childRect = _transform.GetChild(i * columnCount + j).GetComponent<RectTransform>();
                    childRect.anchorMax = new Vector2(_cellWidth * (j + 1) + Spacing.x * j,  _cellHeight * i + _cellHeight + Spacing.y * i);
                    childRect.anchorMin = new Vector2(_cellWidth * j + Spacing.x * j, _cellHeight * i + Spacing.y * i);
                    childRect.offsetMax = Vector2.zero;
                    childRect.offsetMin = Vector2.zero;
                    ColumnNum = j + 1;
                }
                if (exit)
                    break;
                RowNum = i + 1;
            }
            
        }

        private void Align(int rows, int columns, Vector2 spacing, Vector2 padding)
        {
            
        }

        //13 42
        public void AddItem()
        {
            if(ColumnNum == columnCount && RowNum + 1 >= rowCount)
                throw new ArgumentOutOfRangeException();
            var item = Instantiate(itemPrefab, _transform);
            var itemRect = item.GetComponent<RectTransform>();
            var col = ColumnNum;
            var row = RowNum;
            if (ColumnNum == columnCount)
            {
                col = ColumnNum = 0;
                row = ++RowNum;
            }

            itemRect.anchorMax = new Vector2(_cellWidth * (col + 1) + Spacing.x * col,  _cellHeight * row + _cellHeight + Spacing.y * row);
            itemRect.anchorMin = new Vector2(_cellWidth * col + Spacing.x * col, _cellHeight * row + Spacing.y * row);
            ColumnNum++;
        }
    }
}