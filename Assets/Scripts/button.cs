using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class button : MonoBehaviour {
  //  private const string URL = "http://192.168.4.1/servo";
	public Text responseText;

    //void Start(){
    //    GameObject.Find("AvatarStatesUI1").SetActive(false);
    //    GameObject.Find("AvatarStatesUI2").SetActive(false);
    //}

	public void ServoRequest()
	{ 
		StartCoroutine (UploadServo());
	
	}

    public void LEDRequest()
    {
        StartCoroutine(UploadLED());

    }

    //public void ShowAvatarStateUI1(){
    //    GameObject.Find("AvatarStatesUI1").SetActive(true);
    //    Debug.Log("Click1");
    //}
    //public void ShowAvatarStateUI2()
    //{
    //    GameObject.Find("AvatarStatesUI2").SetActive(true);
    //    Debug.Log("Click2");
    //}

	private IEnumerator UploadServo()
	{
        
        UnityWebRequest www = UnityWebRequest.Post(("http://192.168.4.1/servo"), "toggleServo");
		www.chunkedTransfer = false;////ADD THIS LINE
		yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }

	}

    private IEnumerator UploadLED()
    {

        UnityWebRequest www = UnityWebRequest.Post(("http://192.168.4.1/led"), "toggleLED");
        www.chunkedTransfer = false;////ADD THIS LINE
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }

    }
}
