using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convert3Dto2DPositions : MonoBehaviour
{
    static Transform _UpLeftCanvas;
    static Transform _DownRightCanvas;
    static Transform _UpLeftTable;
    static Transform _DownRightTable;
    public Transform UpLeftCanvas;
    public Transform DownRightCanvas;
    public Transform UpLeftTable;
    public Transform DownRightTable;
    private void Start()
    {
        _UpLeftCanvas = UpLeftCanvas;
        _DownRightCanvas = DownRightCanvas;
        _UpLeftTable = UpLeftTable;
        _DownRightTable = DownRightTable;
    }
    public static Vector2 Convert3Dto2D(Vector3 point)
    {
        Vector2 temp = new Vector2();
        temp.x = (point.x - _UpLeftTable.position.x) / (_DownRightTable.position.x - _UpLeftTable.position.x) * (_DownRightCanvas.position.x - _UpLeftCanvas.position.x) + _UpLeftCanvas.position.x;
        temp.y = (point.z - _UpLeftTable.position.z) / (_DownRightTable.position.z - _UpLeftTable.position.z) * (_DownRightCanvas.position.y - _UpLeftCanvas.position.y) + _UpLeftCanvas.position.y;
        return temp;
    }
}
