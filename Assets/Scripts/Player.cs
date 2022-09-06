using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=5.0f;
    public float stamina = 20.0f;
    public bool GG = false;
    private GameObject stamina_object;
    private GameObject respawn_tip;

    // Start is called before the first frame update
    void Start()
    {
        stamina_object = GameObject.Find("Stamina");
        respawn_tip = GameObject.Find("Respawn_tip");
        stamina_object.SetActive(true);
        respawn_tip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        checkGG();
        if(!GG) {
            if(Input.GetKey(KeyCode.LeftArrow)){
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                stamina -= 0.1f * speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                transform.Translate(speed * Time.deltaTime, 0, 0);
                stamina -= 0.1f * speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.UpArrow)){
                transform.Translate(0, speed * Time.deltaTime, 0);
                stamina -= 0.1f * speed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(0, -speed * Time.deltaTime, 0);
                stamina -= 0.1f * speed * Time.deltaTime;
            }
        }
        else{
            ;
        }
        if(Input.GetKey(KeyCode.R)){
            respawn();
        }
    }

    public void respawn(){
        stamina = 20.0f;
        GG = false;
        transform.position = new Vector3(-10f,0f,0f);
        stamina_object.SetActive(true);
        respawn_tip.SetActive(false);
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
        if(collision.gameObject.tag == "Enemys"){
            Debug.Log("hit by Enemys");
            GG = true;
            stamina_object.SetActive(false);
            respawn_tip.SetActive(true);
        }
    }

}
