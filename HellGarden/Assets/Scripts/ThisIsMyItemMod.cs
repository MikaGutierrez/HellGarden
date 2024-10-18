using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThisIsMyItemMod : MonoBehaviour
{

    private bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    [Header("Other")]
    public float PositionParametr = 0;
    public static float PositionParametrNow = 0;
    public bool IsUp = true;
    public static bool TriggerIt = false;
    private bool LookAtIt = false;
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
        PositionParametr = (transform.position.y + 1.8f) * 7;

        if (PositionParametrNow < PositionParametr)
        {
            PositionParametrNow = PositionParametr;
        }


        if (dragging == true && transform.position.y <= 1.7f && transform.position.y >= -1.8f)
        {
            transform.position = new Vector2(transform.position.x, offset.y + Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }

        if (transform.position.y > 1.7f)
        {
            transform.position = new Vector2(transform.position.x, 1.7f);
        }
        else if (transform.position.y < -1.8f)
        {
            transform.position = new Vector2(transform.position.x, -1.8f);
        }

        if (transform.position.y <= -1.8f && LookAtIt == false)
        {
            TriggerIt = true;
            IsUp = false;
        }
        else
        {
            IsUp = true;
        }
        if (transform.position.y > -1.8f)
        {
            LookAtIt = false;
        }

        if (TriggerIt == true)
        {
            LookAtIt = true;
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
        //transform.position = startPosition;
        dragging = false;
    }

}
