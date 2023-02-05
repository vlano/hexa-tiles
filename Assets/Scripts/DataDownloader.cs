using System.Net.Http;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;
using UnityEngine;

public class DataDownloader : MonoBehaviour
{
    private static DataDownloader _instance;
    public static DataDownloader Instance => _instance;
    private void Awake()
    {
        if(_instance != null && _instance != this)
            Destroy(_instance);
        _instance = this;
    }


    public async Task<HexTileGrid> DownloadTiles()
    {
        using (var httpClient = new HttpClient())
        {
            var json = await httpClient.GetStringAsync("https://habticgeneral.blob.core.windows.net/public/dev-cases/hexagonGrid.json");
            return JsonConvert.DeserializeObject<HexTileGrid>(json);
        }
    }
    
}
