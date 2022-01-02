using System.Collections;
using System.Runtime.Serialization;
using UnityEngine.Networking;
using UnityEngine;

public class NetworkTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("localhost:7000/api/v1/"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            string json = webRequest.downloadHandler.text;
            MyClass myObject = new MyClass();
            myObject = JsonUtility.FromJson<MyClass>(json);
            Debug.Log(myObject.another);
            Debug.Log(myObject.status);
        }
    }
}

public class MyClass
{
    public string status;
    public string another;
}
