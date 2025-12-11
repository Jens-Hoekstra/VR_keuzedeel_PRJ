using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int count = 0;
   
    public float timer = 0;


    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        Debug.Log(count);
        timer += Time.deltaTime;
        Debug.Log(timer);

        

        int seconds = (int)Mathf.Floor(timer)%60;
        int minutes = (int)Mathf.Floor(f:timer/60);
        text.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");

    }

}
