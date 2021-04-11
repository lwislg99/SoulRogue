using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Enemigo : MonoBehaviour
{
    GameObject player;

    public EnemyState currState = EnemyState.Wander;

    public float range;
    public float speed;

    private bool chooseDir = false;
    private bool dead = false;
    private Vector3 randomDir;

    

    float dist;

    public float daño;

    public float dmgCoolDown;

    public float vidae = 10;

    float direccion;
    float tiempo;
    public float timer1;
    public float timer2;
    public float timer3;
    public float timer4;
    public Player playeri;
    public Animator anim;

    public float coldownDaño = 1;

    float RandomDir;

    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        playeri = FindObjectOfType<Player>();
        dmgCoolDown = 0;
        direccion = 1;
        tiempo = 0;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coldownDaño >= 0)
        {
            coldownDaño -= Time.deltaTime;

        }


        dmgCoolDown = dmgCoolDown + Time.deltaTime;
        float dist = Vector3.Distance(this.transform.position, playeri.transform.position);

        distance = Vector2.Distance(playeri.transform.position, transform.position);
        Vector2 playerDirection = (playeri.transform.position - transform.position);
        RaycastHit2D playerInfo = Physics2D.Raycast(transform.position, playerDirection, 1000f);
        if (playerInfo.collider.gameObject.tag == "Player" && distance<=5)
        {
            Debug.Log("pene");
            Follow();
        }
        else
        {
            Wander();
        }

        RaycastHit2D wallInfo = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 0.5f);


        if (vidae <= 0)
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, playeri.transform.position) <= range;
    }

    void Wander()
    {
        RaycastHit2D wallInfo = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 0.5f);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (wallInfo.collider.gameObject.tag == "pared")
        {
            Debug.Log("yes");
            RandomDir = Random.Range(0, 360);
            /*if (RandomDir <= 1)
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
            }*/
            transform.Rotate(new Vector3(0, 0, RandomDir));

        }
    }
    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, playeri.transform.position, speed * Time.deltaTime);

    }
    void Dmg()
    {
        if (dist <= 1 && dmgCoolDown >= 2)
        {
           playeri.vida = playeri.vida - daño;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
//other.gameObject.CompareTag("areaDaño")
        if (other.tag == "areaDaño" && coldownDaño <= 0)
        {
           
            vidae -= playeri.dano;
            coldownDaño = 1;

            if (playeri.balaDanoFuego == true)
            {
                vidae -= (Time.deltaTime / 2);
            }
           
        }
        if(other.tag == "Player" && dmgCoolDown >= 0)
        {
            anim.SetBool("atack", true);
            playeri.vida -= daño;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            anim.SetBool("atack", false);
        }
    }
}
