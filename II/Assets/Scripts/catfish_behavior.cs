using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catfish_behavior : MonoBehaviour
{
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }
}
