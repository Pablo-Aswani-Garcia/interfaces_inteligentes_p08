using UnityEngine;

public class colision : MonoBehaviour
{
    public AudioSource sonidoColision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision detectada con: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("soldados")){
            sonidoColision.Play();
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
