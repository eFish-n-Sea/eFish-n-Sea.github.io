using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_controller : MonoBehaviour
{
    public GameObject[] prefabShells;
    public int shellsPerRow;
    public float genStartX, genStartY, genSpaceX, genSpaceY;
    GameObject[] shells;

    // Start is called before the first frame update
    void Start(){
        generateShells();
        placeShells();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateShells(){
        for (int i = 0; i < 20; i++){
            int shellIndex = Random.Range(0, 6);
            Instantiate(prefabShells[shellIndex]);
        }

        shells = GameObject.FindGameObjectsWithTag("Shell");

        List<int> dirtyChoices = new List<int>{2, 1, 4, 4, 10, 5, 6, 8, 6, 7, 7, 9, 8, 9, 10, 7, 4, 2, 4, 5};
        foreach (GameObject shell in shells){
            int dirtIndex = Random.Range(0, dirtyChoices.Count);
            shell.GetComponent<shell_behavior>().dirtiness = dirtyChoices[dirtIndex];
            dirtyChoices.RemoveAt(dirtIndex);
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
}
