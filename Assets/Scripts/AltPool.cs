using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltPool : MonoBehaviour
{
    public Queue<GameObject> QueuedObject;

    public GameObject Origin;
    public GameObject Object;
    public float SpawnRate;
    public int MaxObject;

    private void Start()
    {
        QueuedObject = new Queue<GameObject>();

        for(int i = 0; i < MaxObject; i++) //Pake for untuk menentukan batasan yg harus dibuat
        {
            GameObject CreateObject = Instantiate(Object, Origin.transform.position, Quaternion.identity);
            QueuedObject.Enqueue(CreateObject); //memasukkan object yang telah dibuat ke antrian
        } // kelemahannya dia bakalan start sesuai amount max object tapi kalau di Spawn trigger harusnya bisa satu satu

    }

    public void SpawnObject()
    {
        GameObject CurrentObject = QueuedObject.Dequeue(); //Ketika spawn akan menjadi giliran
        CurrentObject.transform.position = Origin.transform.position; //Mengatur lokasi spawn

        QueuedObject.Enqueue(CurrentObject); //balik ke antrian

        if(QueuedObject != null)
        {
            QueuedObject = new Queue<GameObject>();
        }

    }

    /*Pelajaran: Queue itu antrian, modelnya akan seperti ini
     Enqueue -> 1 -> Dequeue
    */

    // Jangan pakai Destroy, jika pakai destroy itemnya gk akan spawn
}
