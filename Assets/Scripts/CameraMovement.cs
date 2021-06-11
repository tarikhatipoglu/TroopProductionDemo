using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float speed = 0.1f;
    float zoomSpeed = 10.0f;
    float rotateSpeed = 0.3f;

    public float maxHeight = 60f;
    public  float minHeight = 10f;

    public Vector3 p1;
    public Vector3 p2;

    void Start()
    {
        
    }

    void Update()
    {
        float hor = Mathf.Clamp01(transform.position.y) * speed * Input.GetAxis("Horizontal");
        float ver = Mathf.Clamp01(transform.position.y) * speed * Input.GetAxis("Vertical");
        float scrollSpeed = Mathf.Log(transform.position.y) * -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

        if((transform.position.y >= maxHeight) && (scrollSpeed > 0))
        {
            scrollSpeed = 0;
        }
        else if((transform.position.y) <= minHeight && (scrollSpeed < 0))
        {
            scrollSpeed = 0;
        }

        if((transform.position.y + scrollSpeed) > maxHeight)
        {
            scrollSpeed = maxHeight - transform.position.y;
        }
        else if((transform.position.y + scrollSpeed) < minHeight)
        {
            scrollSpeed = minHeight - transform.position.y;
        }

        Vector3 verticalMove = new Vector3(0, scrollSpeed, 0);
        Vector3 LR = hor * transform.right;

        Vector3 WS = transform.forward;
        WS.y = 0;
        WS.Normalize();
        WS = WS * ver;

        Vector3 move = verticalMove + LR + WS;

        transform.position = transform.position + move;

        getCameraRotation();
    }

    void getCameraRotation()
    {
        if(Input.GetMouseButtonDown(2)) //Check if middle mouse is pressed
        {
            p1 = Input.mousePosition;
        }

        if(Input.GetMouseButton(2)) //check if middle mouse is holding
        {
            p2 = Input.mousePosition;

            float dx = (p2 - p1).x * rotateSpeed;
            float dy = (p2 - p1).y * rotateSpeed;

            transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, dx, 0)); //Y rotation

            transform.GetChild(0).transform.rotation = transform.GetChild(0).transform.rotation * Quaternion.Euler(new Vector3(-dy, 0, 0));

            p1 = p2;
        }
    }
}
