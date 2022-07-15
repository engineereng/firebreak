using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public float life = 0.0f;
    public bool isAlive = false;
    private readonly float lifeDecay = 0.05f;
    private readonly float LIFECAP = 100.0f;
    public void Heal (int healing)
    {
        life += healing;
        if (life > LIFECAP)
        {
            life = LIFECAP;
        }        
    }

    protected void ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = new Color (0.0f, life / LIFECAP, 0, 1.0f);
    }

    private void DecayLife()
    {
        life -= lifeDecay;
        if (life < 0)
        {
            life = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        DecayLife();
        isAlive = life > 50;
        ChangeColor();
    }
}