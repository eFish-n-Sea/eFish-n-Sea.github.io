using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell_behavior : MonoBehaviour
{
    public float redOffset, blueOffset, brightnessOffset;
    public int dirtiness;
    public bool sparkling;
    public bool collected;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start(){
        sparkling = false;
        collected = false;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update(){
        float red = 1f - dirtiness/redOffset - dirtiness/brightnessOffset;
        float green = 1f - dirtiness/brightnessOffset;
        float blue = 1f - dirtiness/blueOffset - dirtiness/brightnessOffset;
        sprite.color = new Color(red, green, blue, 1);
    }

    void OnTriggerEnter2D(Collider2D col){
        if (dirtiness > 0){
            clean();
        }
        if (dirtiness == 0){
            sparkle();
        }
    }

    void OnMouseDown(){
        if (dirtiness == 0){
            collect();
        }
    }

    void clean(){
        dirtiness--;
    }

    void sparkle(){
        sparkling = true;
    }

    void collect(){
        collected = true;
    }
}
