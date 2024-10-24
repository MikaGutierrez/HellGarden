using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAnIce : MonoBehaviour
{

    public GameObject[] Ice;

    // Start is called before the first frame update
    private void Start()
    {
    }
    private void Update()
    {

    }

    private void OnMouseDown()
    {
        Instantiate(Ice[Random.Range(0, Ice.Length)], new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f), Quaternion.Euler(0f, 0f, 0f));
    }
    private void OnMouseUp()
    {
    }
}
