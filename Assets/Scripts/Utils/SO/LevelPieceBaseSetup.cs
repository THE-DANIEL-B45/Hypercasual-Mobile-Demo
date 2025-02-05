using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBaseSetup : ScriptableObject
{
    public ArtManager.ArtType artType;

    [Header("Pieces")]
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPiecesEnd;

    public int piecesStartNumber = 3;
    public int piecesNumber = 5;
    public int piecesEndNumber = 1;
}
