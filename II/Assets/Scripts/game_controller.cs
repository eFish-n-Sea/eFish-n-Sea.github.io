using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_controller : MonoBehaviour
{
    public int collectedShells;
    public GameObject[] prefabShells;
    public int shellsPerRow;
    public float genStartX, genStartY, genSpaceX, genSpaceY;
    public float time3Stars, time2Stars, time1Star;
    GameObject[] shells;

    // Start is called before the first frame update
    void Start(){
        generateShells();
        placeShells();
    }

    // Update is called once per frame
    void Update(){
        if (collectedShells == 20)
            win();
    }

    void generateShells(){
        for (int i = 0; i < 20; i++){
            int shellIndex = Random.Range(0, 6);
            Instantiate(prefabShells[shellIndex]);
        }

        shells = GameObject.FindGameObjectsWithTag("Shell");

        int[] dirtyChoices = new int[] {2, 1, 4, 4, 10, 5, 6, 8, 6, 7, 7, 9, 8, 9, 10, 7, 4, 2, 4, 5};
        for (int i = 0; i < 20; i++){
            shells[i].GetComponent<shell_behavior>().dirtiness = dirtyChoices[i];
        }
    }

    void placeShells(){
        float x = genStartX;
        float y = genStartY;
        for (int i = 0; i < 20; i++){
            shells[i].transform.position = new Vector2(x, y);
            if (i % 5 == 4){
                x = genStartX;
                y += genSpaceY;
            }
            else{
                x += genSpaceX;
            }
        }
    }

    void win(){
        GameObject.FindWithTag("Catfish").GetComponent<catfish_behavior>().speed = 0;
        float time = GameObject.FindWithTag("Timer").GetComponent<timer>().win();
        StartCoroutine(GameObject.FindWithTag("Results").GetComponent<results>().win(stars(time)));
    }

    int stars(float time){
        if (time < time3Stars)
            return 3;
        else if (time < time2Stars)
            return 2;
        else if (time < time1Star)
            return 1;
        else
            return 0;
    }
}
