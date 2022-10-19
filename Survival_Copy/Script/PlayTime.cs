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
        UIManager.Instance.PlayTime.text = ReturnTime(TimeCur);

        // 현재 TimeCur 에 따라서 적 스폰 최대수를 설정하는 구문 작성필요. SpawnScript 에 스크립트 저장해놨음.
        EnemySpawnSys.GetComponent<EnemySpawn>().MaxEnemy = SetMaxEnemySpawn(TimeCur);
    }

    // 시간에 따른 적 스폰 패턴 함수 생성

    int SetMaxEnemySpawn(float TimeCur)
    {
        if (TimeCur < 10)
        {
            return 10;
        }
        else if (10 <= TimeCur && TimeCur < 60)
        {
            return 20;
        }
        else if (60 <= TimeCur && TimeCur < 180)
        {
            return 50;
        }
        else if (180 <= TimeCur && TimeCur < 300)
        {
            return 100;
        }
        else
            return 200;
    }

    string ReturnTime(float TimeCur)
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
