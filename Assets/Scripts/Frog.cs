using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour

{
    Rigidbody rb;
    public float vitesse;

    private bool willjump;

    [SerializeField] int saut = 2;

    [SerializeField] DynamicJoystick joystick;

    private Vector3 slideDirection;

    [SerializeField] float slideSpeed = 2f;

    [SerializeField] float decceleration = 2;

    GameManager gameManager;

    public bool collided = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        MoveForward();
}

    void MoveForward()
    {
        Debug.Log("Move Forward " + collided);
        if (collided)
        {

            transform.DOMoveZ(transform.position.z + 5, 1f).SetEase(Ease.Linear);
            transform.DOMoveY(transform.position.y + 3, 0.5f).SetEase(Ease.OutQuad);
            transform.DOMoveY(transform.position.y, 0.5f)
                .SetDelay(0.5f)
                .SetEase(Ease.InQuad)
                .OnComplete(MoveForward);

            collided = false;

        }
        else
        {
            Fail();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(0, 0, vitesse) * Time.deltaTime);
        if (joystick.Direction.magnitude >0)
        {
            //willjump = true;

            slideDirection = new Vector3(joystick.Direction.x,0,0);
        }
        else
        {
           //slideSpeed = Mathf.Lerp(slideSpeed, 0, decceleration);
        }

    }

    private void FixedUpdate()
    {
        if (willjump == true)
        {
           //rb.velocity = new Vector3(0, saut, 0);
            willjump = false;
            Debug.Log(willjump);
        }
        else
        {
            rb.velocity = new Vector3(0,0,0) ;
        }

        rb.velocity = slideDirection * slideSpeed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide with Nenuphar" + collision.gameObject.name);
        if ( collision.gameObject.tag == "Nenuphar")
        {
            gameManager.AddScore(20);
            //  gameManager.score = gameManager.score + 20;
            collided = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonus"))
        {
            // Aouter des points
            Debug.Log("Point");
            gameManager.AddScore(15);
        }
    }

    void Fail()
    {
        Debug.Log("GameOver");
        DOTween.Kill(gameObject);
        rb.velocity = new Vector3(0, -10, 0);
        rb.useGravity = true;
        rb.isKinematic = false;
        GetComponent<Animator>().enabled = false;
        enabled = false;
        gameManager.GameOver();
    }

}
