using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo1 : MonoBehaviour
{

    NavMeshAgent agent;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

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



    public float target1Dist;
    public float target2Dist;
    public float playerDist;
    public float atackTargetDist;
    bool ida;
    public float rango = 13;
    public barraVida barraVidaI;

    public bool dummy = false;
    public GameObject Alert;
    bool Exclamacion;
    float alertTime;
    public float rangoAtaque = 3;
    public bool ataque;

    public Color blanco;
    public Color normal;
    public Color normal2;
    SpriteRenderer Renderer;

    public GameObject areaDañoE1;

    bool AreaDaño;

    public float atackSpeed = 20;
    public float atackTime=1;

    Vector3 atackTarget;
    public float cooldownAtaque;
    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        playeri = FindObjectOfType<Player>();
        dmgCoolDown = 0;

        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

        barraVidaI = GetComponentInChildren<barraVida>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        ida = false;

        alertTime = 1.5f;
        Exclamacion = true;
        ataque = false;

        AreaDaño = true;

        cooldownAtaque = 0;

    }

    // Update is called once per frame
    void Update()
    {

        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        target1Dist = Vector2.Distance(target1.transform.position, transform.position);
        target2Dist = Vector2.Distance(target2.transform.position, transform.position);
        playerDist = Vector2.Distance(playeri.transform.position, transform.position);
        


        cooldownAtaque -= Time.deltaTime;


        if (coldownDaño >= 0)
        {
            coldownDaño -= Time.deltaTime;

        }

        if (dmgCoolDown >= 0)
        {
            dmgCoolDown -= Time.deltaTime;
        }
        //float dist = Vector3.Distance(this.transform.position, playeri.transform.position);

        //distance = Vector2.Distance(playeri.transform.position, transform.position);
        Vector2 playerDirection = (playeri.transform.position - transform.position);
        RaycastHit2D playerInfo = Physics2D.Raycast(transform.position, playerDirection, 1000f);

        if (dummy == true)
        {
            if (vidae <= 0)
            {
                vidae = vidaeMax;
            }
        }
        else
        {
            if (playerInfo.collider.gameObject.tag == "Player" && playerDist <= rango && playerDist > rangoAtaque && ataque == false)
            {
                Debug.Log("SIGUIENDO");
                Follow();
                
            }
            else if(playerDist <= rangoAtaque && cooldownAtaque <= 0)
            {
                
                
                ataque = true;
                Renderer.color = blanco;
                Invoke("Ataque", 1.0f);
            }else if(playerDist > rango && ataque== false)
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



    }

    private void LateUpdate()
    {
        float velocityX = agent.velocity.x;
        float velocityY = agent.velocity.y;

        anim.SetFloat("Movx", velocityX);
        anim.SetFloat("Movy", velocityY);
    }
    void Wander()
    {
        Alert.gameObject.SetActive(false);
        Exclamacion = true;
        alertTime = 1.5f;

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
        alertTime -= Time.deltaTime;
        if (Exclamacion == true)
        {
            Debug.Log("sdadsg");
            Alert.gameObject.SetActive(true);
            if (alertTime <= 0)
            {
                Exclamacion = false;
            }
        }
        else
        {
            Alert.gameObject.SetActive(false);
        }
        
        //transform.position = Vector2.MoveTowards(transform.position, playeri.transform.position, speed * Time.deltaTime);
        agent.SetDestination(playeri.transform.position);
        atackTarget = playeri.transform.position;
        

    }
    void Ataque()
    {
        Renderer.color = normal2;
        GetComponent<NavMeshAgent>().speed = 10;
        agent.SetDestination(atackTarget);

        if (AreaDaño == true)
        {
            Instantiate(areaDañoE1, transform.position, transform.rotation);
            AreaDaño = false;
        }
       
            
        
        
        Invoke("Ataqueno", 0.5f);

    }
    void Ataqueno()
    {
        GetComponent<NavMeshAgent>().speed = 4;
        ataque = false;
        AreaDaño = true;
        cooldownAtaque = 4;
    }
    
    void OnTriggerStay2D(Collider2D other)
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

            barraVidaI.UpdateHealth();
        }



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (dummy == false)
        {
            if (collision.gameObject.tag == "Player" && dmgCoolDown <= 0)
            {
                Debug.Log("entro");
                /*anim.SetBool("atack", true);*/
                //playeri.vida -= daño;
                dmgCoolDown = 1;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("atack", false);
        }
    }
    
}
