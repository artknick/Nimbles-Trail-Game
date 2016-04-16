using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    float speed = 0.0f;
    float turnAmount = 0.0f;
    float speedModifier = 2.0f;
    float rotSpeed = 300.0f;

    //bool attacking = false;

    Animator anim;

    public BoxCollider weapon;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        Move();

        Animate();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Attack();
        }
	}

    void Attack()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(WeaponEnable());
        
    }

    IEnumerator WeaponEnable()
    {
        yield return new WaitForSeconds(.2f);
        weapon.enabled = true;
        yield return new WaitForSeconds(.2f);
        weapon.enabled = false;
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotSpeed * Time.deltaTime, 0);
            turnAmount += Time.deltaTime;
            if (turnAmount > 1)
                turnAmount = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
            turnAmount -= Time.deltaTime;
            if (turnAmount < -1)
                turnAmount = -1;
        }
        else
        {
            turnAmount = 0;
        }

        transform.Translate((Input.GetAxis("Horizontal") * speed) / 10, 0, (Input.GetAxis("Vertical") * speed) / 10);

        if(Input.GetAxis("Vertical") != 0.0f)
        {
            speed += Time.deltaTime * speedModifier;
            if(speed > 1)
                speed = 1;
        }
        else
        {
            speed -= Time.deltaTime * speedModifier;
            if (speed < 0)
                speed = 0;
        }
    }

    void Animate()
    {
        anim.SetFloat("Speed", speed);
        anim.SetFloat("Turn", turnAmount);
    }
}
