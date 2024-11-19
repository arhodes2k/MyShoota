using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : MonoBehaviour
{
    float waitTime;
   [SerializeField] float timer;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
       timer = Random.Range(2f, 13f); ;
      
    }

    // Update is called once per frame
    void Update()
    {
        waitTime = Random.Range(2f, 13f); 
        timer -= Time.deltaTime;
        if (timer < 0){
            anim.SetTrigger("Lick");
            Wait();
        }

        Debug.Log(timer);
     
    }

    void Wait() {
        timer = waitTime;
         timer -= Time.deltaTime;

    }
}
