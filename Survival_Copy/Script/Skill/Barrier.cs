using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public double Def = 0;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = ObjectManager.Instance.Player;
        transform.position = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Def == 0)
        {
            ObjectManager.Instance.PBarrier.SetActive(false);
            Def = 0;
        }
    }
}
