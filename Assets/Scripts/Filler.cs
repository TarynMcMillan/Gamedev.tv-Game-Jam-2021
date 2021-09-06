using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filler : MonoBehaviour
{
    Grave[] graves;
    Grave selectedGrave;
    float step;
    float speed = 5f;
    bool isMoving = false;
    bool reachedTarget = false;
    bool filledGrave = false;
    bool fillingGrave = false;
    float timerStarted = 0f;
    float timerFinished = 3f;
    int randomFactor;
    bool isGraveEmpty;
    Animator enemyAnimator;
    Animator selectedGraveAnimator;
    AudioSource audioSource;
    EnemySpawner enemySpawner;

    private void Start()
    {
        step = speed * Time.deltaTime;
        enemySpawner = FindObjectOfType<EnemySpawner>();
        // enemyAnimator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        graves = FindObjectsOfType<Grave>();
        SelectGrave();
    }

    private void Update()
    {
        isGraveEmpty = selectedGrave.GetComponent<Grave>().isEmpty;
        if (!isGraveEmpty)
        {
            SelectGrave();
        }
        if (isGraveEmpty)
        {
            if ((selectedGrave.transform.Find("Junk(Clone)") == null))
            {
                // print("is moving is " + isMoving);
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
            audioSource.Play();
            // enemyAnimator.SetTrigger("enemyFadeIn");
            // if (selectedGraveAnimator != null)
            // {
            if (!filledGrave)
            {
                FillGrave();
            }
        }
    }

    void FillGrave()
    {
        selectedGraveAnimator.SetTrigger("fill grave");
           
        FindObjectOfType<PileCounter>().AddPile();
        filledGrave = true;
        selectedGrave.GetComponent<Grave>().isEmpty = false;
        print("This grave is empty? " + selectedGrave.GetComponent<Grave>().isEmpty);
        if (selectedGrave.transform.Find("Junk(Clone)") != null)
        {
            print("respawned a Junk grave");
        }
        /*
        timerStarted += Time.deltaTime;
        print(timerStarted);
        if (timerStarted >= timerFinished)

        */
         print("destroyed a filler");
        
        StartCoroutine(DestroyFiller());
    }

    IEnumerator DestroyFiller()
    {
        enemySpawner.spawningFiller = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    void SelectGrave()
    {
        // print("selecting grave");
        randomFactor = Random.Range(0, graves.Length);
        selectedGrave = graves[randomFactor];
        selectedGraveAnimator = selectedGrave.GetComponent<Animator>();
    }

    
}
