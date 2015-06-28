using UnityEngine;
using System.Collections;

public class iTweenHelper 
{
    
    public static IEnumerator Rigging(GameObject go, Vector3 originalPos,Vector3 amount, float time = 1, float wait = 0)
    {
        yield return new WaitForSeconds(wait);
        while (true)
        {
            iTween.MoveTo(go, iTween.Hash("time", time, "easetype", iTween.EaseType.linear, "position", originalPos + amount));
            yield return new WaitForSeconds(time);
            iTween.MoveTo(go, iTween.Hash("time", time, "easetype", iTween.EaseType.linear, "position", originalPos - amount));
            yield return new WaitForSeconds(time);
        }
    }

    public static IEnumerator ScaleForever(GameObject go, Vector3 originalScale, Vector3 amount, float time = 1, float wait = 0)
    {
        yield return new WaitForSeconds(wait);
        while (true)
        {
            iTween.ScaleTo(go, iTween.Hash("time", time, "easetype", iTween.EaseType.linear, "scale", originalScale + amount));
            yield return new WaitForSeconds(time);
            iTween.ScaleTo(go, iTween.Hash("time", time, "easetype", iTween.EaseType.linear, "scale", originalScale - amount));
            yield return new WaitForSeconds(time);
        }
    }

    public static void ScaleTo(GameObject go,Vector3 amount,float time)
    {
        iTween.ScaleTo(go, amount, time);
    }
}
