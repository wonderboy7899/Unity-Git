using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill002 : Skill
{
    GameObject Missile;

    public override void SetStatus()
    {
        SkillName = "���� �̻���";
        SkillInfo = "����ź�� ������ 3�� �� �þ�ϴ�.";
        Active = false;
        atk = 10;
        level = 1;
        coolTime = 1.5f;
    }

    public override void ActiveSkill()
    {
        int Max = level * 3;
        for (int x = 0; x < Max; x++)
        {
            Missile = Instantiate(ObjectManager.Instance.Missile2, SkillManager.Instance.GetRanPos(ObjectManager.Instance.Player), Quaternion.identity);
            Missile.transform.SetParent(ObjectManager.Instance.Clone.transform);
        }
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
