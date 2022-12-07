using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float accelerationAmount = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.Translate(moveAmount, 0f , 0f);
    }
}
