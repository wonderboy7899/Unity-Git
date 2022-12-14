using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class LoginManager : MonoBehaviour
{
    [Header("Login")]
    public TMP_InputField ID;
    public TMP_InputField PW;
    [Header("CreateAccount")]
    public TMP_InputField NewID;
    public TMP_InputField NewPW;

    public GameObject LoginPanel;
    public GameObject CreateAccountPanel;

    public string BaseUrl;
    
    // Start is called before the first frame update
    void Start()
    {
        Managers.Sound.Play("Audio/Little Engine", Sound.Bgm);
        // BaseUrl 을 만들어서 활용할것. BaseUrl = http://127.0.0.1
        BaseUrl = "http://127.0.0.1/";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitButton()
    {
        Application.Quit(); 
    }

    public void LoginButton()
    {
        StartCoroutine(LoginCo());
    }

    public void OpenCreateAccountButton()
    {
        LoginPanel.SetActive(false);
        CreateAccountPanel.SetActive(true);
        //StartCoroutine(LoginCo());
    }

    public void CreateAccountButton()
    {
        StartCoroutine(CreateCo());
        LoginPanel.SetActive(true);
        CreateAccountPanel.SetActive(false);
    }

    IEnumerator CreateCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("Input_user", NewID.text);
        form.AddField("Input_pass", NewPW.text);
        form.AddField("Input_Info", "안녕하세요.");

        WWW webRequest = new WWW(BaseUrl + "CreateAccount.php", form);
        yield return webRequest;

        Debug.Log(webRequest.text);
        webRequest.Dispose();   // A Native Collection has not been disposed, resulting in a memory leak. Enable Full StackTraces to get more details. 에러의 해결법
    }

    IEnumerator LoginCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("Input_user", ID.text);
        form.AddField("Input_pass", PW.text);

        UnityWebRequest www = UnityWebRequest.Post(BaseUrl + "login.php", form);
        yield return www.SendWebRequest();

        if (www.error == null)
        {
            string result = www.downloadHandler.text;   // {"result":false, "code":"000", "cnt":1}
            LoginJson loginJson = JsonUtility.FromJson<LoginJson>(result);
            VarManager.User_ID = ID.text;
            VarManager.User_Gold = loginJson.gold;
            if (loginJson.result)
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        else
            Debug.Log(www.error);
    }
}
