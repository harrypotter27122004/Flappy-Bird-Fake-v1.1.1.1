using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdController : MonoBehaviour
{
    public AudioClip flySound;
    public AudioClip gameOverSound;
    public AudioClip ping;
    private AudioSource audioSource;
    private Animator animat;
    public float flyPower = 50000;
    GameObject objj;
    public GameObject GameController;

    // Start is called before the first frame update
    void Start()
    {
        objj = gameObject;
        audioSource = objj.GetComponent<AudioSource>();
        animat = objj.GetComponent<Animator>();
        animat.SetFloat("flyPower",0);
        animat.SetBool("isDead",false);

    }

    // Update is called once per frame
    void Update()
    {
        if(!gameController.isGameOver)
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            objj.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, flyPower));
            audioSource.clip = flySound;
            audioSource.Play();
        };
        animat.SetFloat("flyPower",objj.GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        endGame();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        GameController.GetComponent<gameController>().GetPoint();
        audioSource.PlayOneShot(ping, 0.75F);
    }

    void endGame()
    {
        /*audioSource.PlayOneShot(gameOverSound, 1F);
        animat.SetBool("isDead",true);
        GameController.GetComponent<gameController>().EndGame();*/
        StartCoroutine(DelayCoroutine());
    }

    IEnumerator DelayCoroutine()
    {

        if (!gameController.isGameOver)
            audioSource.PlayOneShot(gameOverSound, 1F);
        animat.SetBool("isDead",true);
        bgMovement.speed =0;
        gameController.isGameOver = true;

        yield return new WaitForSeconds(1f);

        GameController.GetComponent<gameController>().EndGame();

    }
}
