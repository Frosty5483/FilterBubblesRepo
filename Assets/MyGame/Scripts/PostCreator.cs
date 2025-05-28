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
    [SerializeField] private Image image;
    [SerializeField] private Text caption1, caption2;
    [SerializeField] private Text hashtag1, hashtag2, hashtag3, hashtag4;

    [Header("Post UI")]
    [SerializeField] private Text caption;
    [SerializeField] private Text hashtagText1;
    [SerializeField] private Text hashtagText2;


    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        UpdateData(data[index]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateData(PostData data)
    {
        image.sprite = data.image1;

        caption1.text = data.caption1;
        caption2.text = data.caption2;

        hashtag1.text = data.hashtag1;
        hashtag2.text = data.hashtag2;
        hashtag3.text = data.hashtag3;
        hashtag4.text = data.hashtag4; 
    }

    public void Done()
    {
        index++;
        UpdateData(data[index]);
    }

    public void ChangeImage()
    {
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
        switch (buttonIndex)
        {
            case 0:
                caption.text = caption1.text;
                break;
            case 1:
                caption.text = caption2.text;
                break;
        }
    }

    public void SetHashtag(int buttonIndex)
    {
     
    }
}
