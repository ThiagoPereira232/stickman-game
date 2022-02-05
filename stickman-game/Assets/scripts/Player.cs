using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rig;

    private Vector2 _direction;

    public Vector2 Direction { get => _direction; set => _direction = value; }

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnInput();
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

    #endregion
}
