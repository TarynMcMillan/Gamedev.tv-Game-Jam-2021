using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform[] cameraPos;
    int number = 0;
    float step;
    float speed = 1000f;

    private void Start()
    {
        step = speed * Time.deltaTime;
        this.transform.position = cameraPos[number].position;
        number++;
    }

    private void Update()
    {
        print("The camera position number is  " + number);
        if (Input.GetKeyDown("space"))
        {
            NextPosition();
        }
    }

    public void NextPosition()
    {
        this.transform.position = cameraPos[number].position;
        number++;
    }


}
