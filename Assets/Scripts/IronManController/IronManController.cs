using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronManController : MonoBehaviour
{
    public static IronManController instance;
    public float bounceForce;
    private Rigidbody2D IronBody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    private bool isAlive;
    private bool didFlap;

    private GameObject spawner;

    public float flag = 0;
    public int score = 0;

    // Start is called before the first frame update
    void Awake()
    {
        isAlive = true;
        IronBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MakeInstance();
        spawner = GameObject.Find ("Spawner pillar");

    }

    void MakeInstance()
    {
        if (instance == null) { instance = this; }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IronMoveMent();

    }

    void IronMoveMent()
    {

        if (isAlive == true)
        {
            if (didFlap)
            {
                didFlap = false;
                IronBody.velocity = new Vector2(IronBody.velocity.x, bounceForce);
                audioSource.PlayOneShot(flyClip);
            }
            ;
            //if (Input.GetMouseButtonDown(0)) { IronBody.velocity = new Vector2(IronBody.velocity.x, bounceForce);
            // audioSource.PlayOneShot(flyClip); 
        }
        if (IronBody.velocity.y > 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, 90, IronBody.velocity.y / 10);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            anim.SetTrigger("Booster");

        }
        else if (IronBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetTrigger("Rest");
        }
        else if (IronBody.velocity.y < 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, -90, -IronBody.velocity.y / 10);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            anim.SetTrigger("Rest");
        }
    }
    public void FlapButton()
    {
        didFlap = true;
        
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "PillarScore")
        {
            score++;
            if(GameplayController.instance != null) { GameplayController.instance.SetScore(score); }
            audioSource.PlayOneShot(pingClip);
        }
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Pillar" || target.gameObject.tag == "Ground")
        {
            flag = 1;
            if (isAlive) {
                isAlive = false;


            Destroy(spawner);
                audioSource.PlayOneShot(diedClip); anim.SetTrigger("Died");
            }
            if (GameplayController.instance != null) { GameplayController.instance.DiedShowPanel(score); }
        }
    }
}

