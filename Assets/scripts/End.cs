using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audio;
    public GameObject ScoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        if (animator == null) {
            animator = GetComponent<Animator>();
        }
        if (audio == null) {
            audio = GetComponent<AudioSource>();
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Car") {
            animator.SetInteger("fireworks", 1);
            audio.Play();
            Invoke("ShowScoreBoard", 3.0f);
        }
    }

    void ShowScoreBoard() {
        ScoreBoard.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
