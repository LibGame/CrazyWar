using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{

    public GameObject BlockPrefabs;
    public GameObject AmunitionBlockPrefabs;
    public CameraController _cameraControll;
    public int HeihtAmounBlocks;
    public int WidthAmounBlocks;
    public int AmounBlocks;
    private float _xPos = -20f;
    private float _yPos = 10f;
    private float leftLimit = -20f;
    private float rightLimit;
    private float upperLimit = 10f;
    private float bottomLimit;
    public bool _isSetRight;

    private void Start()
    {
        BlocksCreators();
    }

    public void BlocksCreators()
    {
        for(int x = 0; x < AmounBlocks; x++)
        {
            _xPos += 1.13f;
            if (x % WidthAmounBlocks == 0)
            {

                rightLimit = _xPos;
                _yPos -= 1.13f;
                _xPos = -20f;

            }

            if (Random.Range(1,10) > 8)
            {
                Instantiate(AmunitionBlockPrefabs, new Vector2(_xPos, _yPos), Quaternion.identity);
            }
            else
            {
                Instantiate(BlockPrefabs, new Vector2(_xPos, _yPos), Quaternion.identity);
            }
        }
        bottomLimit = _yPos;

        _cameraControll.LimmitSetter(leftLimit, rightLimit, upperLimit, bottomLimit);
    }
}
