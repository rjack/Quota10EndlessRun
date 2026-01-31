using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private int squareCounter;
    [Tooltip("X -> Squares, Y -> Difficulty Multiplier")]
    [SerializeField] private AnimationCurve difficultyCurve;
    public static float DifficultyMultiplier = 1f;

    private void Awake()
    {
        EntrySquarePoint.OnPlayerEnterOnEntryPoint += IncreaseCounter;
    }

    private void OnDestroy()
    {
        EntrySquarePoint.OnPlayerEnterOnEntryPoint -= IncreaseCounter;
    }

    private void IncreaseCounter()
    {
        squareCounter++;
        difficultyCurve.Evaluate(squareCounter);
    }
}
