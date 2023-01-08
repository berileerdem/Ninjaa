using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawnerL : MonoBehaviour
{
    public GameObject trapL;
    public float spawnRate;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnRate = Random.Range(3, 7);
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            timer = 0;
            spawnTrap();
        }

    }

    public void spawnTrap()
    {
        Instantiate(trapL, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }
}
