using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move : MonoBehaviour
{
    float move_speed = 5f;
    // Update is called once per frame
    void Update()
    {
        charactermove();
    }
    void charactermove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-(move_speed * Time.deltaTime), 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(+(move_speed * Time.deltaTime), 0, 0);
        }

    }
}
