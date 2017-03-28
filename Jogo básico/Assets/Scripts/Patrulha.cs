using UnityEngine;
using System.Collections;

public class Patrulha : MonoBehaviour {

    public float moveSpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
        if (transform.position.x >= 4.8 && transform.position.x <= 5)
            moveSpeed *= -1;
        if (transform.position.x >= -0.5 && transform.position.x <= -0.3)
            moveSpeed *= -1;

    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
        }
    }
}
