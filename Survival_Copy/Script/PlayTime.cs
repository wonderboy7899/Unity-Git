using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTime : MonoBehaviour
{
    public GameObject EnemySpawnSys;

    public float TimeStart = 0f;
    public float TimeCur;
    public float TimeMax;

    // Start is called before the first frame update
    void Start()
    {
        TimeCur = TimeStart;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCur += Time.deltaTime;
        GameManager.Instance.TimeCur = TimeCur;
        UIManager.Instance.PlayTime.text = ReturnTimeToString(TimeCur);
        EnemySpawnManager.Instance.MaxEnemy = EnemySpawnManager.Instance.SetMaxEnemySpawn(TimeCur);

        if (TimeCur > 10f && TimeCur < 10.1f)//TimeCur > 300f && TimeCur < 300.1f)
        {
            EnemySpawnManager.Instance.SpawnBoss(ObjectManager.Instance.Boss1);
            ObjectManager.Instance.RedField.transform.position = ObjectManager.Instance.Player.transform.position;
            ObjectManager.Instance.RedField.SetActive(true);
            UIManager.Instance.BossHealth.SetActive(true);
            UIManager.Instance.BossName.text = "Boss1";
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
