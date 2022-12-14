using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill003 : Skill
{
    public GameObject SkillIcon;

    GameObject Barrier;

    public override void SetStatus()
    {
        SkillName = "디플렉터 실드";
        SkillInfo = "적의 공격을 방어하는 방어막을 생성합니다.";
        Active = false;
        atk = 10;
        level = 0;
        coolTime = 30f;
    }

    public override void ActiveSkill()
    {
        var Script = ObjectManager.Instance.PBarrier.GetComponent<Barrier>();
        if (level == 1)                                     // 레벨별 수치 조정
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
