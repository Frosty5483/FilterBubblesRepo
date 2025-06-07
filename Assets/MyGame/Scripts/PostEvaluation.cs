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

    public int evaluationindex1 = 0;
    public int evaluationindex2 = 5;
    public bool finished = false;


    public Post currentPost;

    private void Update()
    {

    }
    public void FillEvaluator(int postIndex)
    {
        currentPost = creator.posts[postIndex];
        caption.text = currentPost.caption;
        hashtag.text = currentPost.hashtag1 + " " + currentPost.hashtag2;
        image.sprite = currentPost.image;

    }
    public void LikesNumber()
    {
        randomNumber = Random.Range(3000, 150000);

        for (int i = 0; i < randomNumber; i = i+10)
        {
            likes.text = i.ToString();
            StartCoroutine(LikeWait(randomNumber));
        }
    }
    IEnumerator LikeWait(int number)
    {
        yield return null;
    }
}
