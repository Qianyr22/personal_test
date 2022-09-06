using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=5.0f;
    public float stamina = 20.0f;
    public bool GG = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(!GG) {
            if(Input.GetKey(KeyCode.LeftArrow)){
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                stamina -= speed * Time.deltaTime;
                checkGG();
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                transform.Translate(speed * Time.deltaTime, 0, 0);
                stamina -= speed * Time.deltaTime;
                checkGG();
            }
            if(Input.GetKey(KeyCode.UpArrow)){
                transform.Translate(0, speed * Time.deltaTime, 0);
                stamina -= speed * Time.deltaTime;
                checkGG();
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(0, -speed * Time.deltaTime, 0);
                stamina -= speed * Time.deltaTime;
                checkGG();
            }
        }
    }

    private void checkGG() {
        if(stamina <= 0) {
            GG = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Walls"){
            Debug.Log("hit");
            if(Input.GetKey(KeyCode.LeftArrow)){
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if(Input.GetKey(KeyCode.UpArrow)){
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(0, speed * Time.deltaTime, 0);
            }  
        }
    }

}
