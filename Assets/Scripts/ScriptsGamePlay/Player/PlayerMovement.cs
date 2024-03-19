using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerAbstract
{
    [Header("Player Movement")]

    [SerializeField] protected float moveSpeed = 3f;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    [SerializeField] protected float onHorizontal;

    [SerializeField] protected float onVertical;

    [SerializeField] protected float maxY = 15f;

    [SerializeField] protected float minY = -15f;

    [SerializeField] protected float maxX = 20f;

    [SerializeField] protected float minX = -20f;

    protected virtual void Update()
    {
        this.Movement();
    }

    protected virtual void Movement()
    {

        this.onHorizontal = InputManager.Instance.OnHorizontal;
        this.onVertical = InputManager.Instance.OnVertical;

        float posX = this.moveSpeed * this.onHorizontal * Time.deltaTime;

        float posY = this.moveSpeed * this.onVertical * Time.deltaTime;

        transform.parent.position += new Vector3(posX, posY, 0);

        float clampedX = Mathf.Clamp(transform.parent.position.x, this.minX, this.maxX);
        float clampedY = Mathf.Clamp(transform.parent.position.y, this.minY, this.maxY);

        transform.parent.position = new Vector3(clampedX, clampedY, 1);

        if(this.onHorizontal != 0 || this.onVertical != 0)
            this.playerCtrl.Model.GetComponent<Animator>().SetInteger("State", 1);
        else
            this.playerCtrl.Model.GetComponent<Animator>().SetInteger("State", 0);


        if(this.onHorizontal != 0)
        {
            if (this.onHorizontal > 0) this.playerCtrl.Model.localScale = new Vector3(1, 1, 1);
            else this.playerCtrl.Model.localScale = new Vector3(-1, 1, 1);
        }
    }
}
