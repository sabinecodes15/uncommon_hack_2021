using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;
    private bool _isEnemyLaser = false;

   

    // Update is called once per frame
    void Update()
    {
        if(_isEnemyLaser == false)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
        
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        //transform.Translate(Vector3.right * Time.deltaTime * speed);

        //destroy
        if (transform.position.y > 8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }

    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        //transform.Translate(Vector3.right * Time.deltaTime * speed);

        //destroy
        if (transform.position.y > 8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }

    }

    public void AssignEnemy()
    {
        _isEnemyLaser = true;
    }
}
