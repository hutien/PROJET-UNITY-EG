


using UnityEngine;
using System.Collections;

public class PickableObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    public float rota = 10;

    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool touched = false;

    void Update()
    {
        // check distance entre objet et joueur
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        // si - ou = 1.9 unités de distance = on peut ramasser
        if (dist <= 5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        // si on peut ramasser et qu'on appuie sur E = on porte l'objet
        if (hasPlayer && Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        }

        // Si on porte l'objet
        if (beingCarried)
        {
            // si l'objet touche un mur / objet avec collider
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }

            // R= on fait tourner suivant y
            if (Input.GetKey(KeyCode.R))
            {

                GetComponent<Rigidbody>().transform.Rotate(0, 0.5f, 0);
               
            }

            // R= on fait tourner suivant x
            if (Input.GetKey(KeyCode.T))
            {

                GetComponent<Rigidbody>().transform.Rotate(0.5f, 0, 0);

            }
            // R= on fait tourner suivant z
            if (Input.GetKey(KeyCode.Y))
            {

                GetComponent<Rigidbody>().transform.Rotate(0, 0, 0.5f);

            }


            // Clique gauche = on jette l'objet
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            }



            // clique droit on pose l'objet
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }

    // Détection de contact grace au collider is trigger
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
