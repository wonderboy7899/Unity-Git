using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetStatus : MonoBehaviour
{
    public string BaseUrl = "http://127.0.0.1/";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Init_Status());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Init_Status()
    {
        WWWForm form = new WWWForm();
        form.AddField("User_ID", VarManager.User_ID);

        UnityWebRequest www = UnityWebRequest.Post(BaseUrl + "SetStatus.php", form);
        yield return www.SendWebRequest();

        if (www.error == null)
        {
            string result = www.downloadHandler.text;   // {"result":false, "code":"000", "cnt":1}
            StatusJson statusJson = JsonUtility.FromJson<StatusJson>(result);

            if (statusJson.result)
            {
                VarManager.Speed = statusJson.movespeed;
                VarManager.AtkDmg = statusJson.atkdmg;
                VarManager.MaxHP = statusJson.maxhp;
            }
        }
        else
            Debug.Log(www.error);
    }
}
