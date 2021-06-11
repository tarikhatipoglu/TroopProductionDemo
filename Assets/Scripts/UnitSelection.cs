using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class UnitSelection : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelected = new List<GameObject>();

    private static UnitSelection _instance;
    public static UnitSelection Instance { get { return _instance; } }
    void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            deselectAll();
        }
    }

    public void clickSelect(GameObject unitToAdd)
    {
        deselectAll();
        unitSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.transform.GetChild(1).gameObject.SetActive(true);

        unitToAdd.GetComponent<OrderMovement>().enabled = true;
    }
    public void shiftClickSelect(GameObject unitToAdd)
    {
        if(!unitSelected.Contains(unitToAdd))
        {
            unitSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.transform.GetChild(1).gameObject.SetActive(true);

            unitToAdd.GetComponent<OrderMovement>().enabled = true;
        }
        else
        {
            unitSelected.Remove(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitToAdd.transform.GetChild(1).gameObject.SetActive(false);

            unitToAdd.GetComponent<OrderMovement>().enabled = false;
        }
    }
    public void dragSelect(GameObject unitToAdd)
    {
        if(!unitSelected.Contains(unitToAdd))
        {
            unitSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.transform.GetChild(1).gameObject.SetActive(true);

            unitToAdd.GetComponent<OrderMovement>().enabled = true;
        }
    }
    public void deselectAll()
    {
        foreach(var unit in unitSelected)
        {
            unit.GetComponent<OrderMovement>().enabled = false;
            unit.transform.GetChild(0).gameObject.SetActive(false);
            unit.transform.GetChild(1).gameObject.SetActive(false);
        }

        unitSelected.Clear();
    }
}