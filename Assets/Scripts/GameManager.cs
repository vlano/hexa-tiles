using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GridGenerator _generator;
    private async void Start()
    {
        var gridData = await DataDownloader.Instance.DownloadTiles();
        _generator.GenerateGrid(gridData);
    }
}
