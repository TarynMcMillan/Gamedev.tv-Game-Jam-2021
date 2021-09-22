using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform[] cameraPos;
    [SerializeField] float speed = 1f;
    int number = 0;
    float step;
    bool isMoving = false;
    // Vector3 velocity = Vector3.zero;
    // float smoothTime = 0.001f;

    private void Start()
    {
        step = speed * Time.deltaTime;
        this.transform.position = cameraPos[number].position;
    }

    private void Update()
    {
        // print("The camera position is " + number);
        if (isMoving)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, cameraPos[number].transform.position, step);
            if (Camera.main.transform.position == cameraPos[number].transform.position)
            {
                isMoving = false;
            }
        }
    }

    public void NextPosition()
    {
        number++;
        if (number > 3)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }     
    }
}

// Camera.main.transform.position = cameraPos[number].transform.position;

// Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, cameraPos[number].transform.position, ref velocity, smoothTime);

// Vector3.SmoothDamp

// Vector3 lerpPosition = Vector3.Lerp(Camera.main.transform.position, cameraPos[number].transform.position, step);
// Camera.main.transform.position = lerpPosition;
