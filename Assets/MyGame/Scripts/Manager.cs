using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    
    [SerializeField] GameObject postScreen;
    [SerializeField] GameObject radicalizeScreen;

    [SerializeField] TMP_Text radicalizeText;

    public string radicalized;

    [Header("Radicalize Images")]
    [SerializeField] SpriteRenderer post1_imag;
    [SerializeField] SpriteRenderer post2_imag;
    [SerializeField] SpriteRenderer post3_imag;
    [SerializeField] SpriteRenderer post4_imag;

    [Header("Radicalize Texts")]
    [SerializeField] TMP_Text post1_Text;
    [SerializeField] TMP_Text post2_Text;
    [SerializeField] TMP_Text post3_Text;
    [SerializeField] TMP_Text post4_Text;

    [Header("Level 2 Post Help Values")]
    public int postRoutineE = 1;
    public int postRoutineS = 1;

    public bool epath;
    public bool spath;

    [Header("Level 2 Post Images")]
    public Sprite post1E_Imag;
    public Sprite post1S_Imag;
    public Sprite post2E_Imag;
    public Sprite post2S_Imag;
    public Sprite post3E_Imag;
    public Sprite post3S_Imag;
    public Sprite post4E_Imag;
    public Sprite post4S_Imag;
    public Sprite post5E_Imag;
    public Sprite post5S_Imag;
    public Sprite post6E_Imag;
    public Sprite post6S_Imag;
    public Sprite post7E_Imag;
    public Sprite post7S_Imag;
    public Sprite post8E_Imag;
    public Sprite post8S_Imag;
    public Sprite post9E_Imag;
    public Sprite post9S_Imag;
    public Sprite post10E_Imag;
    public Sprite post10S_Imag;

    [Header("Level 2 Post Texts")]
    public string post1E_Txt;
    public string post1S_Txt;
    public string post2E_Txt;
    public string post2S_Txt;
    public string post3E_Txt;
    public string post3S_Txt;
    public string post4E_Txt;
    public string post4S_Txt;
    public string post5E_Txt;
    public string post5S_Txt;
    public string post6E_Txt;
    public string post6S_Txt;
    public string post7E_Txt;
    public string post7S_Txt;
    public string post8E_Txt;
    public string post8S_Txt;
    public string post9E_Txt;
    public string post9S_Txt;
    public string post10E_Txt;
    public string post10S_Txt;

    [Header("Level 2 Post Bools")]
    public bool post1E_bool;
    public bool post2E_bool;
    public bool post3E_bool;
    public bool post4E_bool;
    public bool post5E_bool;
    public bool post6E_bool;
    public bool post7E_bool;
    public bool post8E_bool;
    public bool post9E_bool;
    public bool post10E_bool;
    public bool post1S_bool;
    public bool post2S_bool;
    public bool post3S_bool;
    public bool post4S_bool;
    public bool post5S_bool;
    public bool post6S_bool;
    public bool post7S_bool;
    public bool post8S_bool;
    public bool post9S_bool;
    public bool post10S_bool;

    public void LoadAfterLvl2()
    {
        postScreen.SetActive(false);
        radicalizeScreen.SetActive(true);

        radicalizeText.text = radicalized;
        radicalizeText.gameObject.SetActive(true);

        if (post1E_bool)
        {
            post1_imag.sprite = post1E_Imag;
            post1_Text.text = post1E_Txt;

        }
        if (post1S_bool)
        {
            post1_imag.sprite = post1S_Imag;
            post1_Text.text = post1S_Txt;

        }



        if (post2E_bool)
        {
            post2_imag.sprite = post2E_Imag;
            post2_Text.text = post2E_Txt;

        }
        if (post3E_bool)
        {
            post2_imag.sprite = post3E_Imag;
            post2_Text.text= post3E_Txt;

        }
        if (post2S_bool)
        {
            post2_imag.sprite = post2S_Imag;
            post2_Text.text = post2S_Txt;

        }
        if (post3S_bool)
        {
            post2_imag.sprite = post3S_Imag;
            post2_Text.text = post3S_Txt;

        }



        if (post4E_bool)
        {
            post3_imag.sprite = post4E_Imag;
            post3_Text.text = post4E_Txt;

        }
        if (post5E_bool)
        {
            post3_imag.sprite = post5E_Imag;
            post3_Text.text = post5E_Txt;

        }
        if (post6E_bool)
        {
            post3_imag.sprite = post6E_Imag;
            post3_Text.text = post6E_Txt;

        }
        if (post4S_bool)
        {
            post3_imag.sprite = post4S_Imag;
            post3_Text.text = post4S_Txt;

        }
        if (post5S_bool)
        {
            post3_imag.sprite = post5S_Imag;
            post3_Text.text = post5S_Txt;

        }
        if (post6S_bool)
        {
            post3_imag.sprite = post6S_Imag;
            post3_Text.text = post6S_Txt;

        }



        if (post7E_bool)
        {
            post4_imag.sprite = post7E_Imag;
            post4_Text.text = post7E_Txt;

        }
        if (post8E_bool)
        {
            post4_imag.sprite = post8E_Imag;
            post4_Text.text = post8E_Txt;

        }
        if (post9E_bool)
        {
            post4_imag.sprite = post9E_Imag;
            post4_Text.text = post9E_Txt;

        }
        if (post10E_bool)
        {
            post4_imag.sprite = post10E_Imag;
            post4_Text.text = post10E_Txt;

        }
        if (post7S_bool)
        {
            post4_imag.sprite = post7S_Imag;
            post4_Text.text = post7S_Txt;

        }
        if (post8S_bool)
        {
            post4_imag.sprite = post8S_Imag;
            post4_Text.text = post8S_Txt;

        }
        if (post9S_bool)
        {
            post4_imag.sprite = post9S_Imag;
            post4_Text.text = post9S_Txt;

        }
        if (post10S_bool)
        {
            post4_imag.sprite = post10S_Imag;
            post4_Text.text = post10S_Txt;

        }
    }
}
