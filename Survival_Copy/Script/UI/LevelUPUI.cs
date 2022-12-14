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

    }

    // Update is called once per frame
    void Update()
    {

    }


    // ��ų ���ý� ������ �Լ� �����. 3�� OnClick()
    public void First()
    {
        SkillManager.Instance.SkillList[UIManager.Instance.RanNum[0]].level += 1;
        UIManager.Instance.DesLevelUI();
    }

    public void Second()
    {
        SkillManager.Instance.SkillList[UIManager.Instance.RanNum[1]].level += 1;  
        UIManager.Instance.DesLevelUI();
    }

    public void Third()
    {
        SkillManager.Instance.SkillList[UIManager.Instance.RanNum[2]].level += 1;
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
