using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;

    public float runSpeed = 300f;//�������� ���� ������ ������
    public float strafeSpeed = 20f;//�������� ���� ������ � �������
    public float jumpForce = 5f;//���� �������
    private int coins;
    [SerializeField] private Text coinsText;


    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool doJump = false;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey("left"))
        {
            strafeLeft = true;
        } else
        {
            strafeLeft = false;
        }


        if (Input.GetKey("right"))
        {
            strafeRight = true;
        } else
        {
            strafeRight = false;
        }


        if (Input.GetKeyDown("space"))
        {
            doJump = true;
        }
        

        if(transform.position.y < - 5f)
        {
            Debug.Log("ʳ���� ���!");
        }
    }

    
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + Vector3.forward * runSpeed * Time.deltaTime);

        if (strafeLeft)
        {
            rb.AddForce(-strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (strafeRight)
        {
            rb.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(doJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            doJump = false;
        }
    }
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coins++;
            coinsText.text = coins.ToString();// ���������� �������� � �����
            Destroy(other.gameObject);
        }
    }

}
