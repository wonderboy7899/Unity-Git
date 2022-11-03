using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    int atk;
    GameObject ColObj;
    Vector2 dir;
    Vector2 target;

    private void OnTriggerEnter2D(Collider2D col)
    {
        ColObj = col.gameObject;

        if (ColObj.tag == "Player")
        {
            var ObjScript = ColObj.GetComponent<Player>();
            ObjScript.Status.NowHP -= atk;
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        atk = 5;

        Destroy(gameObject, 5);
        dir = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir.normalized * 5 * Time.deltaTime);
    }

    IEnumerator Explosive()
    {
        yield return new WaitForSeconds(2f);

    }
}
