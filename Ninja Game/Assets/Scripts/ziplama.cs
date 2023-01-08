using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ziplama : MonoBehaviour
{
    public GameObject oyuncu;
    Rigidbody rb;
    public float hiz = 5.0f;
    public float ziplamaGucu = 10.0f;
    bool yerdeMi;

    void Start()
    {
        rb=oyuncu.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        //W-A-S-D ya Yön tuþlarýna basýlýrsa yatay adlý deðiþkene eksene göre deðer verir.
        float yatay = Input.GetAxis("Horizontal") * Time.deltaTime * hiz;
        oyuncu.transform.Translate(new Vector3(yatay, 0, 0)); // Y eksenini deðiþtir.
        if (Input.GetKeyDown(KeyCode.Space)) //Eðer Boþluk tuþuna basýlýrsa.
        {
            if (yerdeMi) //yerDemi deðiþkeni True ise içerisini gerçekleþtir.
            {

                rb.AddForce(new Vector3(0, ziplamaGucu, 0), ForceMode.Impulse);
            }
        }

    }
    private void OnCollisionStay(Collision collision) //Eðer sürekli platforma deðiyorsa
    {
        if (collision.gameObject.tag == "platform") //eðer platform etiketli nesneye deðerse
        {
            yerdeMi = true; //yerDemi deðiþkeninin deðerini true(doðru) yap.

        }

    }



    private void OnCollisionExit(Collision collision) // Eðer platforma deðme iþlemi bittiyse.
    {
        if (collision.gameObject.tag == "platform") //platform etiketli nesnelere deðmiyorsa
        {
            yerdeMi = false; //yerdeMi deðiþkeninin deðerini false(yanlýþ) yap.

        }

    }
}
