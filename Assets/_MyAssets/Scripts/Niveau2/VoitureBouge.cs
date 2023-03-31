using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoitureBouge : MonoBehaviour
{
    //Attributs
    [SerializeField] private float positionEnXD = 1.016f;
    [SerializeField] private float positionEnXF = 1.98f;
    [SerializeField] private float positionZ = 3.21499f;
    [SerializeField] private float positionY = 0.36999f;
    [SerializeField] private float vitesse = 1;
    private float positionEntrePoint = 0;

    private float _direction = 1;

    //méthodes privées
    private void FixedUpdate()
    {
        Vector3 positionDebut = new Vector3(positionEnXD, positionY,positionZ );
        Vector3 positonFin = new Vector3(positionEnXF, positionY, positionZ);

        transform.position = Vector3.Lerp(positionDebut, positonFin, positionEntrePoint);
        positionEntrePoint += Time.deltaTime * vitesse * _direction;
        if (positionEntrePoint >= 1 || positionEntrePoint <= 0)
            _direction *= -1;
        return;
    }
}
