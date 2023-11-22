using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }
 
    [SerializeField]
    private GameObject ballPrefab;
 
    [SerializeField]
    private GameObject[] ballPosition;
    
    [SerializeField]
    private GameObject cueBall;
    
    [SerializeField]
    private GameObject ballLine;
    
    [SerializeField]
    private float xInput;
 
    public static GameManager instance;
 
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SetBall(BallColor.White, 0);
        SetBall(BallColor.Red, 1);
        SetBall(BallColor.Yellow, 2);
        SetBall(BallColor.Green, 3);
        SetBall(BallColor.Brown, 4);
        SetBall(BallColor.Blue, 5);
        SetBall(BallColor.Pink, 6);
        SetBall(BallColor.Black, 7);
    }
 
    // Update is called once per frame
    void Update()
    {
        RotateBall();
    }
 
    private void SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(ballPrefab,
            ballPosition[i].transform.position,
            Quaternion.identity);
        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }

    private void RotateBall()
    {
        xInput = Input.GetAxis("Horizontal");
        cueBall.transform.Rotate(new Vector3(0f,xInput/20f,0f));
        
    }
}