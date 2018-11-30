using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class button : MonoBehaviour {
    private const string URL = "http://192.168.4.1/servo";
	public Text responseText;

	public void Request()
	{ 
		StartCoroutine (Upload());
	
	}


	private IEnumerator Upload()
	{
		//WWWForm form = new WWWForm();
        //form.AddField("/servo", "toggleServo");

		UnityWebRequest www = UnityWebRequest.Post((URL), "toggleServo");
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
