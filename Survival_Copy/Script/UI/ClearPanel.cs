using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearPanel : MonoBehaviour
{
    public Text Score;
    public int Score_Var;
    public Text Gold;
    public int Gold_Var;
    public Text Time;
    public float Time_Var;
    public Text EnemyKillCount;
    public int EnemyKillCount_Var;

    public string BaseUrl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            Set_Var();
        }
    }

    public void Set_Var()
    {
        EnemyKillCount_Var = GameManager.Instance.Killcnt;
        Time_Var = GameManager.Instance.TimeCur;
        Score_Var = EnemyKillCount_Var + (int)Time_Var;
        Gold_Var = (EnemyKillCount_Var * 2) + ((int)Time_Var * 10);

        Score.text = Score_Var.ToString();
        Gold.text = Gold_Var.ToString();
        Time.text = UIManager.Instance.PlayTime.text;
        EnemyKillCount.text = EnemyKillCount_Var.ToString();
    }

    public void Retry_Btn()
    {
        VarManager.User_Gold += Gold_Var;
        SceneManager.LoadScene("PlayScene");
    }

    public void Clear_Btn()
    {
        GameManager.Instance.GameResume();
        VarManager.User_Gold += Gold_Var;
        SceneManager.LoadScene("TitleScene");   
    }

    IEnumerator ClearCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("Input_gold", Gold_Var);

        WWW webRequest = new WWW(BaseUrl + "CreateAccount.php", form);
        yield return webRequest;

        Debug.Log(webRequest.text);
        webRequest.Dispose();
    }


    /*
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
               Debug.Log(result);
               LoginJson loginJson = JsonUtility.FromJson<LoginJson>(result);
               if (loginJson.result)
               {
                   SceneManager.LoadScene("TitleScene");
               }
           }
           else
               Debug.Log(www.error);
       }
     */
}
