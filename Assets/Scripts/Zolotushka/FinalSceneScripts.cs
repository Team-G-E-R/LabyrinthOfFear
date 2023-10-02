using System;
using System.Collections;
using System.Collections.Generic;
using Common.Scripts;
using UnityEngine;
using UnityEngine.Playables;

public class FinalSceneScripts : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private GameObject player;

    public void OnCollisionEnter(Collision other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<movement>().enabled = false;
        _director.Play();
    }
}
