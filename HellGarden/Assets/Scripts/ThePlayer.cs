using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThePlayer : MonoBehaviour
{
    public static int Hears = 1;
    public Text TextHearCounter;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TextHearCounter.text = "Hears:" + Hears;
    }
}
