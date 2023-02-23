using System;
using UnityEngine;
using UnityEngine.UI;

namespace FlexibleGridLayout
{

public class FlexibleGridLayout : LayoutGroup {
    [Min(1)][SerializeField] private int columns;
    [Min(1)][SerializeField] private int rows;
    [SerializeField] private Vector2 cellSize;
    [SerializeField] private Vector2 spacing;
    [SerializeField] private FitType fitType;
	
    private bool _fitX;
    private bool _fitY;

    public Vector2 CellSize => cellSize;
    public FitType FitType => fitType;
    public int Columns => columns;
    public int Rows => rows;

    public override void CalculateLayoutInputVertical() {
        base.CalculateLayoutInputHorizontal();
        var count = transform.childCount;

		switch (fitType)
		{
			case FitType.Uniform or FitType.Height or FitType.Width:
				_fitX = _fitY = true;
				var sqrRt = Mathf.Sqrt(count);
				rows = Mathf.CeilToInt(sqrRt);
				columns = Mathf.CeilToInt(sqrRt);
				rows = Mathf.CeilToInt(count / (float)columns);
				columns = Mathf.CeilToInt(count / (float)rows);
				break;
			case FitType.FixedRows:
				columns = Mathf.CeilToInt(count / (float)rows);
				break;
			case FitType.FixedColumns:
				rows = Mathf.CeilToInt(count / (float)columns);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}

		var rect = rectTransform.rect;
		var parentW = rect.width;
		var parentH = rect.height;
		
		var cellW = parentW / columns - spacing.x/columns * (columns - 1) - padding.left / (float) columns - padding.right / (float) columns;
        var cellH = parentH / rows - spacing.y/rows * (rows - 1)  - padding.bottom / (float) rows - padding.top / (float) rows;
        
        cellSize.x = _fitX ? cellW : cellSize.x;//_fitX ? cellW : cellSize.x
        cellSize.y = _fitY ? cellH : cellSize.y;//_fitY ? cellH : cellSize.y


        for (int i = 0; i < rectChildren.Count; i++) {

            var columnCount = 0;
            var rowCount = 0;
            rowCount = i / columns;
            columnCount = i % columns;

            var item = rectChildren[i];

            var xPos = cellSize.x * columnCount + spacing.x * columnCount + padding.left; 
            var yPos = cellSize.y * rowCount + spacing.y * rowCount + padding.top;
                
            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 1, yPos, cellSize.y);
		}

	}

	public override void SetLayoutHorizontal() {

    }

    public override void SetLayoutVertical() {

    }
}
    /*public class FlexibleGridLayout : LayoutGroup
    {
        [SerializeField] private FitType fitType = FitType.Uniform;
        [Min(0)]
        [SerializeField] private Vector2 spacing;
        [Min(1)]
        [SerializeField] private int columns;
        [Min(1)]
        [SerializeField] private int rows;
        private Vector2 _cellSize;

        private bool _fitX;
        private bool _fitY;

        public Vector2 CellSize => _cellSize;
        public FitType FitType => fitType;
        public int Columns => columns;
        public int Rows => rows;


        public override void CalculateLayoutInputVertical()
        {
        }

        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();
            
            if(fitType is FitType.Width or FitType.Height or FitType.Uniform)
            {
                _fitX = true;
                _fitY = true;
                var sqrRt = Mathf.Sqrt(transform.childCount);
                var num = Mathf.CeilToInt(sqrRt);
                columns = num;
                rows = num;
            }

            switch (fitType)
            {
                case FitType.FixedColumns:
                    rows = Mathf.CeilToInt(transform.childCount / (float)columns);
                    break;
                case FitType.Width:
                    rows = Mathf.CeilToInt(transform.childCount / (float)columns);
                    break;
                case FitType.FixedRows:
                    columns = Mathf.CeilToInt(transform.childCount / (float)rows);
                    break;
                case FitType.Height:
                    columns = Mathf.CeilToInt(transform.childCount / (float)rows);
                    break;
                case FitType.Uniform:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            var rect = rectTransform.rect;
            var parentW = rect.width;
            var parentH = rect.height;

            var cellW = parentW / columns - spacing.x/columns * (columns - 1) - padding.left / (float) columns - padding.right / (float) columns;
            var cellH = parentH / rows - spacing.y/rows * (columns - 1)  - padding.bottom / (float) rows - padding.top / (float) rows;

            _cellSize.x = _fitX ? cellW : _cellSize.x;
            _cellSize.y = _fitY ? cellH : _cellSize.y;

            var columnCount = 0;
            var rowCount = 0;

            for (int i = 0; i < rectChildren.Count; i++)
            {
                rowCount = i / columns;
                columnCount = i % columns;

                var item = rectChildren[i];

                var xPos = _cellSize.x * columnCount + spacing.x * columnCount + padding.left; 
                var yPos = _cellSize.y * rowCount + spacing.y * rowCount + padding.top;
                
                SetChildAlongAxis(item, 0, xPos, _cellSize.x);
                SetChildAlongAxis(item, 1, yPos, _cellSize.y);

            }
        }
        public override void SetLayoutHorizontal()
        {
        }

        public override void SetLayoutVertical()
        {
        }
    }*/
}