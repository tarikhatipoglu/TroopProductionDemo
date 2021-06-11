using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public string buildingName;

    [SerializeField]
    private LayerMask layerName;
    
    public GameObject selectedGreen;
    public GameObject clickedMenu;

    public GameObject[] thingsToProduce;

    void Start()
    {
        selectedGreen.SetActive(false);
        clickedMenu.SetActive(false);
    }

    void Update()
    {
        Clicking();
    }
    void Clicking()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, layerName))
            {
                selectedGreen.SetActive(true);
                clickedMenu.SetActive(true);
            }
            else
            {
                selectedGreen.SetActive(false);
                clickedMenu.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            selectedGreen.SetActive(false);
            clickedMenu.SetActive(false);
        }
    }

    //Failed Function, Dont use it!
    void RaycastClick_Example()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                if (hitInfo.transform.gameObject.tag == buildingName)
                {
                    Debug.Log("You clicked building " + buildingName);
                    selectedGreen.SetActive(true);
                    clickedMenu.SetActive(true);
                }
                else
                {

                }
            }
            else
            {
                selectedGreen.SetActive(false);
                clickedMenu.SetActive(false);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            selectedGreen.SetActive(false);
            clickedMenu.SetActive(false);
        }
    }

    public void ProduceTrooper()
    {
        Debug.Log("Trooper ready!");
    }

    public void selectBuilding(GameObject buildingToClick)
    {
        selectedGreen.SetActive(false);
        clickedMenu.SetActive(false);
    }
}
