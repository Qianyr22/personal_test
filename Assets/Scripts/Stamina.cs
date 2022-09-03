using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stamina : MonoBehaviour
{   
    public TMP_Text text;
    private float stamina = 20.0f;
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || 
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow)) {
                stamina -= speed * Time.deltaTime;
                text.text = "Stamina: " + string.Format("{0:0.00}", stamina);
        }
    }
}
