using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    Vector3 target;
    Vector3 randomPosition;

    float radius = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemySpawnManager.Instance.CurEnemy < EnemySpawnManager.Instance.MaxEnemy)
        {
            Instantiate(ObjectManager.Instance.Enemy01, GetRandomPosition(radius), Quaternion.identity);
            EnemySpawnManager.Instance.CurEnemy += 1;
        }
        // Vector 인자를 사용하기 위해서 Quaternion rotation 필요함
    }

    public Vector3 GetRandomPosition(float radius)
    {
        float a = ObjectManager.Instance.Player.transform.position.x;
        float b = ObjectManager.Instance.Player.transform.position.y;

        float x = Random.Range(-radius + a, radius + a);
        float y_b = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x - a, 2));
        y_b *= Random.Range(0, 2) == 0 ? -1 : 1;
        float y = y_b + b;
        Vector3 randomPosition = new Vector3(x, y, 0);

        return randomPosition;
    }
}