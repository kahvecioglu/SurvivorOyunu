using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunKontrol : MonoBehaviour
{
    public GameObject zombi;
    private float zamansayacý;
    private float zamansuresi = 10f;
    public Text PuanText;
    private int puan;
    // Start is called before the first frame update
    void Start()
    {
        zamansayacý = zamansuresi;
    }

    // Update is called once per frame
    void Update()
    {zamansayacý-=Time.deltaTime;
        if (zamansayacý < 0)
        {
            Vector3 pos = new Vector3(Random.Range(157,405), 28.3f, Random.Range(381,124));
            Instantiate(zombi, pos, Quaternion.identity);
            zamansayacý = zamansuresi;
        }
        
    }

    public void PuanArttir(int p)
    {

        puan += p;
        PuanText.text = " " + puan;
    }

    public void OyunBitti()
    {
        PlayerPrefs.SetInt("puan",puan);
        SceneManager.LoadScene("OyunBitti");

    }
}
