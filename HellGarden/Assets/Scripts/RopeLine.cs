using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeLine : MonoBehaviour
{

    public Transform[] bones;
    //public Transform bone2;

    public LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line.enabled = true;
        line.positionCount = bones.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < bones.Length; i++)
        {
            line.SetPosition(i, bones[i].position);
        }
    }
}
