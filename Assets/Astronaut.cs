using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float roSpeed = 20f;
    
    [SerializeField] GameObject Bullet;
    Vector3 translation;
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
      
       if (Input.GetKey(KeyCode.D)){
         move = 1f;
        //  rigid.MovePosition(rigidp += Vector3.left * speed * Time.deltaTime);
        } else {
         move = 0f;
        }

        rb.transform.Translate(move * speed * Time.deltaTime, 0f, 0f, Space.Self);

        //rotation works.
        if (Input.GetKey(KeyCode.W)) {
            rb.rotation += roSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)){
            rb.rotation -= roSpeed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            Fire();
        }

    }

    void Fire() {

        //Instantiate(Object original, Vector3 position, Quaternion rotation); 
        //thank you unity manual and claude.ai :) https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
        GameObject bullet; 
        float angle = rb.rotation * Mathf.Deg2Rad;
        float bulletSpeed = 15f;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        //will set this trans up on front panel.
        translation = new Vector3(Xtrans, Ytrans, 0);
         position = transform.position + translation;
    
        bullet = Instantiate(Bullet, position, Quaternion.Euler(rb.rotation, 0, 0));
        Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
        brb.velocity = direction * bulletSpeed;

    }
}
