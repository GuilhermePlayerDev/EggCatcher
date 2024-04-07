using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private FixedJoystick js;
    private float movespeed = 0.1f;
    float hinput;
    public int thescore = 0;

    public TextMeshProUGUI wintxt1;
    [SerializeField] private GameObject wingame;
    [SerializeField] private GameObject gameover;

    private void FixedUpdate()
    {
        hinput = js.Horizontal * movespeed;
        //vinput = js.Vertical * movespeed;

        transform.Translate(hinput, 0, 0);
    }

    void Update()
    {

        if (thescore == 20)
        {
            wingame.SetActive(true);
        }
        //if time over 1 minute , game over
        //gameover setactive true
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "egg")
        {
            thescore++;
            Destroy(col.gameObject);
            wintxt1.text = "Pontos " + thescore;
        }
    }
}
