using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Audio
{
    private bool dragging = false;
    private Vector3 offset;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FireFlower")
        {
            PlaySounds(audioClips[1], p1: 0.6f, p2: 0.8f);
        }
    }
    private void Start()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    private void Update()
    {
        if (dragging == true)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            dragging = false;
        }
    }

    private void OnMouseDown()
    {
        PlaySounds(audioClips[0], p1: 0.6f, p2: 0.8f);
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    private void OnMouseUp()
    {
        PlaySounds(audioClips[0], p1: 0.6f, p2: 0.8f);
        dragging = false;
    }

    private void SelfDestroy()
    { 
    Destroy(gameObject);
    }
}
