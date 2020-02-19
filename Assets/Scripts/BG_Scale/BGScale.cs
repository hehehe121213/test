using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {

        SpriteRenderer sr = GetComponent<SpriteRenderer> ();
        Vector3 tempScale = transform.localScale;


        float Height = sr.bounds.size.y ;
        float Weight = sr.bounds.size.x;

        float BGHeight = Camera.main.orthographicSize * 2f;
        float BGWeight = BGHeight * Screen.width / Screen.height;

        tempScale.y = BGHeight / Height;
        tempScale.x = BGWeight / Weight;

        transform.localScale = tempScale;
    }

    
    
}
