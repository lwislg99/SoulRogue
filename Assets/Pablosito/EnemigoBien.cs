using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBien : MonoBehaviour
{
    public float speed = 2;
    public float distance;
   
   
    float RandomDir;
    public GameObject playeri;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(playeri.transform.position, transform.position);
        Vector2 playerDirection = (playeri.transform.position - transform.position);
        RaycastHit2D playerInfo = Physics2D.Raycast(transform.position, playerDirection, 1000f);
        if (playerInfo.collider.gameObject.tag == "Player" /*&& distance<=10*/)
        {
            Debug.Log("pene");
            Follow();
        }else
        {
            Wander();
        }
        
        RaycastHit2D wallInfo = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 0.5f);




    }
    
    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, playeri.transform.position, speed * Time.deltaTime);
    }
    void Wander()
    {
        RaycastHit2D wallInfo = Physics2D.Raycast(transform.position,transform.TransformDirection( Vector2.right), 0.5f);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (wallInfo.collider.gameObject.tag == "pared")
        {
            Debug.Log("yes");
            RandomDir = Random.Range(0, 4);
            if (RandomDir <= 1)
            {
                transform.Rotate(new Vector3(0, 0, 90));
            }
            if (RandomDir > 1 && RandomDir <= 2)
            {
                transform.Rotate(new Vector3(0, 0, 180));
            }
            if (RandomDir > 2 && RandomDir <= 3)
            {
                transform.Rotate(new Vector3(0, 0, 270));
            }
            if (RandomDir > 3 && RandomDir <= 4)
            {
                transform.Rotate(new Vector3(0, 0, 360));
            }


        }
    }
    
}
