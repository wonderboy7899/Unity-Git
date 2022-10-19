using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    private static EnemySpawnManager instance = null;

    public int MaxEnemy;
    public int CurEnemy = 0;

    public bool PlayerDied = false;
    void Awake()
    {
        if (null == instance)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static EnemySpawnManager Instance
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

    public int SetMaxEnemySpawn(float TimeCur)
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
