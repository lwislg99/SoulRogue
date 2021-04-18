using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo1 : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    public EnemyState currState = EnemyState.Wander;

    public float range;
    public float speed;

    public float daño;

    public float dmgCoolDown;

    public float vidae = 10;

    
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
    // Start is called before the first frame update
    void Start()
    {
        playeri = FindObjectOfType<Player>();
        dmgCoolDown = 0;
       
        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        ida = false;
    }

    // Update is called once per frame
    void Update()
    {

        target1Dist = Vector2.Distance(target1.transform.position, transform.position);
        target2Dist = Vector2.Distance(target2.transform.position, transform.position);
        playerDist = Vector2.Distance(playeri.transform.position, transform.position);

        //Animaciones
        
        
            Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

            // Map 'worldDeltaPosition' to local space
            float dx = Vector3.Dot(transform.right, worldDeltaPosition);
            float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

            // Low-pass filter the deltaMove
            float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
            smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

            // Update velocity if time advances
            if (Time.deltaTime > 1e-5f)
                velocity = smoothDeltaPosition / Time.deltaTime;

            bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

        // Update animation parameters
        anim.SetBool("move", shouldMove);
        anim.SetFloat("velx", velocity.x);
            anim.SetFloat("vely", velocity.y);

            GetComponent<LookAt>().lookAtTargetPosition = agent.steeringTarget + transform.forward;
        



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
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
    void OnAnimatorMove()
    {
        // Update position to agent position
        transform.position = agent.nextPosition;
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
        agent.SetDestination(playeri.transform.position);
        
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



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && dmgCoolDown <= 0)
        {
            Debug.Log("entro");
            /*anim.SetBool("atack", true);*/
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
}
