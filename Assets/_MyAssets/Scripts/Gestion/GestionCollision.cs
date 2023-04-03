using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    //Attributs 
    private GestionJeu _gestionJeu;
    private bool _toucher = false;
    private float _tempstotal;
    private float _tempsNiv1;
    private float _tempsNiv2;
    private float _tempsNiv3;
    private float _point1;
    private float _point2;
    private float _point3;
    private float _pointTot;


    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();//get objet gestion de jeu
    }

    //Gestion collision et chagmeent de couleurs
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!_toucher)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;//Changement de couleur
                _gestionJeu.AugmenterPointage();
                _toucher = true;
                Invoke("DelaiFin", 4);
            }

        }

    }

    private void DelaiFin()
    {
        _toucher= false;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }


}
