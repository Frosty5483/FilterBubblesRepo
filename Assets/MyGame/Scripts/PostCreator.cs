using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PostCreator : MonoBehaviour
{
    public List<PostData> data;
    private int index;

    [Header("Data to change")]
    // Die Texte der Auswahlmöglichkeiten
    [SerializeField] private Image image;
    [SerializeField] private Text caption1, caption2;
    [SerializeField] private Text[] hashtagTexts;

    [Header("Post UI")]
    // Die Texte des "Posts"
    [SerializeField] private TextMeshProUGUI captionPost;
    [SerializeField] private TextMeshProUGUI[] hashtagPost;

    [Header("Others")]
    bool hashtagSwitch = true;
    int lastIndex = 4;
    [SerializeField] private GameObject errorText;
    [SerializeField] private GameObject postEvaluatorCanvas;
    [SerializeField] private GameObject postCreatorCanvas;
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
        errorText.SetActive(false);

        postEvaluation = FindObjectOfType<PostEvaluation>();
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
            index++;
            UpdateData(data[index]);
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
        yield return new WaitForSeconds(5);
        postEvaluatorCanvas.SetActive(false);
        postCreatorCanvas.SetActive(true);
    }
    IEnumerator DoNextFrame()
    {
        yield return null;
        postEvaluation.LikesNumber();
    }

    IEnumerator ErrorText()
    {
        errorText.SetActive(true);
        yield return new WaitForSeconds(3);
        errorText.SetActive(false);
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
