using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float roSpeed = 50f;
    
    [SerializeField] GameObject AlienBullet;
    [SerializeField] float Ytrans = -0.3f;
    [SerializeField] float Xtrans = -0.3f;
    Vector3 position;
      Rigidbody2D rb;

      float move;
        
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
     
    }

    // Update is called once per frame
    void Update()
    {
      
       if (Input.GetKey(KeyCode.LeftArrow)){
         move = 1f;
       
        } else {
         move = 0f;
        }

        rb.transform.Translate(move * speed * Time.deltaTime, 0f, 0f, Space.Self);

        //rotation works.
        if (Input.GetKey(KeyCode.UpArrow)) {
            rb.rotation += roSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            rb.rotation -= roSpeed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.RightShift)){
            Fire();
        }

    }

    void Fire() {
     
        GameObject bullet; 
        float angle = rb.rotation * Mathf.Deg2Rad;
        float bulletSpeed = 15f;
        
        Vector3 translation = new Vector3(Xtrans, Ytrans, 0);
         position = transform.position + translation;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));    
        bullet = Instantiate(AlienBullet, position, Quaternion.Euler(rb.rotation, 0, 0));
        Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
        brb.velocity = direction * bulletSpeed;

    }
}
