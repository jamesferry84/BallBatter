using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] int hitPoints = 1;
    [SerializeField] bool breakable = true;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!breakable) {
            return;
        }
        hitPoints--;
        if (hitPoints <= 0) {
            Destroy(gameObject);
        }
        
    }
}
