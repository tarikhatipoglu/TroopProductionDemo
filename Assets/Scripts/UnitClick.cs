using UnityEngine;
using System.Drawing;

public class UnitClick : MonoBehaviour
{
    private Camera myCamera;
    public GameObject groundMarker;

    public LayerMask clickable;
    public LayerMask ground;

    RaycastHit hit;
    void Start()
    {
        myCamera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                groundMarker.transform.position = hit.point;
                groundMarker.SetActive(false);
                groundMarker.SetActive(true);

                //groundMarker.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    //shift click
                    UnitSelection.Instance.shiftClickSelect(hit.collider.gameObject);
                }
                else if(!Input.GetKey(KeyCode.LeftShift))
                {
                    //normal click
                    UnitSelection.Instance.clickSelect(hit.collider.gameObject);
                }
            }
            else if(!Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                //deselect them all
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelection.Instance.deselectAll();
                }
            }
        }
    }
}