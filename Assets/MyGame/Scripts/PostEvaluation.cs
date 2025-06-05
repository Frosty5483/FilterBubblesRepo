using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PostEvaluation : MonoBehaviour
{
    [SerializeField] private PostCreator creator;

    [Header ("Post Data")]
    public TextMeshProUGUI caption;
    public TextMeshProUGUI hashtag;
    public TextMeshProUGUI likes;
    public Image image;

    private int randomNumber;
    //private bool isfilled = false;


    public Post currentPost;

    private void Update()
    {
        //if (isfilled) { isfilled = false; LikesNumber(); }
    }
    public void FillEvaluator(int postIndex)
    {
        Debug.Log(postIndex);
        currentPost = creator.posts[postIndex];
        caption.text = currentPost.caption;
        hashtag.text = currentPost.hashtag1 + " " + currentPost.hashtag2;
        image.sprite = currentPost.image;
        //isfilled = true;

    }
    public void LikesNumber()
    {
        randomNumber = Random.Range(3000, 150000);

        for (int i = 0; i < randomNumber; i = i+1000)
        {
            likes.text = i.ToString();
            StartCoroutine(LikeWait(randomNumber));
        }
    }
    IEnumerator LikeWait(int number)
    {
        Debug.Log("wehhhaa");
        if (number < 50000)
        {
            yield return new WaitForSeconds(0.1f);
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
        }
    }
}
