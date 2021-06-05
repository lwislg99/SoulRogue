using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo3 : MonoBehaviour
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

    [SerializeField] Transform target1;
    [SerializeField] Transform target2;

    NavMeshAgent agent;

    public float target1Dist;
    public float target2Dist;
    public float playerDist;
    bool ida;
    public float rango = 13;
    bool disparo;

    public float rangoDisparo = 10;
    public float cooldownDisparo = 1.5f;
    float cooldownDisparoBase;

    public GameObject proyectilDisparo;
    public barraVida barraVidaI;
    // Start is called before the first frame update
    void Start()
    {
        playeri = FindObjectOfType<Player>();
        barraVidaI = GetComponentInChildren<barraVida>();
        dmgCoolDown = 0;

        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        ida = false;

        cooldownDisparoBase = cooldownDisparo;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        target1Dist = Vector2.Distance(target1.transform.position, transform.position);
        target2Dist = Vector2.Distance(target2.transform.position, transform.position);
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

    private void LateUpdate()
    {//Esto es para las animaciones del movimiento
        float velocityX = agent.velocity.x;
        float velocityY = agent.velocity.y;

        anim.SetFloat("Velx", velocityX);
        anim.SetFloat("Vely", velocityY);
        //ESto es para las animaciones de ataque,explosion
        Vector2 Direccionplayer = playeri.transform.position - this.transform.position;
        Direccionplayer.Normalize();
        float posicionx = Direccionplayer.x;
        float posiciony = Direccionplayer.y;
        anim.SetFloat("Atackx", posicionx);
        anim.SetFloat("Atacky", posiciony);

       
    }
    void Wander()
    {
        if (ida == false)
        {
            agent.SetDestination(target1.position);
            if (target1Dist <= 1)
            {
                ida = true;
            }
        }
        if (ida == true)
        {
            agent.SetDestination(target2.position);
            if (target2Dist <= 1)
            {
                ida = false;
            }
        }
    }

    void Follow()
    {
        //transform.position = Vector2.MoveTowards(transform.position, playeri.transform.position, speed * Time.deltaTime);
        if (disparo == false)
        {
            anim.ResetTrigger("Atack");
            agent.SetDestination(playeri.transform.position);
        }
        else
        {
            cooldownDisparo -= Time.deltaTime;
            agent.SetDestination(this.transform.position);
            if (cooldownDisparo <=0)
            {//animacion disparo
                anim.SetTrigger("Atack");


                Instantiate(proyectilDisparo, transform.position, transform.rotation);
                cooldownDisparo = cooldownDisparoBase;
            }
            
        }


    }

    void OnTriggerStay2D(Collider2D other)
    {
        playeri.SufrirDañoColor();

        //other.gameObject.CompareTag("areaDaño")
        if (other.tag == "areaDaño" && coldownDaño <= 0)
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
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && dmgCoolDown <= 0)
        {
            Debug.Log("entro");
            /*anim.SetBool("atack", true);
            playeri.vida -= daño;
            dmgCoolDown = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("atack", false);
        }
    }
    */
}
