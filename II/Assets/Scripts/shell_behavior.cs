using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell_behavior : MonoBehaviour
{
    public float redOffset, blueOffset, brightnessOffset;
    public float moveSpeed;
    public int dirtiness;
    public bool sparkling;
    public bool collected;
    GameObject bag;
    catfish_behavior catfish_script;
    SpriteRenderer sprite;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){
        sparkling = false;
        collected = false;
        bag = GameObject.FindWithTag("Bag");
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        catfish_script = GameObject.FindWithTag("Catfish").GetComponent<catfish_behavior>();
    }

    void Update(){
        float red = 1f - dirtiness/redOffset - dirtiness/brightnessOffset;
        float green = 1f - dirtiness/brightnessOffset;
        float blue = 1f - dirtiness/blueOffset - dirtiness/brightnessOffset;
        sprite.color = new Color(red, green, blue, 1);
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Catfish"){
            if (dirtiness > 0){
                clean();
            }
            if (dirtiness == 0){
                sparkle();
            }
            catfish_script.speed = catfish_script.slow;
        }
        else if (col.tag == "Bag"){
            this.gameObject.SetActive(false);
            rb.velocity = new Vector2(0, 0);
            GameObject.FindWithTag("GameController").GetComponent<game_controller>().collectedShells ++;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.tag == "Catfish"){
            catfish_script.speed = catfish_script.fast;
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
        transform.GetChild(0).gameObject.SetActive(true);
    }

    void collect(){
        if (!collected){
            collected = true;
            float shellX = transform.position.x;
            float shellY = transform.position.y;
            float bagX = bag.transform.position.x;
            float bagY = bag.transform.position.y;
            float disX = bagX - shellX;
            float disY = bagY - shellY;
            float moveDis = (float) System.Math.Sqrt(disX*disX + disY*disY);
            float ratio = moveSpeed/moveDis;
            rb.velocity = new Vector2(ratio * disX, ratio * disY);
        }
    }
}
