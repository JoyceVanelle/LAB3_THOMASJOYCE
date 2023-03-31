using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege3 : MonoBehaviour
{
    [SerializeField] private float _force = 200;  // Force sur les ballons
    [SerializeField] private List<GameObject> _listeBallons = new List<GameObject>();  // Liste des ballons
    private bool _activer= false;  // regarder si le piege a ete activer
    private List<Rigidbody> _listeRb = new List<Rigidbody>(); // Liste de rigidbody des ballons
    
    void Start()
    {
        foreach (var balle in _listeBallons)
        {
            _listeRb.Add(balle.GetComponent<Rigidbody>()); //store les rigibodys des ballons 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_activer)
        {

            foreach (var rb in _listeRb)
            {
                rb.useGravity = true;  //active la gravité sur les ballons
                Vector3 direction = new Vector3(0f, -1f, 0f); // Pointe le bas
                rb.AddForce(direction * _force); // Pousse les ballons!
            }
            _activer = true;  // Active la zone pour pas que sa plante et le repete a chaque frame
        }
    }
}
