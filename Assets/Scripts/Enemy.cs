using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Grave[] graves;
    Grave selectedGrave;
    float step;
    float speed = 1f;
    bool isMoving = false;
    bool reachedTarget = false;
    float timerStarted = 0f;
    float timerFinished = 1f;
    int randomFactor;
    bool isGraveEmpty;

    private void Start()
    {
        step = speed * Time.deltaTime;
        graves = FindObjectsOfType<Grave>();
        SelectGrave();
    }

    private void Update()
    {
        isGraveEmpty = selectedGrave.GetComponent<Grave>().isEmpty;
        if (isGraveEmpty)
        {
            SelectGrave();
        }
        if (!isGraveEmpty)
        {
            if((selectedGrave.transform.Find("Junk(Clone)") == null))
            {
                isMoving = true;
            }
            else
            {
                SelectGrave();
            }
        }
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, selectedGrave.transform.position, step);
        }
        if (transform.position == selectedGrave.transform.position)
        {
            reachedTarget = true;
        }
        if (reachedTarget)
        {
            timerStarted += Time.deltaTime;
            if (timerStarted >= timerFinished)
            {
                print("poof!");
                Destroy(gameObject);
            }
        }
    }

    void SelectGrave()
    {
        randomFactor = Random.Range(0, graves.Length);
        selectedGrave = graves[randomFactor];
    }
}
