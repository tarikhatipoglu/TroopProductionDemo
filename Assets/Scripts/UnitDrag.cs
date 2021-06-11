using UnityEngine;
using System.Drawing;

public class UnitDrag : MonoBehaviour
{
    Camera myCamera;

    //graphical
    [SerializeField]
    RectTransform boxVisual;

    //logical
    Rect selectionBox;

    Vector2 startPos;
    Vector2 endPos;

    void Start()
    {
        myCamera = Camera.main;
        startPos = Vector2.zero;
        endPos = Vector2.zero;
        DrawVisual();
    }

    void Update()
    {
        //when clicked
        if(Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            selectionBox = new Rect();
        }

        //when dragging
        if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }

        //when release click
        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
            startPos = Vector2.zero;
            endPos = Vector2.zero;
            DrawVisual();
        }
    }

    void DrawVisual()
    {
        Vector2 dragStart = startPos;
        Vector2 dragEnd = endPos;

        Vector2 dragCenter = (dragStart + dragEnd) / 2.0f;
        boxVisual.position = dragCenter;

        Vector2 dragSize = new Vector2(Mathf.Abs(dragStart.x - dragEnd.x), Mathf.Abs(dragStart.y - dragEnd.y));

        boxVisual.sizeDelta = dragSize;
    }
    void DrawSelection()
    {
        // X calculations
        if(Input.mousePosition.x < startPos.x)
        {
            // left
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPos.x;
        }
        else
        {
            selectionBox.xMin = startPos.x;
            selectionBox.xMax = Input.mousePosition.x;
        }

        // Y calculations
        if (Input.mousePosition.y < startPos.y)
        {
            // down
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPos.y;
        }
        else
        {
            // up
            selectionBox.yMin = startPos.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }
    void SelectUnits()
    {
        //All selected troops
        foreach(var unit in UnitSelection.Instance.unitList)
        {
            //To start selecting them by dragging
            if(selectionBox.Contains(myCamera.WorldToScreenPoint(unit.transform.position)))
            {
                //If units are in dragging
                UnitSelection.Instance.dragSelect(unit);
            }
        }
    }
}
