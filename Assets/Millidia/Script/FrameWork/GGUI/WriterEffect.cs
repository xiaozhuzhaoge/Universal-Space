using UnityEngine;
using System.Collections;
using System.Text;

public class WriterEffect : MonoBehaviour {

    public UILabel label;
    private string text;
    public bool isActive;

    public string Text {
        set {
            text = value;
            isActive = true;
        }
        get
        {
            return text;
        }
    }

    public float speed;

    public void Update()
    {
        if (isActive)
        {
            PlayAnimation();
        }
    }

    public void PlayAnimation()
    {
        isActive = false;
        if (label == null)
            return;
        StopAllCoroutines();
        label.text = "";
        StartCoroutine(startWriterEffect());
    }

    IEnumerator startWriterEffect()
    {
        int start = 0;
        StringBuilder sb = new StringBuilder();

        while (start < text.Length)
        {
            //若包含BBCODE颜色片段，取得片段首至片段结尾的索引，然后根据索引跳过
            if (Text.Contains("[-]"))
            {
                if (Text.ToCharArray()[start] == '[')
                {
                    Debug.Log(Text);
                    int endIndexShift = Text.IndexOf("[-]") + 3;
                    StringBuilder temp = new StringBuilder();
                    for (int i = start; i < endIndexShift; i++)
                    {
                       temp.Append(Text.ToCharArray()[i]);
                    }
                    Debug.Log(temp);
                    start = endIndexShift;
                    sb.Append(temp);
                }
            }
            sb.Append(Text.ToCharArray()[start]);
  
            if (label == null)
                break;

            label.text = sb.ToString();
            yield return new WaitForSeconds(speed);
            start++;
        }
    }

    void OnDisable()
    {
        if (label != null)
            label.text = "";
    }
}
