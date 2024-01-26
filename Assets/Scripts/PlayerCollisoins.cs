using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.UI;

public class PlayerCollisoins : MonoBehaviour
{
    // Start is called before the first frame update
    private int counter;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] GameObject particleEffect;
    [SerializeField] ParticleSystem Particle;
    
    void Awake()
    {
        particleEffect = Instantiate(particleEffect);
        Particle = particleEffect.GetComponent<ParticleSystem>();
        particleEffect.SetActive(false);
    }
    //IEnumerator Start()
    void Start()
    {
        //yield return null;
        StartCoroutine(GameManager.instance.CourutineTest());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "COIN")
        {
            Debug.Log(other.gameObject.name);
            Destroy(other.gameObject);
            counter++;
            Score.text = counter.ToString();
            //Instantiate(particleEffect,other.transform.position,Quaternion.identity);
            particleEffect.transform.position = other.transform.position;
            particleEffect.SetActive(true);
            Particle.Play();
            AudioManager.instance.PlaySFX(0);
            GameManager.instance.CoinsColleted++;
        }
    }

    
}
