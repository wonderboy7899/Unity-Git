using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTime : MonoBehaviour
{
    public GameObject EnemySpawnSys;

    private float TimeStart = 0f;
    private float TimeCur;
    private float TimeMax;

    // Start is called before the first frame update
    void Start()
    {
        TimeCur = TimeStart;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCur += Time.deltaTime;
        UIManager.Instance.PlayTime.text = ReturnTimeToString(TimeCur);
        EnemySpawnManager.Instance.MaxEnemy = EnemySpawnManager.Instance.SetMaxEnemySpawn(TimeCur);

        if (TimeCur > 300f)
        {
            //EnemySpawnManager.Instance.() 보스 몬스터 스폰함수 실행.
        }
        else if (TimeCur > 600f)
        {
            //EnemySpawnManager.Instance.()
        }
        else if (TimeCur > 900f)
        {
            //EnemySpawnManager.Instance.()
        }
        else if (TimeCur > 1200f)
        {
            //EnemySpawnManager.Instance.()
        }
    }

    // 시간에 따른 적 스폰 패턴 함수 생성

    string ReturnTimeToString(float TimeCur)
    {
        int min = 0;
        int sec = 0;
        int T = (int)TimeCur;
        string result = null;

        min = T / 60;
        sec = T % 60;
        
        if (min < 10)
        {
            result += ("0" + min.ToString());
        }
        else if (min > 10)
        {
            result += min.ToString();
        }
        else if (min < 1)
        {
            result += "00";
        }

        result += " : ";

        if (sec < 10)
        {
            result += ("0" + sec.ToString());
        }
        else
        {
            result += sec.ToString();
        }

        return result;
    }
}
