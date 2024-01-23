using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    public float score;
    public Text txtScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -3.95f, 4.04f);
        transform.position = pos;

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

        if (score >= 100)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScoreWall")
        {
            score++;
            txtScore.text = "Score: " + score;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            score = score + 5;
            txtScore.text = "Score: " + score;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
