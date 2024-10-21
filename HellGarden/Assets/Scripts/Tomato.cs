using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    public float TomatoLifeTime = 0;
    public float SpeedOfHeaelth = 1;
    public SpriteRenderer sr;
    public Sprite SpriteNone;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Animator ObjectAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TomatoLifeTime += Time.deltaTime * SpeedOfHeaelth;


        if (TomatoLifeTime < 10)
        { 
            sr.sprite = SpriteNone;
        }
        else if (TomatoLifeTime >= 10 && TomatoLifeTime < 20)
        {
            sr.sprite = Sprite1;
        }
        else if (TomatoLifeTime >= 20 && TomatoLifeTime < 30)
        {
            sr.sprite = Sprite2;
        }
        else if (TomatoLifeTime >= 30 && TomatoLifeTime < 40)
        {
            ObjectAnimator.Play("TomatoBad");
            sr.sprite = Sprite3;
        }
        else if (TomatoLifeTime >= 40)
        {
            TomatoLifeTime = 0;
        }
    }
}
