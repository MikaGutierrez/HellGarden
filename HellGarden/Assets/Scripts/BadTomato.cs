using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BadTomato : MonoBehaviour
{
    public GameObject particles;
    public GameObject self;
    public GameObject[] BroukenHearts;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "BlackHole")
        {
            Destroy(self);
        }
    }

    void Start()
    {
        StartCoroutine(GiveHearts());
    }
    private void OnMouseDown()
    {
        ThePlayer.Hears += 1;
        Instantiate(particles, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        Destroy(self);
    }

    private IEnumerator GiveHearts()
    {
        Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, 4.776672f, 0f), Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(3);
        ThePlayer.Hears -= 2;
        StartCoroutine(GiveHearts());

    }
}
