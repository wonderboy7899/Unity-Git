using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretS : MonoBehaviour
{
    public GameObject Boss;

    float speed = 20f;

    GameObject ColObj;
    GameObject Player;

    Rigidbody2D rb;
    Quaternion rotTarget;
    Quaternion rotation;

    Vector2 Pos;
    Vector3 dir;
    Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        Player = ObjectManager.Instance.Player;
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            target = Player.transform.position;
        }

        Pos = transform.position;
        dir = (target - Pos);

        var BossScript = Boss.GetComponent<Boss1>();
        float angle = BossScript.angle;
        rotTarget = Quaternion.AngleAxis(angle, Vector3.back);
        rotation = Quaternion.Slerp(transform.rotation, rotTarget, Time.deltaTime * 20f);
        transform.rotation = rotation;
    }

    IEnumerator Fire()
    {
        Vector3 MissileVector = gameObject.transform.rotation.eulerAngles;
        Instantiate(ObjectManager.Instance.EnemyMissile, gameObject.transform.position, Quaternion.Euler(0, 0, MissileVector.z)).transform.SetParent(ObjectManager.Instance.Clone.transform);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Fire());
    }
}
