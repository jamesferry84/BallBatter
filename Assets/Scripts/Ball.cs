using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    [SerializeField] float initialSpeed = .05f;
    [SerializeField] float maxSpeed = .5f;
    Rigidbody2D myRigidBody;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    int score = 0;
    int maxBouncesAtZeroXChange = 2;
    bool startGame = false;

    int lives = 3;
    Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        // Application.targetFrameRate = 120; // sets the framerate;
        myRigidBody = this.GetComponent<Rigidbody2D>();
        myRigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
        livesText.text = lives.ToString();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && startGame == false) {
            startGame = true;
            myRigidBody.constraints = RigidbodyConstraints2D.None;
            myRigidBody.AddForce(new Vector2(initialSpeed, initialSpeed));
            transform.SetParent(null);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void moveBall(Vector2 direction) {
        // myRigidBody.MovePosition((Vector2)transform.position + (direction * ballSpeed * Time.deltaTime));
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("brick")) {
            score++;
            Debug.Log(score);
            scoreText.text = score.ToString();
        }
    }

    private void EndGame() {
        //Scenemanager stuff
        ResetPositions();
    }

    private void ResetPositions() {
        startGame = false;
        myRigidBody.velocity = new Vector2(0,0);
        transform.SetParent(parent);
        transform.position = new Vector3(parent.position.x,parent.position.y + 0.25f, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("entered trigger");
        if (lives > 0) {
            lives--;
            livesText.text = lives.ToString();
            ResetPositions();
        } else {
            EndGame();
        }
        
    }
}
