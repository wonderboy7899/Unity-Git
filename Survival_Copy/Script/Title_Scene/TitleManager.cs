using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    private static TitleManager instance = null;

    public GameObject Home_Panel;
    public GameObject Hangar_Panel;

    string BaseUrl = "http://127.0.0.1/";

    void Awake()
    {
        if (null == instance)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static TitleManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void LogOut_Btn()
    {
        StartCoroutine(LogOutCo());
    }

    IEnumerator LogOutCo()
    {
        WWWForm form = new WWWForm();
        form.AddField("User_ID", VarManager.User_ID);
        form.AddField("User_gold", ((int)VarManager.User_Gold).ToString());

        VarManager.User_ID = null;
        VarManager.User_Gold = 0;

        WWW webRequest = new WWW(BaseUrl + "Logout.php", form);
        yield return webRequest;

        Debug.Log(webRequest.text);
        webRequest.Dispose();
        SceneManager.LoadScene("Login");
    }

    public void GameStartBtn()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void OpenHangarBtn()
    {
        Home_Panel.SetActive(false);
        Hangar_Panel.SetActive(true);
    }

    public void CloseHangarBtn()
    {
        Hangar_Panel.SetActive(false);
        Home_Panel.SetActive(true);
    }

    public void Attack_Btn()
    {
        if (VarManager.User_Gold >= 500)
        {
            VarManager.User_Gold -= 500;
            VarManager.AtkDmg += 1;
        }
    }

    public void Move_Speed_Btn()
    {
        if (VarManager.User_Gold >= 500)
        {
            VarManager.User_Gold -= 500;
            VarManager.Speed += 1;
        }
    }

    public void Max_HP_Btn()
    {
        if (VarManager.User_Gold >= 500)
        {
            VarManager.User_Gold -= 500;
            VarManager.MaxHP += 10;
        }
    }

    public void OpenSettingBtn()
    {

    }
}
