using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
public class Player : MonoBehaviour
{
    public Rigidbody2D JugadorRB;

    public bool movJugadorActivado = true;
    public bool dañoJugadorActivado = true;
    public bool ArcangelMiguel = true;
    public bool ArcangelGabriel = false;
    public bool Mandato1 = false;
    public bool Mandato2 = false;
    public bool interacionDisponible = false;
    public bool balaDanoFuego = false;
    public bool Dash = false;
    public bool cambio = false;




    public Vector3 Movimiento;
    public Vector3 Ataque;



    public GameObject Jugador;
    public GameObject areaAtaqueMiguel;
    public GameObject prefabDisparo;
    public GameObject areaDanoExplosion;
    public GameObject visualBala;


    public float Velocidad = 0.1f;
    public float velocidadNormal = 0.1f;
    public float velocidadDash = 0.6f;
    public float vida = 10;
    public float vidaMax = 10;
    public float dano = 1;
    public float dañoAumentado = 3;
    public float dañoMegaAunmentado = 6;
    public float dañoBase = 1;
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
            dano = dañoBase;
            dañoJugadorActivado = true;
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
            dañoJugadorActivado = true;
            Dash = false;

        }


        if (movJugadorActivado == true)
        {



            if (Dash == false)
            {
                guardarInputX = Input.GetAxis("Horizontal");
                guardarInputY = Input.GetAxis("Vertical");

                Movimiento.x = (Velocidad * guardarInputX);
                Movimiento.y = (Velocidad * guardarInputY);

                anim.SetFloat("Andar x", Input.GetAxis("Horizontal"));
                anim.SetFloat("Andar y", Input.GetAxis("Vertical"));

                

            }



            if (Input.GetKeyDown(KeyCode.Space) && Dash == false && delayDash <= 0)
            {

                Dash = true;
                Velocidad = velocidadDash;
                Movimiento.x = guardarInputX * Velocidad;
                Movimiento.y = guardarInputY * Velocidad;

                dañoJugadorActivado = false;
                tiempoDash = 0.15f;


            }


            JugadorRB.MovePosition(transform.position + Movimiento);

            float ataqueHor = Input.GetAxis("ataqueVertical");
            float ataqueVer = Input.GetAxis("ataqueHorizontal");

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


            if (vida <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }

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
            }
            if (coldownAtaque <= 0 && (ataqueHor != 0 || ataqueVer != 0))
            {
                ataque(ataqueHor, ataqueVer);
                coldownAtaque = 1.5f;
            }


            if (delayAtaque <= 0)
            {
                //esto seirve para quitar el area
                areaAtaqueMiguel.SetActive(false);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.CompareTag("Enemy") && delayVida <= 0 && dañoJugadorActivado == true)
        {
            vida--;
            delayVida = 1;
        }
        */

        if (collision.CompareTag("Interaccion"))
        {
            interacionDisponible = true;


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interaccion"))
        {
            interacionDisponible = false;
        }
    }


    void ataque(float x, float y)
    {

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
            cambio = true;
        }
    }


    void miguelMandamiento1()
    {
        if (delayHabilidades <= 0)
        {
            delayTiempoAtaqueUp = 3;
            dañoJugadorActivado = false;
            delayHabilidades = 5;
            cambio = true;
        }
    }
    void miguelMandamiento2()
    {
        if (delayHabilidades <= 0)
        {
            delayTiempoAtaqueUp = 3;
            dano = dañoMegaAunmentado;
            cambio = true;


        }
    }
    void miguelNoMandamiento()
    {
        if (delayHabilidades <= 0)
        {
            vida += 2;
            dano = dañoAumentado;
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

}
