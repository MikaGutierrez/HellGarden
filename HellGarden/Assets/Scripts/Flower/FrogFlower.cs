using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogFlower : Audio
{
    [Header("ChangeGameObjects")]
    public SpriteRenderer FrogRenderer;
    public Sprite Stage1;
    public Sprite Stage2;
    public Sprite Stage3;
    [Header("Flower Health")]
    public float FlowerHealth = 100;
    public float MaxFlowerHealth = 100;
    public float MinFlowerHealth = 0;
    public int FlowerStage;
    public float FlowerHealthLooseSpeed = 7f;
    [Header("OtherStates")]
    public float PressPower = 19.5f;
    public float SecondsToGetHeart = 2;
    [Header("Paricles")]
    public GameObject[] Hearts;
    public GameObject[] BroukenHearts;
    private bool DidIt = false;
    // Start is called before the first frame update



    void Start()
    {
        StartCoroutine(GiveHearts());
    }

    // Update is called once per frame
    void Update()
    {
        if (ThisIsMyItemMod.TriggerIt == true && ThisIsMyItemPlugIt.IsPluged == true)
        {

            PlaySounds(audioClips[0], p1: 0.9f, p2: 1f);
            ThisIsMyItemMod.TriggerIt = false;
            FlowerHealth += ThisIsMyItemMod.PositionParametrNow;
            Debug.Log(ThisIsMyItemMod.PositionParametrNow);
            ThisIsMyItemMod.PositionParametrNow = 0;
            DidIt = true;
        }
        if (ThisIsMyItemMod.PositionParametrNow != 0 && DidIt == true && ThisIsMyItemPlugIt.IsPluged == true)
        {

            PlaySounds(audioClips[1], p1: 0.9f, p2: 1f);
            DidIt = false;
        }






        if (FlowerHealth >= MinFlowerHealth)
        {
            FlowerHealth -= Time.deltaTime * FlowerHealthLooseSpeed;
        }

        if (FlowerHealth > MaxFlowerHealth)
        {
            FlowerHealth = MaxFlowerHealth;
        }

        if (FlowerHealth >= 70)
        {
            FlowerStage = 0;
        }
        else if (FlowerHealth < 70 && FlowerHealth > 40)
        {
            FlowerStage = 1;
        }
        else if (FlowerHealth < 40 && FlowerHealth > 0)
        {
            FlowerStage = 2;
        }



        if (FlowerStage == 0)
        {
            FrogRenderer.sprite = Stage1;
        }
        else if (FlowerStage == 1)
        {
            FrogRenderer.sprite = Stage2;
        }
        else if (FlowerStage == 2)
        {
            FrogRenderer.sprite = Stage3;
        }

    }
    private IEnumerator GiveHearts()
    {
        yield return new WaitForSeconds(SecondsToGetHeart);
        if (FlowerStage == 2)
        {
            Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
            Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
            Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
            ThePlayer.Hears -= 3;
        }
        else if (FlowerStage == 1)
        {
        }
        else if (FlowerStage == 0)
        {
            Instantiate(Hearts[Random.Range(0, Hearts.Length)], new Vector3(transform.position.x, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
            ThePlayer.Hears += 1;
        }
        StartCoroutine(GiveHearts());

    }
}
