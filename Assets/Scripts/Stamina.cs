using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stamina : MonoBehaviour
{   
    public TMP_Text text;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.Find("Player").GetComponent<Player>();
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Stamina: " + string.Format("{0:0.00}", player.stamina);
    }
}
