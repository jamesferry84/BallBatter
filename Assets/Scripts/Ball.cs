using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float initialSpeed = 5f;
    [SerializeField] float maxSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = initialSpeed * Time.deltaTime;
        transform.position += new Vector3(0, moveSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (initialSpeed > 0 && initialSpeed < maxSpeed)
        {
            initialSpeed += 1f;
        }
        else if (initialSpeed < 0 && initialSpeed > (maxSpeed * -1))
        {
            initialSpeed -= 1f;
        }

        initialSpeed *= -1;

    }
}
