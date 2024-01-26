using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ZombieHareket : MonoBehaviour
{
    private GameObject oyuncu;
    public GameObject kalp;
    private int zombiCan = 3;
    private bool kalpOlusturuldu = false;
    private bool puanarttý = false;
    private float mesafe;
    private int zombidengelencan = 10;
    private OyunKontrol oyunkntrl;
    private AudioSource aSource;
    public bool zombiOluyor=false;

   
    
 

    // Start is called before the first frame update
    void Start()
    {
        aSource=GetComponent<AudioSource>();
        oyuncu = GameObject.Find("Oyuncu");
        oyunkntrl=GameObject.Find("_Scripts").GetComponent<OyunKontrol>();

        
    }

    // Update is called once per frame
    void Update()
    {
      
        GetComponent<NavMeshAgent>().destination=oyuncu.transform.position;
        mesafe=Vector3.Distance(transform.position,oyuncu.transform.position);

        if (mesafe < 5f)
        {
            
            if(!aSource.isPlaying) 
            
            aSource.Play();
              
            
            


            if (!zombiOluyor)
                {
                    GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
                }



        }
        else
        {
           if(aSource.isPlaying)
                aSource.Stop();

        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag.Equals("mermi"))
        {
            zombiCan--;
            
          
        }
        if(zombiCan == 0) {

            zombiOluyor = true;

            if (!kalpOlusturuldu && !puanarttý)
            {
                oyunkntrl.PuanArttir(zombidengelencan);
                puanarttý = true;
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.667f);
                Instantiate(kalp, transform.position, Quaternion.identity);
                kalpOlusturuldu = true;
                
            }


        }
    }

  

}
