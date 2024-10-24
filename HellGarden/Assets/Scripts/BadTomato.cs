using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

public class BadTomato : Audio
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
        PlaySounds(audioClips[3], p1: 0.9f, p2: 1f);
        StartCoroutine(GiveHearts());
    }
    private void OnMouseDown()
    {
        StartCoroutine(Die());
    }

    private IEnumerator GiveHearts()
    {
        PlaySounds(audioClips[Random.Range(0, audioClips.Length -1)], p1: 0.9f, p2: 1f);
        Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(3);
        ThePlayer.Hears -= 2;
        StartCoroutine(GiveHearts());

    }
    private IEnumerator Die()
    {
        PlaySounds(audioClips[3], p1: 0.9f, p2: 1f);
        ThePlayer.Hears += 1;
        Instantiate(particles, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        yield return new WaitForSeconds(0.01f);
        Destroy(self);
    }
}
