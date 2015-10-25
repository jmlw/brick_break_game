using UnityEngine;
using System.Collections.Generic;

public class Paddle : MonoBehaviour, IPaddle
{

    public int playerTags = 5;

    private enum Direction
    {
        LEFT = -1,
        RIGHT = 1
    }
    ;

    private float skinWidth = 0.15f;
    private GameplayData gameData;
    private GameObject paddleGameObject;
    private Transform paddleTransform;
    private Vector2 paddlePosition;

    private struct PaddleSizes {
        //list of paddle sizes
        int currentActiveSize;
        int previousActiveSize;
        GameObject[] sizes;
       
        float width;
        float paddleLeft;
        float paddleRight;

        public PaddleSizes(GameObject[] sizesArray) : this() {
            if (sizesArray.Length == 5) {
                sizes = sizesArray;
                currentActiveSize = -1;
                previousActiveSize = -1;
            } else {
                Logger.Error("Must have a minimum size at index 0, and standard size at index 1");
            }

            setActivePaddleSize(1);
        }

        void setActivePaddleSize(int sizeIndex) {
            Logger.Debug("Paddle.PaddleSizes.setActivePaddleSize");
            if ( !(sizeIndex == currentActiveSize)) {
                Logger.Debug("Setting active paddle size to : " + sizeIndex +
                             "\nGameObject Name : "+ sizes[sizeIndex].name);
                if (previousActiveSize != -1) 
                    sizes[previousActiveSize].SetActive(false);

                previousActiveSize = currentActiveSize;
                currentActiveSize = sizeIndex;

                sizes[currentActiveSize].SetActive(true);
            }

            calculatePaddleValidPlayArea();
        }
        
        void resetPaddleSize() {
            Logger.Debug("Paddle.PaddleSizes.resetPaddleSize");
            setActivePaddleSize(1);
        }
        
        void decreasePaddleSize() {
            Logger.Debug("Paddle.PaddleSizes.decreasePaddleSize");
            if (currentActiveSize != 0) {
                setActivePaddleSize(currentActiveSize -1);
            }
        }
        
        void increasePaddleSize() {
            Logger.Debug("Paddle.PaddleSizes.increasePaddleSize");
            if (currentActiveSize != 4) {
                setActivePaddleSize(currentActiveSize + 1);
            }
        }

        void calculatePaddleValidPlayArea() {
            //TODO:
            width = sizes[currentActiveSize].transform.localScale.x;
            Vector2 localPosition = (Vector2)sizes[currentActiveSize].transform.position;
            paddleLeft = localPosition.x - width / 2;
            paddleRight = localPosition.x + width / 2;
        }
    }

    // Set this in the inspector to edit gameplay on the fly (y position and starting x)
    public Vector2 startPosition;
    public float paddleVelosity;
    public float maximumVelosity;

    // left and right bounds represent farthest center of paddle can go
    private float leftBoundPosition;
    private float rightBoundPosition;
    private float paddleWidth;
    private GameObject _attachedBall;

    private Vector2 lastPosition;

    void Awake()
    {


        paddleTransform = this.transform;
        paddleGameObject = this.gameObject;

        GameObject[] children = enumerateChildren();
        Logger.Debug("test: " + children.Length);

        PaddleSizes thisPaddleSize = new PaddleSizes(children);

        lastPosition = paddleTransform.position;
    }

    void Start()
    {
        gameData = GameplayData.Instance;
        gameData.registerPaddle(this.gameObject);
        Transform leftBorder;
        Transform rightBorder;
        Dictionary<GameplayData.boundary, Transform> bounds = gameData.getBounds();
        leftBorder = bounds [GameplayData.boundary.LEFT];
        rightBorder = bounds [GameplayData.boundary.RIGHT];
        
        leftBoundPosition = leftBorder.transform.position.x + leftBorder.transform.localScale.x / 2 + paddleWidth / 2;
        rightBoundPosition = rightBorder.transform.position.x - rightBorder.transform.localScale.x / 2 - paddleWidth / 2;
    }
    
    void Update()
    {
        lastPosition = paddleTransform.position;
//         horizontal movement
//        paddlePosition = paddleTransform.position;
//
//        paddlePosition.x += normalizeAxis(Input.GetAxis("Horizontal")) * paddleVelosity;
//
//        paddleTransform.position = Vector2.Lerp(paddleTransform.position, paddlePosition, Time.deltaTime);
//
//        if (paddleTransform.position.x <= leftBoundPosition) {
//            paddleTransform.position = new Vector2(leftBoundPosition, paddleTransform.position.y);
//        } else if (paddleTransform.position.x >= rightBoundPosition) {
//            paddleTransform.position = new Vector2(rightBoundPosition, paddleTransform.position.y);
//        }
//        
//        if (_attachedBall != null)
//        {
//            _attachedBallTransform.position = new Vector2(paddleTransform.position.x, _attachedBallTransform.position.y);
//
//            if (Input.GetKeyDown("Space")){
//                detachBall();
//            }
//        }
    }

    GameObject[] enumerateChildren() {
        GameObject[] children = new GameObject[playerTags];
        int childIndex = 0;
        for (int i = 0; i < paddleTransform.childCount - 1; i ++){
            Logger.Debug("Paddle.Start.enumerateChildren - for index: " + i);
            if (paddleTransform.GetChild(i).tag == "Player") {
                children[childIndex] = paddleTransform.GetChild(i).gameObject;
                childIndex++;
                Logger.Debug("Paddle.Start.enumerateChildren - for - child of tag \"Player\" found!" +
                             "\nAdding to children list at index: " + childIndex);
            }
        }

        return children;
    }

    int normalizeAxis(float input)
    {
        if (input > 0)
        {
            return 1;
        } else if (input < 0)
        {
            return -1;
        } else
        {
            return 0;
        }
    }

    void Move(Vector2 moveLocation)
    {
        Vector2 newPosition;
        int direction = (int)Mathf.Sign(moveLocation.x);
        if (CheckCollisionWithBoarder(direction)) {

            //TODO: perform move

        }
        //TODO: implement


    }

    bool CheckCollisionWithBoarder(int direction)
    {
        Vector2 raycastOrigin = paddleTransform.position;
        RaycastHit2D hit;
        if (direction == 1) {
            raycastOrigin = new Vector2(raycastOrigin.x + paddleWidth/2, raycastOrigin.y);
            hit = Physics2D.Raycast(raycastOrigin, Vector2.right);
        } else {
            raycastOrigin = new Vector2(raycastOrigin.x - paddleWidth/2, raycastOrigin.y);
            hit = Physics2D.Raycast(raycastOrigin, Vector2.left);
        }

        if (hit) {
            if (hit.distance <= skinWidth) {
                // TODO: Stop movement from going further!!!
                // this should prevent movement of paddle when very close to wall
                // should not cause ball to behave erratically as skinwidth is 
                // less than half the ball size
                return false;
            }
        }

        // TODO: Finish

        return false;
    }

    void IPaddle.Launch() {

    }

    void IPaddle.MoveTo(Vector2 destination) {
        paddleTransform.position = Vector2.Lerp(lastPosition, destination, Time.deltaTime);
    }

}
