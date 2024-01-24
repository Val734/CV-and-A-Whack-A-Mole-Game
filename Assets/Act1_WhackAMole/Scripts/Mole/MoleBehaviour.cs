using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class MoleBehaviour : MonoBehaviour
{
    [SerializeField] float TimeUp;
    private bool addScore=false; 
    private Animator _anim;
    //[SerializeField] GameObject soundManager;
    private AudioSource hurtSound;
    private AudioSource laughSound;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        GameObject soundManager = GameObject.FindGameObjectWithTag("SoundManager");

        hurtSound = soundManager.transform.Find("HurtMoleSound").GetComponent<AudioSource>();
        laughSound = soundManager.transform.Find("LaughMoleSound").GetComponent<AudioSource>();
    }
    void Update()
    {
        TimeUp -= Time.deltaTime;
        if (TimeUp < 0f)
        {
           laughSound.Play();
            StartCoroutine(HideMoleAnim());

        }
    }

    IEnumerator HideMoleAnim()
    {
        _anim.SetTrigger("hide_mole");
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }


    public void MoleKilled()
    {
        if (addScore == false)
        {
            gameObject.GetComponentInParent<MoleSpawnerController>().OnMoleKilled();
           hurtSound.Play();
            addScore = true;

        }
        _anim.SetTrigger("hit_mole");

        StartCoroutine(DestroyMolePrefab());
    }
    IEnumerator DestroyMolePrefab()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
        addScore= false;
    }
}
