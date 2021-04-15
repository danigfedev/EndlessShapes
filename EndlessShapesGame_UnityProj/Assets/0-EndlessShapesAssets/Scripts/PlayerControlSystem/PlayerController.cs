using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player position limits")]
    [Tooltip("Player's left limit")]
    public float minXLimit = -6.67f;
    [Tooltip("Player's right limit")]
    public float maxXLimit = 6.67f;
    [Tooltip("Player's delta movement")]
    public float stepX = 6.67f;
    
    public Transform shapeParent;
    public GameObject deathParticleSystem;

    private List<GameObject> shapeList;
    private int currentShapeIndex = 0;

    private void Awake()
    {
        InitializeShapes();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveLeft();
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveRight();
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            ToggleShapeNext();
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            ToggleShapePrevious();
    }

    public void OnOutputTriggerEnter()
    {
        //Count gate
        //Trigger gate dissolve effect
    }

    private void InitializeShapes()
    {
        shapeList = new List<GameObject>();
        for (int i = 0; i < shapeParent.childCount; i++)
        {
            GameObject shape = shapeParent.GetChild(i).gameObject;
            shape.SetActive(i == currentShapeIndex);
            shapeList.Add(shape);
        }

        deathParticleSystem.SetActive(false);
    }

    /// <summary>
    /// Checks whether the player has reached the left limit or not.
    /// </summary>
    /// <returns>true if player has reached the limit, false if not</returns>
    private bool CheckMinXLimit()
    {
        if (Mathf.Abs(transform.position.x - minXLimit) < 0.01f)
            return true;
        return false;
    }

    /// <summary>
    /// Checks whether the player has reached the right limit or not.
    /// </summary>
    /// <returns>true if player has reached the limit, false if not</returns>
    private bool CheckMaxXLimit()
    {
        if (Mathf.Abs(transform.position.x - maxXLimit) < 0.01f)
            return true;
        return false;
    }

    public void CountGate()
    {

    }
    
    
    [ContextMenu("PlayerDie")]
    public void Die()
    {
        foreach (GameObject shape in shapeList)
            shape.SetActive(false);
        deathParticleSystem.SetActive(true);
    }

    /// <summary>
    /// Moves player one step to the left
    /// </summary>
    public void MoveLeft()
    {
        if (CheckMinXLimit()) return;
        transform.position -= transform.right * stepX;
    }

    /// <summary>
    /// Moves player one step to the right
    /// </summary>
    public void MoveRight()
    {
        if (CheckMaxXLimit()) return;
        transform.position += transform.right * stepX;
    }


    /// <summary>
    /// Moves to next shape
    /// </summary>
    public void ToggleShapeNext()
    {
        HideShape(currentShapeIndex);
        currentShapeIndex = CorrectShapeIndex(++currentShapeIndex);
        ShowShape(currentShapeIndex);
    }

    /// <summary>
    /// Moves to prevous shape
    /// </summary>
    private void ToggleShapePrevious()
    {
        HideShape(currentShapeIndex);
        currentShapeIndex = CorrectShapeIndex(--currentShapeIndex);
        ShowShape(currentShapeIndex);
    }

    /// <summary>
    /// Corrects given  shapeList's index
    /// </summary>
    /// <param name="newIndex"></param>
    /// <returns>A valid index value</returns>
    private int CorrectShapeIndex(int newIndex)
    {
        if (newIndex >= shapeList.Count)
            return 0;
        else if (newIndex < 0)
            return shapeList.Count - 1;
        else
            return newIndex;
    }

    private void ShowShape(int shapeIndex)
    {
        shapeList[shapeIndex].SetActive(true);
    }

    private void HideShape(int shapeIndex)
    {
        shapeList[shapeIndex].SetActive(false);
    }

}
