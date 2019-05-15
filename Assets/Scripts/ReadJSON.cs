using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using LitJson;

public class ReadJSON : MonoBehaviour
{

    private JsonData Data;

	void Start()
	{
        string url = "http://192.168.4.1/ambientroom";
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
       
	}
    IEnumerator WaitForRequest(WWW www){
        yield return www;
        if(www.error == null){
            Data = JsonMapper.ToObject(www.text);
            Debug.Log("Light:" + Data["light_brightness"][0]);
            Debug.Log("Temperature_c:" + Data["temperature_c"][0]);
            Debug.Log("Temperature_f:" +Data["temperature_f"][0]);
            Debug.Log("Humidity:" +Data["humidity"][0]);
            //Debug.Log("WWW Text:" + www.text);
        } else {
            Debug.Log("WWW Error:" + www.error);
        }
        
    }


	// Update is called once per frame
	void Update()
    {
        
    }
}
