﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWeapon : MonoBehaviour
{

    Color[] ColorsList;
    private void Start()
    {
        ColorsList = new Color[7];
        ColorsList[0] = Color.red;
        ColorsList[1] = Color.yellow;
        ColorsList[2] = Color.magenta;
        ColorsList[3] = Color.blue;
        ColorsList[4] = Color.green;
        ColorsList[5] = Color.cyan;
        ColorsList[6] = Color.white;
        StartCoroutine(ChangeColorAfterTime(0.5f));
    }

    public int newWeapon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (newWeapon == 0)
            {
                collision.GetComponent<PlayerShooting>().stateMachine.ChangeState(ShotGunFire.Instance);
            }
            else if(newWeapon == 1)
            {
                collision.GetComponent<PlayerShooting>().stateMachine.ChangeState(FullAutoFire.Instance);
            }
            Destroy(gameObject);
        }
    }
    IEnumerator ChangeColorAfterTime(float delayTime)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Color currentcolor = (Color)ColorsList[UnityEngine.Random.Range(0, ColorsList.Length)]; ;
        Color nextcolor;

        spriteRenderer.color = currentcolor;

        while (true)
        {
            nextcolor = (Color)ColorsList[UnityEngine.Random.Range(0, ColorsList.Length)];

            for (float t = 0; t < delayTime; t += Time.deltaTime)
            {
                spriteRenderer.color = Color.Lerp(currentcolor, nextcolor, t / delayTime);
                yield return null;
            }
            currentcolor = nextcolor;
        }
    }
}