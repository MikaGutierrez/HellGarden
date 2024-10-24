using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThisIsMyItem : Audio
{
    private bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    [Header("InsideObjects")]
    public bool UseInsideObjects = true;
    public GameObject InsideObjects;
    [Header("Animation Parametrs")]
    public bool UseAnimations;
    public Animator ObjectAnimator;
    public string AnimatorOnMouseDownName;
    public string AnimatorIdleName;

    // Start is called before the first frame update
    private void Start()
    {
        if (UseInsideObjects == true)
        {
            InsideObjects.SetActive(false);
        }
        startPosition = transform.position;
    }
    private void Update()
    {
        if (dragging == true)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            if (UseAnimations == true)
            {
                ObjectAnimator.Play(AnimatorIdleName);
            }
            if (UseInsideObjects == true)
            {
                InsideObjects.SetActive(false);
            }
            transform.position = startPosition;
            dragging = false;
        }
    }

    private void OnMouseDown()
    {
        if (UseAudio == true)
        {
            PlaySounds(audioClips[0], p1: 0.6f, p2: 0.8f);
        }
        if (UseAnimations == true)
        {
            ObjectAnimator.Play(AnimatorOnMouseDownName);
        }
        if (UseInsideObjects == true)
        {
            InsideObjects.SetActive(true);
        }
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    private void OnMouseUp()
    {
        if (UseAudio == true)
        {
            PlaySounds(audioClips[0], p1: 0.8f, p2: 1f);
        }
        if (UseAnimations == true)
        {
            ObjectAnimator.Play(AnimatorIdleName);
        }
        if (UseInsideObjects == true)
        {
            InsideObjects.SetActive(false);
        }
        transform.position = startPosition;
        dragging = false;
    }
}
