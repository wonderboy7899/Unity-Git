using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string           SkillName;
    public string           SkillInfo;
    public bool             Active;
    public int              atk;
    public int              level;
    public float            coolTime;

    public virtual void SetStatus()
    {

    }

    public virtual void ActiveSkill()
    {

    }
}