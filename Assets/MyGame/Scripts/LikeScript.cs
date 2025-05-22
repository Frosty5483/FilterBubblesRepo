using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LikeScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer post1_imag;
    [SerializeField] SpriteRenderer post2_imag;
    [SerializeField] TMP_Text post1_txt;
    [SerializeField] TMP_Text post2_txt;
    
    private Manager manag;

    private void Start()
    {
        manag = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }
    void GoToNewPost(Sprite image1, string text1, Sprite image2, string text2)
    {
        post1_imag.sprite = image1;
        post2_imag.sprite = image2;
        post1_txt.text = text1;
        post2_txt.text = text2;
    }
}
