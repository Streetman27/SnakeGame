using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{

    public GameObject fruit;
    public Transform playerPosition;
    public Transform enemyPosition;

    public static bool onkoOlemassa = false;

    void Start()
    {
        /*
        if (!onkoOlemassa)
        {
            Invoke("Spawner", 1);
        }
        */
    }

    void FixedUpdate()
    {

        if (!onkoOlemassa)
        {
            Spawner();
        }

    }


    // Luo ehto, jossa tarkistetaan, onko hedelmä samassa paikassa kuin pelaaja tai vihollinen
    // Poista hedelmä ja nollaa pisteet. resettaa spawni (while methodilla kunnes hedelmä ei oo samassa kohdas kuin pelaaja tai vihoollinen?)
    // TAI
    // jos hedelmä ei ole samassa kohdassa kuin vihollinen ja pelaaja; spawnaa hedelmä
    void Spawner()
    {
        Instantiate(fruit, new Vector3(Random.Range(-4,4), Random.Range(0.5f,0.5f), Random.Range(-4,4)), Quaternion.identity);
        onkoOlemassa = true;
    }


}
