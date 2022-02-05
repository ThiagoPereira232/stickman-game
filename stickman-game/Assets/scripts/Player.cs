using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rig;

    private Vector2 _direction;
    private bool _isFighting;
    private bool canFight = true;


    public Vector2 Direction { get => _direction; set => _direction = value; }
    public bool IsFighting { get => _isFighting; set => _isFighting = value; }

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnInput();
        OnFight();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + Direction * speed * Time.fixedDeltaTime);

    }

    void OnFight()
    {
        if (canFight)
        {
            if (Input.GetMouseButtonDown(0))
            {
                canFight = false;
                IsFighting = true;
                Invoke("FinishFight", 0.02f);
                Invoke("CanNewFight", 0.6f);
            }
        }
    }

    private void FinishFight()
    {
        IsFighting = false;
    }

    private void CanNewFight()
    {
        canFight = true;
    }

    #endregion
}
