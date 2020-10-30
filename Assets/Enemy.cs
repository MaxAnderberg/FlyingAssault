using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int scorePerHit = 12;
    ScoreBoard scoreBoard;
    [SerializeField] Transform parent;
    [SerializeField] GameObject deathVFX;
    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);
        GameObject fx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
