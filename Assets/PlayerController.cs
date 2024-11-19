using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 0.3f;
    [SerializeField] GameObject Bullet;
   
    [SerializeField] Vector3 trans;
    public Vector3 aim;
    float aimAngle;
    float rightEnter = 8.41f;
    float leftEnter = -8.56f;
    Animator anim;
    public float moveX;
    public float moveY;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

      
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0f);

            if(moveX > 0f){
              anim.SetBool("Right", true);
                
                 } else {
                     anim.SetBool("Right", false);
                     aim = new Vector3(1, 0, 0);
                     trans = new Vector3(0.5f, 0, 0);
                     
                 }
            if(moveX < 0f){
                 anim.SetBool("Left", true);
            } else {
                     anim.SetBool("Left", false);
                      aim = new Vector3(-1, 0, 0);
                      trans = new Vector3(-0.5f, 0, 0);
                 }
            if(moveY < 0f){
                 anim.SetBool("Down", true);
            } else {
                     anim.SetBool("Down", false);
                    aim = new Vector3(0, -1, 0);
                    trans = new Vector3(0, 0, 0);
                 }
            if(moveY > 0f){
                 anim.SetBool("Up", true);
            } else {
                     anim.SetBool("Up", false);
                     aim = new Vector3(0, 1, 0);
                     trans = new Vector3(0, 0.5f, 0);
                   
                 }
            
        if(Input.GetKeyDown(KeyCode.Space)){
              PewPew();
        }
        
    }

    void PewPew(){
        
         Instantiate(Bullet);
         Bullet.transform.position = transform.position;
         
    }

    void OnTriggerEnter2D (Collider2D collision){
        if (collision.gameObject.name == "Portal Left"){
            transform.position = new Vector3(rightEnter, transform.position.y, transform.position.z);
        }
         if (collision.gameObject.name == "Portal Right"){
            transform.position = new Vector3(leftEnter, transform.position.y, transform.position.z);
        }
    }
}
