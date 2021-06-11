using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBuilding : MonoBehaviour
{
    public void spawnBluePrint(GameObject B)
    {
        Instantiate(B);
    }
}
