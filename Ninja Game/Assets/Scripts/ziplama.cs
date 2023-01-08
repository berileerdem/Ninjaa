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
        //W-A-S-D ya Y�n tu�lar�na bas�l�rsa yatay adl� de�i�kene eksene g�re de�er verir.
        float yatay = Input.GetAxis("Horizontal") * Time.deltaTime * hiz;
        oyuncu.transform.Translate(new Vector3(yatay, 0, 0)); // Y eksenini de�i�tir.
        if (Input.GetKeyDown(KeyCode.Space)) //E�er Bo�luk tu�una bas�l�rsa.
        {
            if (yerdeMi) //yerDemi de�i�keni True ise i�erisini ger�ekle�tir.
            {

                rb.AddForce(new Vector3(0, ziplamaGucu, 0), ForceMode.Impulse);
            }
        }

    }
    private void OnCollisionStay(Collision collision) //E�er s�rekli platforma de�iyorsa
    {
        if (collision.gameObject.tag == "platform") //e�er platform etiketli nesneye de�erse
        {
            yerdeMi = true; //yerDemi de�i�keninin de�erini true(do�ru) yap.

        }

    }



    private void OnCollisionExit(Collision collision) // E�er platforma de�me i�lemi bittiyse.
    {
        if (collision.gameObject.tag == "platform") //platform etiketli nesnelere de�miyorsa
        {
            yerdeMi = false; //yerdeMi de�i�keninin de�erini false(yanl��) yap.

        }

    }
}
