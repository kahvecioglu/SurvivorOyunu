using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyuncuKontrol : MonoBehaviour
{
    public Transform mermiPos;
    public GameObject mermi;
    public GameObject patlama;
    public Image canImaj�;
    private float can = 100f;
    private bool zombiyeDegdi = false; // Saya� de�i�keni
    private float zamanSayaci = 0f; // Zaman sayac�
    private float zamanSuresi = 1f; // Zaman sayac� s�resi (1 saniye)
    private OyunKontrol oyunkntrol;
    public AudioClip atissesi, olmesesi, canalmasesi, yaralanmasesi;
    private AudioSource aSource;
    public ZombieHareket zombieHareket;
  
    
   
   
 

    // Start is called before the first frame update
    void Start()
    {
        
        aSource = GetComponent<AudioSource>();
        oyunkntrol = GameObject.Find("_Scripts").GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        
    
        if (zombiyeDegdi)
        {
            zamanSayaci += Time.deltaTime; // Zaman sayac�n� art�r
            if (zamanSayaci >= zamanSuresi)
            {
                // Zaman s�resi ge�ti�inde saya�� s�f�rla ve izin ver
                zombiyeDegdi = false;
                zamanSayaci = 0f;
            }
        }




        if (Input.GetKeyDown(KeyCode.F))
        {
            aSource.PlayOneShot(atissesi, 1f);
            GameObject go= Instantiate(mermi,mermiPos.position,mermiPos.rotation)as GameObject;
            GameObject goPat = Instantiate(patlama, mermiPos.position, mermiPos.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = mermiPos.transform.forward * 10f;
            Destroy(go.gameObject,2f);
            Destroy(goPat.gameObject, 2f);

           
            

        }
    }


    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag.Equals("zombi"))
        {

           

            if (!zombiyeDegdi  )
            {
                aSource.PlayOneShot(yaralanmasesi, 1f);
                can -= 10f;
                canImaj�.fillAmount = can / 100f;
                canImaj�.color = Color.Lerp(Color.red, Color.green, can / 100f);
                zombiyeDegdi = true;
            }

        }
        if (can <= 0)
        {
            aSource.PlayOneShot(olmesesi, 1f);
            oyunkntrol.OyunBitti();
            
        }
        
    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag.Equals("kalp"))
        {
            aSource.PlayOneShot(canalmasesi, 1f);

            if (can < 100)
            {
                can += 10f;
                Destroy(c.gameObject);
                canImaj�.fillAmount = can / 100f;
                canImaj�.color = Color.Lerp(Color.red, Color.green, can / 100f);
            }
            
            

        }
    }



}
