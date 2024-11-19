using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonBG : MonoBehaviour
{
    [SerializeField] float moveX = -3f;
    [SerializeField] float speed = 2f;
    float bound = -23f;
    AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>(); 
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < bound){
            transform.position = new Vector3(-bound, 0f, 0f);
        } else{
            transform.Translate(moveX * speed * Time.deltaTime, 0f, 0f);
        }
        
    }
}
