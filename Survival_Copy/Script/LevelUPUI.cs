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
    public Transform[]          temp;                                                // 스킬아이콘, 이름, 레벨, 정보

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    // 스킬 선택시 실행할 함수 만들기. 3개 OnClick()
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
     * 마우스 클릭 좌표 구하는 법
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(),
        eventData.position, eventData.pressEventCamera, out Vector2 localCursor))
            return;

        Debug.Log("LocalCursor:" + localCursor);
    }
    */

    /*
     * 변수 초기화 구문
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);                                     // 위치 조정
        Player = GameObject.FindWithTag("Player");                                                              // 플레이어가 보유중인 스킬리스트 (이름, 레벨, 공격력, 쿨타임, 플레이어 보유 여부)
        SkillList = Player.GetComponent<Player>().SkillList;
        SkillIcons = GameObject.Find("SkillIcons");

        for (int i = 0; i < SkillIcons.transform.childCount; i++)                                               // 스킬 아이콘 리스트에 오브젝트 채우기
        {
            Icons[i] = SkillIcons.transform.GetChild(i);
        }
        */
}
