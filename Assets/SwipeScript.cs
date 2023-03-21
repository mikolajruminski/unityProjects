using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour
{
    // Start is called before the first frame update

   
    private bool isSwiping = false;
    private Camera cam;
    private Vector3 mousePos;
    private BoxCollider col;
    private TrailRenderer trail;

    private GameManager gameManager;
    void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        trail.enabled = false;
        col.enabled = false;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
       if (gameManager.isGameActive) {
        if (Input.GetMouseButtonDown(0)) {
            isSwiping = true;
            trail.enabled = true;
            col.enabled = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            isSwiping = false;
            trail.enabled = false;
            col.enabled = false;
        }
       }

       if (isSwiping) {
        UpdateMousePosition();
       }
    }

     void UpdateMousePosition() {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
     }

    
     private void OnCollisionEnter(Collision other)
     {
        if (other.gameObject.GetComponent<Target>()) {
            other.gameObject.GetComponent<Target>().DestroyTarget();
        }
     }
}


