using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillManager : MonoBehaviour
{
    private static SkillManager instance = null;

    public List<Skill> SkillList = new List<Skill>();                              // ��ų ���� (UIManager.cs, LevelUPUI.cs, SkillManager.cs, Skill000.cs ���� ��ũ��Ʈ�� ����)
    Skill001 S1 = new Skill001();
    Skill002 S2 = new Skill002();
    Skill003 S3 = new Skill003();
    Skill004 S4 = new Skill004();

    List<GameObject> IconList = new List<GameObject>();
    public GameObject[] SkillIcons;

    float Pos_X = 0f;
    float Pos_Y = -20f;

    void Awake()
    {
        if (null == instance)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    public static SkillManager Instance
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

    public void InitSkill()
    {
        SkillList.Add(S1);
        S1.SetStatus();
        SkillList.Add(S2);
        S2.SetStatus();
        SkillList.Add(S3);
        S3.SetStatus();
        SkillList.Add(S4);
        S4.SetStatus();
    }

    public void SkillSet()                                                          // InitSkill �� �Բ� Player �� Start ������ �ʱ�ȭ, UIManager DisLevelUI ���� ������ �Ҷ����� �����
    {
        for (int i = 0; i < SkillList.Count; i++)
        {
            if (SkillList[i].level > 0)
            {
                if (SkillList[i].Active == false)
                {
                    StartCoroutine(Fire(SkillList[i]));
                    SkillList[i].Active = true;
                }

                if (Pos_X == 200f)
                {
                    Pos_X = 0f;
                    Pos_Y -= 100f;
                }

                Vector2 temp = new Vector2(Pos_X, Pos_Y);
                if (SkillIcons[i].activeSelf == false)
                {
                    SkillIcons[i].GetComponent<RectTransform>().anchoredPosition = temp;
                    SkillIcons[i].SetActive(true);
                    Pos_X += 100f;
                }
            }
        }
    }

    IEnumerator Fire(Skill skill)                                           // ��ų ���
    {
        skill.ActiveSkill();
        SkillManager.Instance.DisSkillCool(skill);
        yield return new WaitForSeconds(skill.coolTime);

        if (GameManager.Instance.PlayerDied == true/* || �÷��̾� ������ ���� �߰� ���*/)                                              // �÷��̾� �����
        {
            StopCoroutine(Fire(skill));
        }
        else
        {
            StartCoroutine(Fire(skill));
        }
    }

    public void DisSkillCool(Skill skill)                           // ��Ÿ��
    {
        foreach (GameObject Obj in SkillIcons)
        {
            if (Obj.name == skill.SkillName)
            {
                StartCoroutine(coolTime(Obj.transform.GetChild(0).gameObject, Obj.transform.GetChild(1).gameObject, skill.coolTime, skill.coolTime));
            }
        }
    }

    IEnumerator coolTime(GameObject filter, GameObject Text, float cool, float maxcool)
    {
        if (cool == 0f)
        {
            Text.GetComponent<TextMeshProUGUI>().text = "";
            filter.GetComponent<Image>().fillAmount = 0;
        }
        while (cool > 0)
        {
            cool -= Time.deltaTime;
            Text.GetComponent<TextMeshProUGUI>().text = cool.ToString("F1") + "s";
            filter.GetComponent<Image>().fillAmount = (cool / maxcool);
            yield return new WaitForFixedUpdate();
        }
    }

    public Vector3 GetRanPos(GameObject player)
    {
        float a = player.transform.position.x;
        float b = player.transform.position.y;

        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        Vector3 Init_Pos = new Vector3(a += x, b += y, 0);
        return Init_Pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
