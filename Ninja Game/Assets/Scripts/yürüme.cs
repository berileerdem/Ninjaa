using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class yürüme : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public Transform right;
    public Transform left;
    private float yatayHareket;
    public float jump;
    public float hareketHızı;
    public float limitX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
    }

   
    void Update()
    {
        yatayHareket = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(yatayHareket * hareketHızı* 225 *Time.deltaTime,rb.velocity.y);

        if (transform.position.y < 0.085f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jump);
                anim.SetBool("isjumping", true);
            }
            else
            {
                anim.SetBool("isjumping", false);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isrunning", true);
            transform.LookAt(left);
        }
        else
        {
            anim.SetBool("isrunning", false);
        }


        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isrun", true);
            transform.LookAt(right);
        }
        else
        {
            anim.SetBool("isrun", false);
        }

        float xPosition = Mathf.Clamp(transform.position.x, -limitX, limitX);
        transform.position=new Vector2(xPosition, transform.position.y);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectWithTag("Trap"))
        {
            TrapDestroy();
            Debug.Log("Acıdı aga !");
            UIManager.UI.canazalt();
        }
    }
    public void TrapDestroy()
    {
        Destroy(GameObject.FindGameObjectWithTag("Trap"));
    }
}
