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

    private bool tempBool;
    private bool tempBoolS;
    private Manager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        if (manager.postRoutineE == 1 && manager.postRoutineS == 1)
        {
            StartCoroutine(GoToNewPostE(manager.post1E_Imag, manager.post1E_Txt, manager.post1S_Imag, manager.post1S_Txt));
            manager.postRoutineS += 1;
        }
    }



    public IEnumerator GoToNewPostE(Sprite image1, string text1, Sprite image2, string text2)
    {
        post1_imag.sprite = image1;
        post2_imag.sprite = image2;
        post1_txt.text = text1;
        post2_txt.text = text2;

        yield return new WaitForSeconds(0.2f);
        if (tempBool == false)
        {
            manager.postRoutineE += 1;
        }
        if (tempBool == true)
        {
            manager.postRoutineE = 6;
            tempBool = false;
        }

    }

    public IEnumerator GoToNewPostS(Sprite image1, string text1, Sprite image2, string text2)
    {
        post1_imag.sprite = image1;
        post2_imag.sprite = image2;
        post1_txt.text = text1;
        post2_txt.text = text2;

        yield return new WaitForSeconds(0.2f);
        if (tempBoolS == false)
        {
            manager.postRoutineS += 1;
        }
        if (tempBoolS == true)
        {
            manager.postRoutineS = 6;
            tempBoolS = false;
        }
    }
    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //E-path Left
            if (manager.postRoutineE == 2 && gameObject.tag == "Like1" && manager.epath == false && manager.spath == false)
            {
                //E 1 --> E 2/3
                manager.epath = true;
                manager.post1E_bool = true;
                StartCoroutine(GoToNewPostE(manager.post2E_Imag, manager.post2E_Txt, manager.post3E_Imag, manager.post3E_Txt));
            }

            if (manager.postRoutineE == 3 && gameObject.tag == "Like1" && manager.epath == true && manager.spath == false)
            {
                //E 2 --> E 4/5
                manager.post2E_bool = true;
                StartCoroutine(GoToNewPostE(manager.post4E_Imag, manager.post4E_Txt, manager.post5E_Imag, manager.post5E_Txt));
            }
            if (manager.postRoutineE == 4 && gameObject.tag == "Like1" && manager.epath == true && manager.spath == false)
            {
                //E 4 --> E 7/8
                manager.post4E_bool = true;
                StartCoroutine(GoToNewPostE(manager.post7E_Imag, manager.post7E_Txt, manager.post8E_Imag, manager.post8E_Txt));
            }

            if (manager.postRoutineE == 6 && gameObject.tag == "Like1" && manager.epath == true && manager.spath == false)
            {
                //E 5 --> E 8/9
                manager.post5E_bool = true;
                StartCoroutine(GoToNewPostE(manager.post8E_Imag, manager.post8E_Txt, manager.post9E_Imag, manager.post9E_Txt));
            }


            if (manager.postRoutineE == 7 && gameObject.tag == "Like1" && manager.epath == true && manager.spath == false)
            {
                //E 9 --> LoadAfter
                manager.post9E_bool = true;
                manager.LoadAfterLvl2();
            }

            if (manager.postRoutineE == 5 && gameObject.tag == "Like1" && manager.epath == true && manager.spath == false)
            {
                //E 7 --> LoadAfter
                manager.post7E_bool = true;
                manager.LoadAfterLvl2();
            }


            //E-path Right
            if (manager.postRoutineE == 3 && gameObject.tag == "Like2" && manager.epath == true && manager.spath == false)
            {
                //E 3 --> E 5/6
                tempBool = true;
                manager.post3E_bool = true;
                StartCoroutine(GoToNewPostE(manager.post5E_Imag, manager.post5E_Txt, manager.post6E_Imag, manager.post6E_Txt));
            }

            if (manager.postRoutineE == 4 && gameObject.tag == "Like2" && manager.epath == true && manager.spath == false)
            {
                //E 5 --> E 8/9
                manager.post5E_bool = true;
                StartCoroutine(GoToNewPostE(manager.post8E_Imag, manager.post8E_Txt, manager.post9E_Imag, manager.post9E_Txt));
            }

            if (manager.postRoutineE == 6 && gameObject.tag == "Like2" && manager.epath == true && manager.spath == false)
            {
                //E 6 --> E 9/10
                manager.post6E_bool = true;
                StartCoroutine(GoToNewPostE(manager.post9E_Imag, manager.post9E_Txt, manager.post10E_Imag, manager.post10E_Txt));
            }

            if (manager.postRoutineE == 7 && gameObject.tag == "Like2" && manager.epath == true && manager.spath == false)
            {
                //E 10 --> LoadAfter
                manager.post10E_bool = true;
                manager.LoadAfterLvl2();
            }

            if (manager.postRoutineE == 5 && gameObject.tag == "Like2" && manager.epath == true && manager.spath == false)
            {
                //E 8 --> LoadAfter
                manager.post8E_bool = true;
                manager.LoadAfterLvl2();
            }



            //S-path Left
            if (manager.postRoutineS == 2 && gameObject.tag == "Like2" && manager.spath == false && manager.epath == false)
            {
                //S 1 --> S 2/3
                manager.spath = true;
                manager.post1S_bool = true;
                StartCoroutine(GoToNewPostS(manager.post2S_Imag, manager.post2S_Txt, manager.post3S_Imag, manager.post3S_Txt));
            }

            if (manager.postRoutineS == 3 && gameObject.tag == "Like1" && manager.spath == true && manager.epath == false)
            {
                //S 2 --> S 4/5
                manager.post2S_bool = true;
                StartCoroutine(GoToNewPostS(manager.post4S_Imag, manager.post4S_Txt, manager.post5S_Imag, manager.post5S_Txt));
            }
            if (manager.postRoutineS == 4 && gameObject.tag == "Like1" && manager.spath == true && manager.epath == false)
            {
                //S 4 --> S 7/8
                manager.post4S_bool = true;
                StartCoroutine(GoToNewPostS(manager.post7S_Imag, manager.post7S_Txt, manager.post8S_Imag, manager.post8S_Txt));
            }

            if (manager.postRoutineS == 6 && gameObject.tag == "Like1" && manager.spath == true && manager.epath == false)
            {
                //S 5 --> S 8/9
                manager.post5S_bool = true;
                StartCoroutine(GoToNewPostS(manager.post8S_Imag, manager.post8S_Txt, manager.post9S_Imag, manager.post9S_Txt));
            }

            if (manager.postRoutineS == 7 && gameObject.tag == "Like2" && manager.spath == true && manager.epath == false)
            {
                //S 9 --> LoadAfter
                manager.post9S_bool = true;
                manager.LoadAfterLvl2();
            }

            if (manager.postRoutineS == 5 && gameObject.tag == "Like2" && manager.spath == true && manager.epath == false)
            {
                //S 7 --> LoadAfter
                manager.post7S_bool = true;
                manager.LoadAfterLvl2();
            }


            //S-path Right
            if (manager.postRoutineS == 3 && gameObject.tag == "Like2" && manager.spath == true && manager.epath == false)
            {
                //S 3 --> S 5/6
                tempBoolS = true;
                manager.post3S_bool = true;
                StartCoroutine(GoToNewPostS(manager.post5S_Imag, manager.post5S_Txt, manager.post6S_Imag, manager.post6S_Txt));
            }

            if (manager.postRoutineS == 4 && gameObject.tag == "Like2" && manager.spath == true && manager.epath == false)
            {
                //S 5 --> S 8/9
                manager.post5S_bool = true;
                StartCoroutine(GoToNewPostS(manager.post8S_Imag, manager.post8S_Txt, manager.post9S_Imag, manager.post9S_Txt));
            }

            if (manager.postRoutineS == 6 && gameObject.tag == "Like2" && manager.spath == true && manager.epath == false)
            {
                //S 6 --> S 9/10
                manager.post6S_bool = true;
                StartCoroutine(GoToNewPostS(manager.post9S_Imag, manager.post9S_Txt, manager.post10S_Imag, manager.post10S_Txt));
            }


            if (manager.postRoutineS == 7 && gameObject.tag == "Like2" && manager.spath == true && manager.epath == false)
            {
                //S 10 --> LoadAfter
                manager.post10S_bool = true;
                manager.LoadAfterLvl2();
            }

            if (manager.postRoutineS == 5 && gameObject.tag == "Like2" && manager.spath == true && manager.epath == false)
            {
                //S 8 --> LoadAfter
                manager.post8S_bool = true;
                manager.LoadAfterLvl2();
            }

        }

    }

}
