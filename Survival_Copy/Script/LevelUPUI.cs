using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelUPUI : MonoBehaviour
{
    public GameObject          SkillIcons;
    public GameObject          Player;

    public List<Transform>      Icons;
    public List<int>            RanNum;
    public Transform[]          temp;                                                // ��ų������, �̸�, ����, ����

    // Start is called before the first frame update
    void Start()
    {
        RanNum = UIManager.Instance.GetRandomNum();
        for (int i = 0; i < SkillManager.Instance.SkillList.Count; i++)           // ��ų ������ ����Ʈ Icons �ʱ�ȭ
            Icons.Add(SkillIcons.transform.GetChild(i));

        SetIcon(RanNum);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetIcon(List<int> RanNum)
    {
        for (int i = 0; i < 3; i++)
        {
            // Firtst, Second, Third �� ���� ä���
            temp[i].GetChild(0).GetComponent<Image>().sprite = Icons[RanNum[i]].GetComponent<Image>().sprite;
            temp[i].GetChild(1).GetComponent<Text>().text = SkillManager.Instance.SkillList[RanNum[i]].SkillName;
            temp[i].GetChild(2).GetComponent<Text>().text = SkillManager.Instance.SkillList[RanNum[i]].level + "";
            temp[i].GetChild(3).GetComponent<Text>().text = "��ų �����";
        }
    }

    // ��ų ���ý� ������ �Լ� �����. 3�� OnClick()
    public void First()
    {
        Debug.Log(SkillManager.Instance.SkillList[RanNum[0]].level);
        SkillManager.Instance.SkillList[RanNum[0]].level += 1;
        Debug.Log(SkillManager.Instance.SkillList[RanNum[0]].level);
        UIManager.Instance.DesLevelUI();
    }

    public void Second()
    {
        SkillManager.Instance.SkillList[RanNum[1]].level += 1;  
        UIManager.Instance.DesLevelUI();
    }

    public void Third()
    {
        SkillManager.Instance.SkillList[RanNum[2]].level += 1;
        UIManager.Instance.DesLevelUI();
    }

    /*
     * ���콺 Ŭ�� ��ǥ ���ϴ� ��
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(),
        eventData.position, eventData.pressEventCamera, out Vector2 localCursor))
            return;

        Debug.Log("LocalCursor:" + localCursor);
    }
    */

    /*
     * ���� �ʱ�ȭ ����
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);                                     // ��ġ ����
        Player = GameObject.FindWithTag("Player");                                                              // �÷��̾ �������� ��ų����Ʈ (�̸�, ����, ���ݷ�, ��Ÿ��, �÷��̾� ���� ����)
        SkillList = Player.GetComponent<Player>().SkillList;
        SkillIcons = GameObject.Find("SkillIcons");

        for (int i = 0; i < SkillIcons.transform.childCount; i++)                                               // ��ų ������ ����Ʈ�� ������Ʈ ä���
        {
            Icons[i] = SkillIcons.transform.GetChild(i);
        }
        */
}
