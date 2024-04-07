using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bird : MonoBehaviour
{
    public GameObject pA;
    public GameObject pB;
    private Rigidbody2D rb;
    private float speed = 8f;
    private Transform curpoint;

    //spawn eggs

    private float waitingtime;
    private float timer;
    public GameObject eggobj;
    public GameObject eggobjfailed;
    public Transform localeggspawn;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curpoint = pB.transform;

        //eggs

        waitingtime = 1.5f;
        timer = 0;
    }
    void Update()
    {
        Vector2 point = curpoint.position - transform.position;
        if (curpoint == pB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
            gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
            gameObject.transform.localScale = new Vector3(-0.75f, 0.75f, 0.75f);
        }
        if (Vector2.Distance(transform.position, curpoint.position) < 0.5f && curpoint == pB.transform)
        {
            curpoint = pA.transform;
        }
        if (Vector2.Distance(transform.position, curpoint.position) < 0.5f && curpoint == pA.transform)
        {
            curpoint = pB.transform;
        }

        //eggs

        timer += Time.deltaTime;
        if (timer > waitingtime)
        {
            Instantiate(eggobj, localeggspawn.transform.position, Quaternion.identity);
            timer = -2;

        }
    }

}
