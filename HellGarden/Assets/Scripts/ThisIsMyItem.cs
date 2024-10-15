using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsMyItem : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    [Header("InsideObjects")]
    public GameObject InsideObjects;
    [Header("Animation Parametrs")]
    public bool UseAnimations;
    public Animator ObjectAnimator;
    public string AnimatorOnMouseDownName;
    public string AnimatorIdleName;

    // Start is called before the first frame update
    private void Start()
    {
        InsideObjects.SetActive(false);
        startPosition = transform.position;
    }
    private void Update()
    {
        if (dragging == true)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }

    }

    private void OnMouseDown()
    {
        if (UseAnimations == true)
        {
            ObjectAnimator.Play(AnimatorOnMouseDownName);
        }
        InsideObjects.SetActive(true);
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    private void OnMouseUp()
    {
        if (UseAnimations == true)
        {
            ObjectAnimator.Play(AnimatorIdleName);
        }
        InsideObjects.SetActive(false);
        transform.position = startPosition;
        dragging = false;
    }
}
