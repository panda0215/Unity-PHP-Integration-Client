using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class Web : MonoBehaviour
{
    public static Web _instance = null;

    private Coroutine Request_Coroutine_POST = null;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    void Start()
    {
        //// A correct website page.
        //StartCoroutine(GetRequest("http://localhost/my_vie/GetDate.php"));

        //// A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }

    public void Post_Request(string URI, WWWForm data)
    {
        Debug.Log(URI);
        if (Request_Coroutine_POST != null)
        {
            StopCoroutine(Request_Coroutine_POST);
            Request_Coroutine_POST = null;
        }
        Request_Coroutine_POST = StartCoroutine(Post_Coroutine(URI, data));
    }

    IEnumerator Post_Coroutine(string URI, WWWForm data)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Post(URI, data))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("Request Error: " + webRequest.error);
            }
            else
            {
                Debug.Log("Request Received: " + webRequest.downloadHandler.text);
            }
            FindObjectOfType<DataInserter>().Submit.interactable = true;
        }
        yield return null;
    }

    
}