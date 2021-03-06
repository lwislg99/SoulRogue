using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impactacionScript : MonoBehaviour
{
    public float thrust;
    public float knockTime;
 
   
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if(enemy!=null)
            {
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                enemy.isKinematic = true;
            }
        }
    }
    private IEnumerator  KnockCo(Rigidbody2D enemy)
    {
        if(enemy ==null)
        {
            Debug.Log("edurne");
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                StartCoroutine(KnockCoroutine(enemy));
            }
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D enemy)
    {
        Vector2 forceDirection = enemy.transform.position - transform.position;
        Vector2 force = forceDirection.normalized * thrust;

        enemy.velocity = force;
        yield return new WaitForSeconds(.3f);

        enemy.velocity = new Vector2();
    }

}
