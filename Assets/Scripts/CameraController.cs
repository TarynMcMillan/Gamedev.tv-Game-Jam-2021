using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform[] cameraPos;
    int number = 0;
    float step;
    float speed = 100f;

    private void Start()
    {
        step = speed * Time.deltaTime;
        this.transform.position = cameraPos[number].position;
        number++;
    }

    private void Update()
    {
        // print("The camera position number is  " + number);
        if (Input.GetKeyDown("space"))
        {
           NextPosition();
        }
    }

    public void NextPosition()
    {
        Camera.main.transform.position = cameraPos[number].transform.position;

        //Vector3 camPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + (speed * Time.deltaTime), Camera.main.transform.position.z);

       // Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, camPos, speed);

    // transform.position = Vector3.MoveTowards(Camera.main.transform.position, cameraPos[number].position, step);
    
        // Vector3.SmoothDamp
        number++;
        if (number > 3)
        {
            number = 0;
        }
    }


}
