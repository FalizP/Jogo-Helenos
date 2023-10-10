using Unity.VisualScripting;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float speedMultiplier;

    void Awake()
    {

        currentSpeed = MinSpeed;
        generateSpike();

    }

    public void GenerateNextSpikeWihtGap()
    {

        float randoWait = Random.Range(0.1f, 1.2f);
        Invoke("generateSpike", randoWait);

    }

    void generateSpike()
    {

        GameObject Spike =  Instantiate(spike, transform.position, transform.rotation);

        Spike.GetComponent<SpikeScript>().spikeGenerator = this;

    }


    void Update()
    {
        
        if(currentSpeed < MaxSpeed) {

            currentSpeed += speedMultiplier;

        }

    }
}
