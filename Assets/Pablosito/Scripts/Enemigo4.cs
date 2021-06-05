using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo4 : MonoBehaviour
{
    GameObject player;

    public EnemyState currState = EnemyState.Wander;

    public float range;
    public float speed;

    public float daño;

    public float dmgCoolDown;

    public float vidae = 10;
    public float vidaeMax = 10;

    public Player playeri;
    public Animator anim;

    public float coldownDaño = 1;

    float RandomDir;

    public float distance;



    NavMeshAgent agent;

    public float target1Dist;
    public float target2Dist;
    public float playerDist;
    bool ida;
    public float rango = 13;
    bool disparo;

    public float rangoDisparo = 10;
    public float cooldownDisparo = 5f;
    float cooldownDisparoBase;
    public float cooldownInvencible = 3f;
    float cooldownInvencibleBase;

    public GameObject proyectilDisparo;
    public barraVida barraVidaI;

    bool invencible;

    public Color verde;
    public Color rojo;
    SpriteRenderer Renderer;
    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        playeri = FindObjectOfType<Player>();
        barraVidaI = GetComponentInChildren<barraVida>();
        dmgCoolDown = 0;

        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        ida = false;

        cooldownDisparoBase = cooldownDisparo;
        cooldownInvencibleBase = cooldownInvencible;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = new Quaternion(0, 0, 0, 0);

        playerDist = Vector2.Distance(playeri.transform.position, transform.position);

        if (playerDist <= rangoDisparo)
        {
            disparo = true;
        }
        else
        {
            disparo = false;
        }

        if (coldownDaño >= 0)
        {
            coldownDaño -= Time.deltaTime;

        }
        if (invencible == true)
        {
            Renderer.color = rojo;
        }
        else
        {
            Renderer.color = verde;

        }
        /*
        if (dmgCoolDown >= 0)
        {
            dmgCoolDown -= Time.deltaTime;
        }*/
        //float dist = Vector3.Distance(this.transform.position, playeri.transform.position);

        //distance = Vector2.Distance(playeri.transform.position, transform.position);
        Vector2 playerDirection = (playeri.transform.position - transform.position);
        RaycastHit2D playerInfo = Physics2D.Raycast(transform.position, playerDirection, 1000f);

        if (playerInfo.collider.gameObject.tag == "Player" && playerDist <= rango)
        {
            Debug.Log("SIGUIENDO");
            Follow();
        }

        else
        {
            Wander();
        }

        RaycastHit2D wallInfo = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 0.5f);


        if (vidae <= 0)
        {
            playeri.numeroMuertes++;
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }


    void Wander()
    {
        invencible = true;
        agent.SetDestination(this.transform.position);
    }

    void Follow()
    {

        //transform.position = Vector2.MoveTowards(transform.position, playeri.transform.position, speed * Time.deltaTime);
        if (disparo == false)
        {
            invencible = true;
            agent.SetDestination(this.transform.position);
        }
        else
        {
            agent.SetDestination(this.transform.position);
            cooldownDisparo -= Time.deltaTime;
            if (cooldownDisparo <= 0)
            {
                Instantiate(proyectilDisparo, transform.position, transform.rotation);
                cooldownDisparo = cooldownDisparoBase;
            }
            else if (cooldownDisparo >= 3 && cooldownDisparo < 5)
            {
                invencible = false;
            }
            else
            {
                invencible = true;
            }






        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {


        //other.gameObject.CompareTag("areaDaño")
        if (other.tag == "areaDaño" && coldownDaño <= 0 && invencible == false)
        {

            vidae -= playeri.dano;
            coldownDaño = 1;

            if (playeri.balaDanoFuego == true)
            {
                vidae -= (Time.deltaTime / 2);
            }

            barraVidaI.UpdateHealth();

        }



    }
}
