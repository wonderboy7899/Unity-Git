using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject Sprites;
    public Transform BackG;

    GameObject Player;
    float spriteSize = 40.9f;
    int x = 0;
    int y = 0;
    int temp_x = 0;
    int temp_y = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = ObjectManager.Instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        x = (int)(Player.transform.position.x / 40.9);
        y = (int)(Player.transform.position.y / 40.9);

        setBackground();
    }

    public void setBackground()
    {
        if (temp_x != x || temp_y != y)
        {
            if (x < temp_x && y != temp_y)                  // x < 0 && y != 0
            {
                //Debug.Log("x : " + x + ", " + "temp_x : " + temp_x);
                //Debug.Log("y : " + y + ", " + "temp_y : " + temp_y);
                if (y > temp_y)
                {
                    genBackground(x - 1, y + 1);
                    genBackground(x - 1, y);
                    genBackground(x - 1, y - 1);
                    genBackground(x, y + 1);
                    genBackground(x + 1, y + 1);
                }
                else if (y < temp_y)
                {
                    genBackground(x - 1, y - 1);
                    genBackground(x, y - 1);
                    genBackground(x + 1, y - 1);
                    genBackground(x - 1, y);
                    genBackground(x - 1, y + 1);
                }
            }
            else if (x > temp_x && y != temp_y)             // x > 0 && y != 0
            {
                //Debug.Log("x : " + x + ", " + "temp_x : " + temp_x);
                //Debug.Log("y : " + y + ", " + "temp_y : " + temp_y);
                if (y > temp_y)
                {
                    genBackground(x + 1, y - 1);
                    genBackground(x + 1, y);
                    genBackground(x + 1, y + 1);
                    genBackground(x, y + 1);
                    genBackground(x - 1, y + 1);
                }
                else if (y < temp_y)
                {
                    genBackground(x + 1, y - 1);
                    genBackground(x, y - 1);
                    genBackground(x - 1, y - 1);
                    genBackground(x + 1, y);
                    genBackground(x + 1, y + 1);
                }
            }
            else if (x == temp_x && y != temp_y)            // x == 0 && y != 0
            {
                //Debug.Log("x : " + x + ", " + "temp_x : " + temp_x);
                //Debug.Log("y : " + y + ", " + "temp_y : " + temp_y);
                if (y > temp_y)
                {
                    genBackground(x + 1, y + 1);
                    genBackground(x - 1, y + 1);
                    genBackground(x, y + 1);
                }
                else if (y < temp_y)
                {
                    genBackground(x + 1, y - 1);
                    genBackground(x - 1, y - 1);
                    genBackground(x, y - 1);
                }
            }
            else if (x != temp_x && y == temp_y)            // x != 0 && y == 0
            {
                //Debug.Log("x : " + x + ", " + "temp_x : " + temp_x);
                //Debug.Log("y : " + y + ", " + "temp_y : " + temp_y);
                if (x > temp_x)
                {
                    genBackground(x + 1, y + 1);
                    genBackground(x + 1, y - 1);
                    genBackground(x + 1, y);
                }
                else if (x < temp_x)
                {
                    genBackground(x - 1, y + 1);
                    genBackground(x - 1, y - 1);
                    genBackground(x - 1, y);
                }
            }
            temp_x = x;
            temp_y = y;
        }
    }

    public void genBackground(float PosX, float PosY)
    {
        Vector2 Pos = new Vector2(PosX * spriteSize, PosY * spriteSize);
        Instantiate(Sprites, Pos, Quaternion.identity);                             // BackGround 를 부모로 두고 생성하게 고쳐야함, transform.parent 안 먹힘(???) / 변수설정하고 부모 설정하는것도 해봄
    }
}
