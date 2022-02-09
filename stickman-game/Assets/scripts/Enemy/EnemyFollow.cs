using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stopDistance;
    [SerializeField] private AnimationControll animControll;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            // anda
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            animControll.PlayAnim(0);
        }
        else
        {
            // para
            animControll.PlayAnim(1);
        }

        //Debug.Log(target.transform.position.x - transform.position.x);
        float posX = target.transform.position.x - transform.position.x;

        if(posX > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
