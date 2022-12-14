using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public UnitCode unitcode { get; }
    public string Enemyname { get; set; }
    public double MaxHP { get; set; }
    public double NowHP { get; set; }
    public double AtkDmg { get; set; }
    public double Def { get; set; }

    public Status()
    {

    }

    public Status(UnitCode unitcode, string Enemyname, double MaxHP, double AtkDmg, double Def)
    {
        this.unitcode = unitcode;
        this.Enemyname = Enemyname;
        this.MaxHP = MaxHP;
        NowHP = MaxHP;
        this.AtkDmg = AtkDmg;
        this.Def = Def;
    }

    public Status SetUnitStatus(UnitCode unitcode)
    {
        Status status = null;

        switch (unitcode)
        {
            case UnitCode.Player:
                status = new Status(unitcode, "Player", 50, 10, 0);             // 코드, 이름, 최대체력, 공격력, 방어력
                break;
            case UnitCode.Enemy01:
                status = new Status(unitcode, "Enemy01", 10, 0, 0);
                break;
            case UnitCode.Enemy02:
                status = new Status(unitcode, "Enemy02", 10, 0, 0);
                break;
            case UnitCode.Boss1:
                status = new Status(unitcode, "Boss1", 500, 10, 0);
                break;
        }
        return status;
    }
}
