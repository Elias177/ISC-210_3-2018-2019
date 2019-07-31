using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PressStartController : MonoBehaviour
{
    public TextMeshPro text;
    public TextMeshPro Score;
    private int loopcont = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitText());
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(PostRequest("http://localhost:3000/api/Scores"));
        StartCoroutine(GetText());

    }

    // Update is called once per frame



    IEnumerator WaitText()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            text.transform.position = new Vector3(0.7f, -3.4f, 0);
            yield return new WaitForSeconds(0.5f);
            text.transform.position = new Vector3(0.7f, -3.4f, 1);
        }
    }

    IEnumerator PostRequest(string url)
    {
        loopcont = PlayerPrefs.GetInt("Loop");

        WWWForm form = new WWWForm();
        form.AddField("loops", loopcont);
        form.AddField("name", "Unity");
        form.AddField("cantcleared", 0);

        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        Debug.Log("Recibido: " + uwr.downloadHandler.text);

    }

    IEnumerator GetText()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/api/Scores"))
        {
            yield return request.Send();

            if (request.isNetworkError) // Error
            {
                Debug.Log(request.error);
            }
            else // Success
            {
                Debug.Log("Llego: " + request.downloadHandler.text);
            }
        }
    }

}
