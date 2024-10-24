using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsMyItemPlugIt : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public SpriteRenderer sr;
    private bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    public GameObject Holl;
    public static bool IsPluged = false;
    [Header("InsideObjects")]
    public bool UseInsideObjects = true;
    public GameObject InsideObjects;
    [Header("Animation Parametrs")]
    public bool UseAnimations;
    public Animator ObjectAnimator;
    public string AnimatorOnMouseDownName;
    public string AnimatorIdleName;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ToPlug")
        {
            IsPluged = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ToPlug")
        {
            IsPluged = false;
        }
    }
    private void Start()
    {
        IsPluged = false;
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
        sr.sprite = sprite1;
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
        if (UseAnimations == true)
        {
            ObjectAnimator.Play(AnimatorIdleName);
        }
        if (UseInsideObjects == true)
        {
            InsideObjects.SetActive(false);
        }
        if (IsPluged == true)
        {
            sr.sprite = sprite2;
            transform.position = Holl.transform.position;
        }
        else
        {
            transform.position = startPosition;
        }
        dragging = false;
    }
}
