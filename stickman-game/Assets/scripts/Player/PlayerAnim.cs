using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    private bool isHitting;
    private float recoveryTime = 1.5f;
    private float timeCount;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnFight();

        if (isHitting)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= recoveryTime)
            {
                isHitting = false;
                timeCount = 0;
            }

        }
    }

    #region Movement

    void OnMove()
    {
        if(player.Direction.sqrMagnitude > 0)
        {
            anim.SetInteger("transition", 1);
        }
        else
        {
            if (player.IsFighting)
            {
                anim.SetTrigger("isFight");
            }
            else
            {

            anim.SetInteger("transition", 0);
            }
        }

        if(player.Direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(player.Direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    #endregion

    #region Attack

    void OnFight()
    {
        if (player.IsFighting)
        {
            anim.SetInteger("transition", 2);
        }
    }

    public void OnHit()
    {
        if (!isHitting)
        {
            anim.SetTrigger("isHit");
            isHitting = true;
        }
    }

    #endregion
}
