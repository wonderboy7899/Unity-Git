using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Intercepter : MonoBehaviour
{
    public GameObject GameObject;       // 움직일 물체
    [Range(0, 1)]
    public float Test;

    public Vector3 P1;
    public Vector3 P2;
    public Vector3 P3;
    public Vector3 P4;

    public GameObject Player;
    public GameObject Boss1;
    public GameObject Missile;

    public Status Status;

    float speed;
    float dist = 0f;
    float radius = 5f;
    float incVal = 0.3f;

    Vector3 target;
    Vector3 Pos;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        Player = ObjectManager.Instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        var EnemySpawn = EnemySpawnManager.Instance;

        Test += (incVal * Time.deltaTime);

        if (Test > 1)
        {
            incVal *= -1;
        }
        else if (Test < 0)
        {
            incVal *= -1;
        }

        if (Test > 1)
        {
            P1 = EnemySpawn.GetRandomPosition(radius);
            P2 = EnemySpawn.GetRandomPosition(radius);
            P3 = EnemySpawn.GetRandomPosition(radius);
        }
        else if (Test < 0)
        {
            P2 = EnemySpawn.GetRandomPosition(radius);
            P3 = EnemySpawn.GetRandomPosition(radius);
            P4 = EnemySpawn.GetRandomPosition(radius);
        }

        GameObject.transform.position = BezzierTest(P1, P2, P3, P4, Test);
    }

    // 배지어 곡선
    public Vector3 BezzierTest(
        Vector3 P_1, 
        Vector3 P_2, 
        Vector3 P_3, 
        Vector3 P_4, 
        float Value
        )
    {
        Vector3 A = Vector3.Lerp(P_1, P_2, Value);
        Vector3 B = Vector3.Lerp(P_2, P_3, Value);
        Vector3 C = Vector3.Lerp(P_3, P_4, Value);

        Vector3 D = Vector3.Lerp(A, B, Value);
        Vector3 E = Vector3.Lerp(B, C, Value);
        Vector3 F = Vector3.Lerp(D, E, Value);

        return F;
    }

    public void Destroy()
    {

    }
}