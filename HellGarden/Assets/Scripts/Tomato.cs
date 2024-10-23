using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Tomato : MonoBehaviour
{
    public float TomatoLifeTime = 0;
    private int State = 0;
    public float SpeedOfHeaelth = 1;
    public SpriteRenderer sr;
    public Sprite SpriteNone;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public GameObject TomatoRawGreen;
    public GameObject TomatoRawOrange;
    public GameObject TomatoDone;
    public GameObject TomatoBad;
    public Animator ObjectAnimator;
    [Header("Paricles")]
    public GameObject[] Hearts;
    public GameObject[] BroukenHearts;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GiveHearts());
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Knife")
        {
            if (State >= 1)
            {
                TomatoLifeTime = 0;
                if (State == 1)
                {
                    Instantiate(TomatoRawGreen, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f));
                }
                else if (State == 2)
                {
                    Instantiate(TomatoRawOrange, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f));
                }
                else if (State == 3)
                {
                    Instantiate(TomatoDone, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f));
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        TomatoLifeTime += Time.deltaTime * SpeedOfHeaelth;


        if (TomatoLifeTime < 10)
        {
            ObjectAnimator.Play("Tomato");
            State = 0;
            sr.sprite = SpriteNone;
        }
        else if (TomatoLifeTime >= 10 && TomatoLifeTime < 20)
        {
            State = 1;
            sr.sprite = Sprite1;
        }
        else if (TomatoLifeTime >= 20 && TomatoLifeTime < 30)
        {
            State = 2;
            sr.sprite = Sprite2;
        }
        else if (TomatoLifeTime >= 30 && TomatoLifeTime < 40)
        {
            State = 3;
            ObjectAnimator.Play("TomatoBad");
            sr.sprite = Sprite3;
        }
        else if (TomatoLifeTime >= 35)
        {
            Instantiate(TomatoBad, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f));
            TomatoLifeTime = 0;
        }
    }
    private IEnumerator GiveHearts()
    {
        yield return new WaitForSeconds(4);
        if (State == 1)
        {
            Instantiate(Hearts[Random.Range(0, Hearts.Length)], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
            yield return new WaitForSeconds(3);
            ThePlayer.Hears += 1;
        }
        else if (State == 2)
        {
            Instantiate(Hearts[Random.Range(0, Hearts.Length)], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
            ThePlayer.Hears += 1;
        }
        else if (State == 3)
        {
            Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
            yield return new WaitForSeconds(3);
            ThePlayer.Hears -= 1;
        }
        StartCoroutine(GiveHearts());

    }
}
