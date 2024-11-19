using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// current problems : score text not displaying the scor for either player. the bullets won't 
    /// appear the second you have the Destroy(gameObject) so it's currently commented out 
    /// trying to figure out the TMPro that's #1. 
    /// </summary>
    GameManager gc;
    float life = 1f;
       AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, life); 
 
        Debug.Log(transform.position);
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        sound = GetComponent<AudioSource>();

        sound.Play();

    }
   private void OnCollisionEnter2D (Collision2D collision){

        //Destroy(gameObject);
        if(collision.gameObject.tag == "Astronaut"){
           
            gc.ImposterScored();
        }

        if(collision.gameObject.tag == "Alien"){
        
            gc.AstroScored();
        }
       
    }
}
