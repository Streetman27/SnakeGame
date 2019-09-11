using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool canTurn;
    Vector3 direction;
    Vector3 previousPosition;
    public GameObject tail;
    public static int points;
    private int lives;
    private int stage;

    public Text pointsText;
    public Text liveText;

    AudioSource AS;
    public AudioClip[] aanet;

    void Start()
    {
        lives = PlayerPrefs.GetInt("Lives");
        Invoke("MoveForward", 1);
        direction = Vector3.zero;
        AS = GetComponent<AudioSource>();
        UpdateLives();

        //Debug.Log("Elämii: " + PlayerPrefs.GetInt("Lives"));
    }

    void Update()
    {


        if (Input.GetAxisRaw("Horizontal") == -1 && canTurn == true)
        {
            direction = direction + new Vector3(0, -90, 0);
            canTurn = false;
        }

        if (Input.GetAxisRaw("Horizontal") == 1 && canTurn == true)
        {
            direction = direction + new Vector3(0, 90, 0);
            canTurn = false;
        }

        if (points == 4)
        {
            stage = stage + 1;
            stage = SceneManager.GetActiveScene().buildIndex + 1;
            NewStage();
            canTurn = false;
        }

    }

    void MoveForward()
    {
        previousPosition = transform.position;
        transform.Rotate(direction);
        transform.position = transform.position + transform.forward;
        direction = Vector3.zero;
        canTurn = true;
        Instantiate(tail, previousPosition, Quaternion.identity);
        Invoke("MoveForward", 1);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Omena")
        {
            Destroy(other.gameObject);
            PointScript.onkoOlemassa = false; 
            points++;
            UpdatePointsText();
            AS.clip = aanet[Random.Range(0, aanet.Length)];
            if (!AS.isPlaying)
            {
                AS.Play();
            }
        }

        if (other.gameObject.tag == "Seina")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PointScript.onkoOlemassa = false;
            points = 0;
            canTurn = false;
            lives--;
            PlayerPrefs.SetInt("Lives", lives);
            
            if (PlayerPrefs.GetInt("Lives") <= 0)
            {
                ResetStage();
            }
        }

        if (other.gameObject.tag == "Hanta")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PointScript.onkoOlemassa = false;
            points = 0;
            canTurn = false;
            PlayerPrefs.SetInt("Lives", (lives - 1));
            if (PlayerPrefs.GetInt("Lives") <= 0)
            {
                ResetStage();
            }
        }

        if (other.gameObject.tag == "Vihu")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PointScript.onkoOlemassa = false;
            points = 0;
            canTurn = false;
            PlayerPrefs.SetInt("Lives", (lives - 1));
            if (PlayerPrefs.GetInt("Lives") <= 0)
            {
                ResetStage();
            }
        }

    }

    void UpdatePointsText()
    {
        pointsText.text = "Pisteet: " + points.ToString();
    }
    
    void UpdateLives()
    {
        liveText.text = "Lives: " + PlayerPrefs.GetInt("Lives").ToString();
    }

    void NewStage()
    {
        if (stage == 4)
        {
            ResetStage();
        }

        else
        {
            SceneManager.LoadScene(stage);
            PointScript.onkoOlemassa = false;
            points = 0;
        }
        
    }

    void ResetStage()
    {
        SceneManager.LoadScene(0);
        points = 0;
    }

}
