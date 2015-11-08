using UnityEngine;
using System.Collections;
using System;

public class Tile : MonoBehaviour 
{

    public GameObject TopLeft;
    public GameObject TopMid;
    public GameObject TopRight;
    public GameObject Left;
    public GameObject Right;
    public GameObject BottomLeft;
    public GameObject BottomMid;
    public GameObject BottomRight;

    public TextMesh Value;
    public Sprite star;
    public Sprite win_tile;
    public Sprite star_win_tile;
    public bool touchy;
    public bool CanTouch { get; set; }
    public bool IsWinCondition = false;
    public bool WinMarked = false;

    private SpriteRenderer sr;
    public static float elapsedTime = 0;

	// Use this for initialization
	void Start () 
    {
        CanTouch = true;
        touchy = CanTouch;
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        UpdateTileImage();
        StartCoroutine(ChangeTileColors());
	}
	
    public void ColorTile(Color color)
    {
        sr.color = color;
    }

    public void ReEnableColorCoroutine()
    {
        StartCoroutine(ChangeTileColors());
    }

    public IEnumerator RotateDiagonal()
    {
        // Every time activated, set to original position. 
        transform.rotation = Quaternion.identity;
        Value.transform.position = new Vector3(transform.position.x, transform.position.y, -.001f);

        Quaternion fromAngle = transform.rotation;
        Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 50));
        Quaternion backAngle = Quaternion.Euler(transform.eulerAngles - new Vector3(0, 0, 50));
        int passes = 0;
        while (passes < 2)
        {
            for (float t = 0; t < 1; t += Time.deltaTime / 0.25f)
            {
                transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
                yield return new WaitForEndOfFrame();
            }
            for (float t = 0; t < 1; t += Time.deltaTime / 0.5f)
            {
                transform.rotation = Quaternion.Lerp(toAngle, backAngle, t);
                yield return new WaitForEndOfFrame();
            }
            for (float t = 0; t < 1; t += Time.deltaTime / 0.25f)
            {
                transform.rotation = Quaternion.Lerp(backAngle, fromAngle, t);
                yield return new WaitForEndOfFrame();
            }
            passes += 1;
        }

        transform.rotation = Quaternion.identity;
        if (Int32.Parse(Value.text) < 10 && Int32.Parse(Value.text) > 0)
        {
            Value.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            Value.GetComponent<MeshRenderer>().enabled = false;
        }
        Value.transform.position = new Vector3(transform.position.x, transform.position.y, -.001f);
        yield return null;
    }

    public IEnumerator ChangeTileColors()
    {
        while(CanTouch)
        {
            while(TileList.IncrementTimer)
            {
                if (!CanTouch)
                {
                    StopCoroutine(ChangeTileColors());
                    sr.color = Color.white;
                    break;
                }

                sr.color = Color.Lerp(Color.white, Color.red, TileList.Timer);
             
                yield return new WaitForEndOfFrame();
            }
        }
    }

    public void UpdateTileImage()
    {
        if (Int32.Parse(Value.text) >= 10)
        {
            if (IsWinCondition)
            {
                sr.sprite = star_win_tile;
            }
            else
            {
                sr.sprite = star;
            }
            //Debug.Log(Value.text);
            Value.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (Int32.Parse(Value.text) <= 0)
        {
            if (IsWinCondition)
            {
                sr.sprite = win_tile;
            }

            Value.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            if (IsWinCondition)
            {
                sr.sprite = win_tile;
            }
        }
    }
}
