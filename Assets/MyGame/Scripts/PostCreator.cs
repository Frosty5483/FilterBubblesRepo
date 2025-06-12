using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostCreator : MonoBehaviour
{
    public List<PostData> data;
    public List<PostDataFeed> feedData;
    private int index;

    [Header("Data to change")]
    // Die Texte der Auswahlmöglichkeiten
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI caption1, caption2;
    [SerializeField] private TextMeshProUGUI[] hashtagTexts;

    [Header("Post UI")]
    // Die Texte des "Posts"
    [SerializeField] private TextMeshProUGUI captionPost;
    [SerializeField] private TextMeshProUGUI[] hashtagPost;

    [Header("Feed UI")]
    [SerializeField] private TextMeshProUGUI[] feedCaptions;
    [SerializeField] private TextMeshProUGUI[] feedHashtags;
    [SerializeField] private TextMeshProUGUI[] feedComments;
    [SerializeField] private Image[] feedImages;

    [Header("End Evaluation")]
    [SerializeField] private TextMeshProUGUI captionEnd1, captionEnd2;
    [SerializeField] private TextMeshProUGUI hashtagEnd1, hashtagEnd2;
    [SerializeField] private Image imageEnd1, imageEnd2;
    [SerializeField] private TextMeshProUGUI infotext;
    [SerializeField] private GameObject explainationCanvas;


    [Header("Others")]
    bool hashtagSwitch = true;
    int lastIndex = 4;
    [SerializeField] private GameObject errorText;
    [SerializeField] private GameObject postEvaluatorCanvas;
    [SerializeField] private GameObject postCreatorCanvas;
    [SerializeField] private GameObject postEndCanvas;
    private PostEvaluation postEvaluation;

    [Header("Finished Posts")]
    bool captionSet = false;
    bool hashtag1Set = false;
    bool hashtag2Set = false;
    public List<Post> posts;



    void Start()
    {
        index = 0;
        UpdateData(data[index]);
        UpdateFeed(feedData[index]);
        errorText.SetActive(false);

        postEvaluation = FindObjectOfType<PostEvaluation>();
    }

    private void Update()
    {
        postEvaluation = FindObjectOfType<PostEvaluation>();
        Debug.Log("postEvaluation.evaluationindex1 is: " + postEvaluation.evaluationindex1);
        Debug.Log("index: " + index);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LevelSelector");
        }
    }

    public void UpdateData(PostData data)
    {
        // Auswahlmöglichkeiten auf neue ändern
        image.sprite = data.image1;

        caption1.text = data.caption1;
        caption2.text = data.caption2;

        hashtagTexts[0].text = data.hashtag1;
        hashtagTexts[1].text = data.hashtag2;
        hashtagTexts[2].text = data.hashtag3;
        hashtagTexts[3].text = data.hashtag4;

        // Ausgewählte Auswahlmöglichkeiten aus dem "Post" löschen
        captionPost.text = null;
        hashtagPost[0].text = null;
        hashtagPost[1].text = null;

        captionSet = false;
        hashtag1Set = false;
        hashtag2Set = false;
    }

    public void UpdateFeed(PostDataFeed data)
    {
        // Feed ändern/ausfüllen
        feedImages[0].sprite = data.image1;
        feedImages[1].sprite = data.image2;

        feedCaptions[0].text = data.caption1;
        feedCaptions[1].text = data.caption2;
        feedCaptions[2].text = data.caption3;
        feedCaptions[3].text = data.caption4;
        feedCaptions[4].text = data.caption5;


        feedHashtags[0].text = data.hashtag1;
        feedHashtags[1].text = data.hashtag2;
        feedHashtags[2].text = data.hashtag3;
        feedHashtags[3].text = data.hashtag4;
        feedHashtags[4].text = data.hashtag5;

        feedComments[0].text = data.comment1;
        feedComments[1].text = data.comment2;
        feedComments[2].text = data.comment3;
        feedComments[3].text = data.comment4;
    }

    public void Done()
    {
        if (captionSet && hashtag1Set && hashtag2Set)
        {
            FinishedPost(posts[index]);
            // Hier Scenen wechsel, wenn es keine Posts mehr gibt
            // Hier Scenen wechsel, wenn es keine Posts mehr gibt
            // Hier Scenen wechsel, wenn es keine Posts mehr gibt
            // Hier Scenen wechsel, wenn es keine Posts mehr gibt
            // Hier Scenen wechsel, wenn es keine Posts mehr gibt
            // Hier Scenen wechsel, wenn es keine Posts mehr gibt
            StartCoroutine(PostEvaluationOngoing());
            StartCoroutine(DoNextFrame());
            if (index != 5) { index++; } else { postEvaluation.finished = true; }
                UpdateData(data[index]);
            UpdateFeed(feedData[index]);
        }
        else
        {
            StartCoroutine(ErrorText());
        }
    }
    IEnumerator PostEvaluationOngoing()
    {
        postEvaluation.FillEvaluator(index);
        postEvaluatorCanvas.SetActive(true);
        postCreatorCanvas.SetActive(false);
        yield return new WaitForSeconds(6.5f);
        if (!postEvaluation.finished) { postEvaluatorCanvas.SetActive(false); postCreatorCanvas.SetActive(true); }
        else { postEndCanvas.SetActive(true); postEvaluatorCanvas.SetActive(false); postCreatorCanvas.SetActive(false); UpdateEndEvaluation(postEvaluation.evaluationindex1, postEvaluation.evaluationindex2); }
    }
    IEnumerator DoNextFrame()
    {
        yield return null;
        postEvaluation.LikesNumber();
    }

    IEnumerator ErrorText()
    {
        errorText.SetActive(true);
        yield return new WaitForSeconds(3f);
        errorText.SetActive(false);
    }
    IEnumerator EndEvaluation()
    {
        yield return new WaitForSeconds(4);
        if (postEvaluation.evaluationindex1 != 3) { UpdateEndEvaluation(postEvaluation.evaluationindex1, postEvaluation.evaluationindex2); }
        else { explainationCanvas.SetActive(true); }

    }
    public void UpdateEndEvaluation(int a, int b)
    {
        captionEnd1.text = posts[a].caption;
        captionEnd2.text = posts[b].caption;

        hashtagEnd1.text = posts[a].hashtag1 + " " + posts[a].hashtag2;
        hashtagEnd2.text = posts[b].hashtag1 + " " + posts[b].hashtag2;

        imageEnd1.sprite = posts[a].image;
        imageEnd2.sprite = posts[b].image;

        if (postEvaluation.evaluationindex1 == 2) { postEvaluation.evaluationindex1 = 3; infotext.text = "Is icecream now better or pizza?"; }
        if (postEvaluation.evaluationindex1 == 1) { postEvaluation.evaluationindex1 = 2; postEvaluation.evaluationindex2 = 4; infotext.text = "Is spiderman now better or superman?"; }
        if (postEvaluation.evaluationindex1 == 0) { postEvaluation.evaluationindex1 = 1; postEvaluation.evaluationindex2 = 3; infotext.text = "Are dogs now better or cats?"; }


        StartCoroutine(EndEvaluation());
    }

    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }



    public void ChangeImage()
    {
        // Für die Buttons um zwischen den zwei Bildern zu switchen
        if (image.sprite == data[index].image1)
        {
            image.sprite = data[index].image2;
        }
        else
        {
            image.sprite = data[index].image1;
        }
    }

    public void SetCaption(int buttonIndex)
    {
        // Die Ausgewählte Caption in den "Post" laden
        switch (buttonIndex)
        {
            case 0:
                captionPost.text = caption1.text;
                break;
            case 1:
                captionPost.text = caption2.text;
                break;
        }
        captionSet = true;
    }

    public void SetHashtag(int buttonIndex)
    {
        // Den ausgewählten Hashtag in den "Post" laden
        if (hashtagSwitch && lastIndex != buttonIndex)
        {
            hashtagPost[0].text = hashtagTexts[buttonIndex].text;
            hashtagSwitch = false;
            hashtag1Set = true;
        }
        else if (lastIndex != buttonIndex)
        {
            hashtagPost[1].text = hashtagTexts[buttonIndex].text;
            hashtagSwitch = true;
            hashtag2Set = true;
        }
        lastIndex = buttonIndex;
    }

    public void FinishedPost(Post post)
    {
        // Speichert den fertigen Post in ein Post Objekt mit dem index index
        post.caption = captionPost.text;
        post.hashtag1 = hashtagPost[0].text;
        post.hashtag2 = hashtagPost[1].text;
        post.image = image.sprite;
    }
}
