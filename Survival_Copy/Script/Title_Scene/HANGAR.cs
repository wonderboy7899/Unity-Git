using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HANGAR : MonoBehaviour
{
    public Image[] SpaceShip;

    int arrayLength = 0;
    int index = 0;

    public TextMeshProUGUI Cur_Gold;

    // Start is called before the first frame update
    void Start()
    {
        arrayLength = SpaceShip.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Cur_Gold.text = ((int)VarManager.User_Gold).ToString();
    }

    public void RightClick_Btn()
    {
        if ((index + 1) == arrayLength)
        {
            SpaceShip[index].gameObject.SetActive(false);
            index = 0;
            SpaceShip[index].gameObject.SetActive(true);
        }
        else
        {
            SpaceShip[index].gameObject.SetActive(false);
            index += 1;
            SpaceShip[index].gameObject.SetActive(true);
        }
    }

    public void LeftClick_Btn()
    {
        if ((index - 1) < 0)
        {
            Debug.Log(arrayLength);
            SpaceShip[index].gameObject.SetActive(false);
            index = arrayLength - 1;
            SpaceShip[index].gameObject.SetActive(true);
        }
        else
        {
            SpaceShip[index].gameObject.SetActive(false);
            index -= 1;
            SpaceShip[index].gameObject.SetActive(true);
        }
    }

    public void Init_Variable()
    {
        arrayLength = 0;
        index = 0;
    }

    public void Select_Btn()
    {
        TitleManager.Instance.Home_Panel.gameObject.SetActive(true);
        Init_Variable();
        TitleManager.Instance.Hangar_Panel.gameObject.SetActive(false);
    }
}
