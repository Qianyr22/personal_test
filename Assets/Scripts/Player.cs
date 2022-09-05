using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=5.0f;
    private bool is_alive = true;
    private static GameObject die_tip;
    // Start is called before the first frame update
    void Start()
    {
        die_tip = GameObject.Find("Die");
        die_tip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            respawn();
        }
        if (is_alive){
            die_tip.SetActive(false);
            if(Input.GetKey(KeyCode.LeftArrow)){
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if(Input.GetKey(KeyCode.UpArrow)){
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
        }
        else{
            die_tip.SetActive(true);
        }
    }

    public void die(){
        is_alive = false;
    }

    public void respawn(){
        is_alive = true;
        float step = speed * Time.deltaTime;
        transform.localPosition = new Vector3(-10, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Walls"){
            Debug.Log("hit");
            // if(Input.GetKey(KeyCode.LeftArrow)){
            //     transform.Translate(speed * Time.deltaTime, 0, 0);
            // }
            // if(Input.GetKey(KeyCode.RightArrow)){
            //     transform.Translate(-speed * Time.deltaTime, 0, 0);
            // }
            // if(Input.GetKey(KeyCode.UpArrow)){
            //     transform.Translate(0, -speed * Time.deltaTime, 0);
            // }
            // if(Input.GetKey(KeyCode.DownArrow)){
            //     transform.Translate(0, speed * Time.deltaTime, 0);
            // }  
        }
        else if(collision.gameObject.tag == "Enemy"){
            Debug.Log("Collid Enemy");
            die();
        }
    }

}
