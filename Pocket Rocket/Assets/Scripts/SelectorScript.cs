using System;
using UnityEngine;

public class SelectorScript : MonoBehaviour
{
    public GameObject greenShip;
    public GameObject wierdShip;
    public GameObject ufoShip;

    Rigidbody greenShipRigibody;

    private Vector3 shipPos;
    private Vector3 offScreenPos;
    private int CharacterInt = 1;
    private MeshRenderer greenShipRenderer, wierdShipRenderer, ufoShipRenderer;
    private readonly string selectedShip = "SelectedShip";

    private void Awake()
    {
        shipPos = new Vector3(-11,3,-1);
        offScreenPos = new Vector3(-141,0,0);
        greenShipRenderer = GetComponent<MeshRenderer>();
        wierdShipRenderer = GetComponent<MeshRenderer>();
        ufoShipRenderer = GetComponent<MeshRenderer>();

    }

    public void NextCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedShip, 1);
                greenShip.transform.position = offScreenPos;
                wierdShip.transform.position = shipPos;
                CharacterInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedShip, 2);
                wierdShip.transform.position = offScreenPos;
                ufoShip.transform.position = shipPos;
                CharacterInt++;
                
                break;
            case 3:
                PlayerPrefs.SetInt(selectedShip, 3);
                ufoShip.transform.position = offScreenPos;
                greenShip.transform.position = shipPos;
                CharacterInt++;
                break;
            default:
                ResetInt();
                break;
        }
    }

    public void PreviousCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedShip,2);
                greenShip.transform.position = offScreenPos;
                ufoShip.transform.position = shipPos;
                CharacterInt++;
               
                break;
            case 2:
                PlayerPrefs.SetInt(selectedShip, 1);
                ufoShip.transform.position = offScreenPos;
                wierdShip.transform.position = shipPos;
                CharacterInt++;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedShip, 3);
                wierdShip.transform.position = offScreenPos;
                greenShip.transform.position = shipPos;
                CharacterInt++;
                break;
            default:
                ResetInt();
                break;
        }
    }

    private void ResetInt()
    {
        if (CharacterInt >= 3)
        {
            CharacterInt = 1;
        }
        else
        {
            CharacterInt = 3;
        }
    }
}
