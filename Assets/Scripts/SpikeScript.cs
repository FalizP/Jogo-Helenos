using Unity.VisualScripting;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public SpikeGenerator spikeGenerator;

    void Update()
    {

        transform.Translate(Vector2.left * spikeGenerator.currentSpeed *  Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {

            spikeGenerator.GenerateNextSpikeWihtGap();

        }

        if (collision.gameObject.CompareTag("Finish"))
        {

            Destroy(this.gameObject);

        }
    }

}
