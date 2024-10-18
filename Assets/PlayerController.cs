using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 0.3f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter2D (Collider2D collision){
        if (collision.tag == "Portal"){
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
