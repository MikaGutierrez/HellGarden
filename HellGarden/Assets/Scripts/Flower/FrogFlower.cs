using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogFlower : MonoBehaviour
{
    [Header("Flower Health")]
    public float FlowerHealth = 100;
    public float MaxFlowerHealth = 100;
    public float MinFlowerHealth = 0;
    public int FlowerStage;
    public float FlowerHealthLooseSpeed = 7f;
    [Header("OtherStates")]
    public float PressPower = 19.5f;
    public float SecondsToGetHeart = 2;
    // Start is called before the first frame update



    void Start()
    {
        StartCoroutine(GiveHearts());
    }

    // Update is called once per frame
    void Update()
    {
        if (ThisIsMyItemMod.TriggerIt == true)
        {
            ThisIsMyItemMod.TriggerIt = false;
            FlowerHealth += ThisIsMyItemMod.PositionParametrNow;
            Debug.Log(ThisIsMyItemMod.PositionParametrNow);
            ThisIsMyItemMod.PositionParametrNow = 0;
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
        }
        else if (FlowerStage == 1)
        {
        }
        else if (FlowerStage == 2)
        {
        }

    }
    private IEnumerator GiveHearts()
    {
        yield return new WaitForSeconds(SecondsToGetHeart);
        if (FlowerStage == 2)
        {
            ThePlayer.Hears -= 1;
        }
        else if (FlowerStage == 0)
        {
            ThePlayer.Hears += 1;
        }
        StartCoroutine(GiveHearts());

    }
}
