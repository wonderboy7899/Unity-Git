using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill003 : Skill
{
    public GameObject SkillIcon;

    GameObject Barrier;

    public override void SetStatus()
    {
        SkillName = "���÷��� �ǵ�";
        SkillInfo = "���� ������ ����ϴ� ���� �����մϴ�.";
        Active = false;
        atk = 10;
        level = 0;
        coolTime = 30f;
    }

    public override void ActiveSkill()
    {
        var Script = ObjectManager.Instance.PBarrier.GetComponent<Barrier>();
        if (level == 1)                                     // ������ ��ġ ����
        {
            ObjectManager.Instance.PBarrier.SetActive(true);
            Script.Def = 50;
        }
        else if (level >= 2)
        {
            ObjectManager.Instance.PBarrier.SetActive(true);
            Script.Def = 100;
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
