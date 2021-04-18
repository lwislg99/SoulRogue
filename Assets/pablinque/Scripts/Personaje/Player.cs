using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
public class Player : MonoBehaviour
{
    public Rigidbody2D JugadorRB;

    public bool movJugadorActivado = true;
    public bool da�oJugadorActivado = true;
    public bool ArcangelMiguel = true;
    public bool ArcangelGabriel = false;
    public bool ArcangelBombas = false;
    public bool Mandato1 = false;
    public bool Mandato2 = false;
    public bool interacionDisponible = false;
    public bool balaDanoFuego = false;
    public bool Dash = false;
    public bool cambio = false;

    public string angelGame;




    public Vector3 Movimiento;
    public Vector3 Ataque;



    public GameObject Jugador;
    public GameObject areaAtaqueMiguel;
    public GameObject prefabDisparo;
    public GameObject areaDanoExplosion;
    public GameObject visualBala;
    public GameObject prefabBomba;


    public float Velocidad = 0.1f;
    public float velocidadNormal = 0.1f;
    public float velocidadDash = 0.6f;
    public float vida = 10;
    public float vidaMax = 10;
    public float dano = 1;
    public float da�oAumentado = 3;
    public float da�oMegaAunmentado = 6;
    public float da�oBase = 1;
    public float coldownAtaque = 0.5f;
    public float delayAtaque = 0.5f;
    public float delayVida = 1f;
    public float delayHabilidades = 5f;
    public float delayTiempoAtaqueUp = 3f;
    public float delayExplosion = 0.3f;

    public float velocidadDisparo;
    public float ultimoDisparo;
    public float delayDisparo = 0.5f;

    public float tiempoDash;
    public float delayDash;
    public float guardarInputX;
    public float guardarInputY;




    public Animator anim;


    void Start()
    {
        JugadorRB = GetComponent<Rigidbody2D>();
        visualBala.SetActive(false);
        anim = GetComponent<Animator>();
    }


    void Update()
    {


        if (coldownAtaque >= 0)
        {
            coldownAtaque -= Time.deltaTime;
        }
        if (delayAtaque >= 0)
        {
            delayAtaque -= Time.deltaTime;
        }
        if (delayVida >= 0)
        {
            delayVida -= Time.deltaTime;
        }
        if (delayHabilidades >= 0)
        {
            delayHabilidades -= Time.deltaTime;
        }
        if (delayTiempoAtaqueUp >= 0)
        {
            delayTiempoAtaqueUp -= Time.deltaTime;
        }
        if (delayExplosion >= 0)
        {
            delayExplosion -= Time.deltaTime;
        }
        if (tiempoDash >= 0)
        {
            tiempoDash -= Time.deltaTime;
        }
        if (delayDash > 0)
        {
            delayDash -= Time.deltaTime;
        }



        if (delayTiempoAtaqueUp <= 0 && cambio == true)
        {
            dano = da�oBase;
            da�oJugadorActivado = true;
            /*prefabDisparo.transform.localScale = new Vector3(prefabDisparo.transform.localScale.x / 2, prefabDisparo.transform.localScale.y / 2, prefabDisparo.transform.localScale.z / 2);*/
            balaDanoFuego = false;
        }

        if (delayExplosion <= 0)
        {
            areaDanoExplosion.SetActive(false);
        }
        if (tiempoDash <= 0 && Dash == true)
        {

            Velocidad = velocidadNormal;
            delayDash = 3;
            da�oJugadorActivado = true;
            Dash = false;

        }


        if(angelGame == "ArcangelMiguel")
        {
            ArcangelMiguel = true;
            ArcangelGabriel = false;
            ArcangelBombas = false;
        }
        else if(angelGame == "ArcangelGabriel")
        {
            ArcangelGabriel = true;
            ArcangelMiguel = false;
            ArcangelBombas = false;
        }
        else if(angelGame=="ArcangelBombas")
        {
            ArcangelBombas = true;
            ArcangelGabriel = false;
            ArcangelMiguel = false;
        }



        if (movJugadorActivado == true)
        {


            //Para moverse normal
            if (Dash == false)
            {
                guardarInputX = Input.GetAxis("Horizontal");
                guardarInputY = Input.GetAxis("Vertical");

                Movimiento.x = (Velocidad * guardarInputX);
                Movimiento.y = (Velocidad * guardarInputY);

                //animacion movimiento
                anim.SetFloat("Andar x", Input.GetAxis("Horizontal"));
                anim.SetFloat("Andar y", Input.GetAxis("Vertical"));

            }


            //Para hacer el dash
            if (Input.GetKeyDown(KeyCode.Space) && Dash == false && delayDash <= 0)
            {

                Dash = true;
                Velocidad = velocidadDash;
                Movimiento.x = guardarInputX * Velocidad;
                Movimiento.y = guardarInputY * Velocidad;

                da�oJugadorActivado = false;
                tiempoDash = 0.15f;

            }

            //Con esto se mueve el personaje
            JugadorRB.MovePosition(transform.position + Movimiento);


            //recoge el input de ataque
            float ataqueHor = Input.GetAxis("ataqueVertical");
            float ataqueVer = Input.GetAxis("ataqueHorizontal");


            //animacion ataque
            anim.SetFloat("ataqueVertical", Input.GetAxis("ataqueVertical"));
            anim.SetFloat("ataqueHorizontal", Input.GetAxis("ataqueHorizontal"));

            if(Input.GetAxis("ataqueVertical")!=0|| Input.GetAxis("ataqueHorizontal")!=0)
            {
                anim.SetBool("noAtaque", true);
            }
            else
            {
                anim.SetBool("noAtaque", false);
            }



            //Para morirse
            if (vida <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }


            //para ejecutar la habilidad, todas estan llamadas como funciones para espacio
            if (Input.GetButtonDown("Habilidad") && interacionDisponible == false)
            {

                if (ArcangelMiguel == true)
                {

                    if (Mandato1 == true)
                    {
                        miguelMandamiento1();
                    }
                    else if (Mandato2 == true)
                    {
                        miguelMandamiento2();
                    }
                    else
                    {
                        miguelNoMandamiento();
                    }

                }
                else if (ArcangelGabriel == true)
                {
                    if (Mandato1 == true)
                    {
                        gabrielMandamiento1();
                    }
                    else if (Mandato2 == true)
                    {
                        gabrielMandamiento2();
                    }
                    else
                    {
                        gabrielNoMandamiento();
                    }

                }
                else if (ArcangelBombas ==true)
                {
                    if (Mandato1 == true)
                    {
                        bombasMandamiento1();
                    }
                    else if (Mandato2 == true)
                    {
                        bombasMandamiento2();
                    }
                    else
                    {
                        bombasNoMandamiento();
                    }
                }
            }

            //Manda la orden de ataque a la funcion
            if (coldownAtaque <= 0 && (ataqueHor != 0 || ataqueVer != 0))
            {
                ataque(ataqueHor, ataqueVer);
                coldownAtaque = 1.5f;
            }

            //esto sirve para quitar el area de ataque
            if (delayAtaque <= 0)
            {
                areaAtaqueMiguel.SetActive(false);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Para poder interactuar con el escenario (con esto desacticva las habilidades y activa el de interactua)
        if (collision.CompareTag("Interaccion"))
        {
            interacionDisponible = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Para desactivar el interactuar con el escenario
        if (other.CompareTag("Interaccion"))
        {
            interacionDisponible = false;
        }
    }


    void ataque(float x, float y)
    {
        //Diferentes tipos de ataques
        if (ArcangelMiguel == true)
        {
            areaAtaqueMiguel.transform.position = Jugador.transform.position + new Vector3(x, y, 0);

            areaAtaqueMiguel.SetActive(true);
            delayAtaque = 0.5f;
        }
        else if (ArcangelGabriel == true)
        {

            GameObject bullet = Instantiate(prefabDisparo, transform.position, transform.rotation) as GameObject;
            bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector3((x < 0) ? Mathf.Floor(x) * velocidadDisparo : Mathf.Ceil(x) * velocidadDisparo, (y < 0) ? Mathf.Floor(y) * velocidadDisparo : Mathf.Ceil(y) * velocidadDisparo, 0);
            //cambio = true;
        }
        else if(ArcangelBombas==true)
        {
             GameObject bomba = Instantiate(prefabBomba, this.transform) as GameObject;
            bomba.AddComponent<Rigidbody2D>().gravityScale = 0;
            bomba.GetComponent<Rigidbody2D>().velocity = new Vector3 (0 , 0 , 0);

        }
    }


    void miguelMandamiento1()
    {
        if (delayHabilidades <= 0)
        {
            delayTiempoAtaqueUp = 3;
            da�oJugadorActivado = false;
            delayHabilidades = 5;
            cambio = true;
        }
    }
    void miguelMandamiento2()
    {
        if (delayHabilidades <= 0)
        {
            delayTiempoAtaqueUp = 3;
            dano = da�oMegaAunmentado;
            cambio = true;


        }
    }
    void miguelNoMandamiento()
    {
        if (delayHabilidades <= 0)
        {
            vida += 2;
            dano = da�oAumentado;
            delayTiempoAtaqueUp = 3;
            delayHabilidades = 5;
            cambio = true;
            if (vida > vidaMax)
            {
                vida = vidaMax;
            }

        }
    }

    void gabrielMandamiento1()
    {
        if (delayHabilidades <= 0)
        {
            areaDanoExplosion.SetActive(true);

            delayExplosion = 0.3f;
            delayHabilidades = 5;
        }
    }

    void gabrielMandamiento2()
    {
        if (delayHabilidades <= 0)
        {
            balaDanoFuego = true;
            cambio = true;
            delayTiempoAtaqueUp = 3;
            delayHabilidades = 5;
        }
    }

    void gabrielNoMandamiento()
    {
        if (delayHabilidades <= 0)
        {
            /*prefabDisparo.transform.localScale = new Vector3(prefabDisparo.transform.localScale.x * 2, prefabDisparo.transform.localScale.y * 2, prefabDisparo.transform.localScale.z * 2);*/
            delayTiempoAtaqueUp = 3;
            delayHabilidades = 5;
        }
    }
    void bombasMandamiento1()
    {

    }
    void bombasMandamiento2()
    {

    }
    void bombasNoMandamiento()
    {

    }

}