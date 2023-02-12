using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class results : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator win(int stars){
        GetComponent<Animator>().SetBool("earned", true);
        for (int i = 0; i < stars && i < 3; i++){
            yield return new WaitForSeconds(1);
            transform.GetChild(i).GetComponent<Animator>().SetBool("earned", true);
        }
    }
}
