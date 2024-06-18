using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera camView;
    [SerializeField] float speedX;
    [SerializeField] float speedXLerp = 10;
    [SerializeField] float speedXSens = 4;
    [SerializeField] float jumpForce = 12;
    [SerializeField] float camFollowSpeed = 3;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public bool TestGround()//Y速度为0的时候落地（？
    {
        float speedY = rb.velocityY;
        return (Mathf.Abs(speedY) < 0.01f);
    }
    void GetInput()
    {
        if (TestGround() && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        speedX += (Input.GetAxis("Horizontal") - speedX) * speedXLerp * Time.deltaTime;
        transform.position += new Vector3(speedX*speedXSens*Time.deltaTime,0);
    }
    void CameraControll()
    {
        camView.transform.position += (transform.position - camView.transform.position) * camFollowSpeed * Time.deltaTime;
        camView.transform.position = new Vector3(camView.transform.position.x, camView.transform.position.y, -10);
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        CameraControll();
    }
}
