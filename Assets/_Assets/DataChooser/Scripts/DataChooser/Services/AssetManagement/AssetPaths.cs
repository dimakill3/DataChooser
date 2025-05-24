namespace _Assets.DataChooser.Scripts.DataChooser.Services.AssetManagement
{
    public static class AssetPaths
    {
        public static string GetDataCollectionPath(string collectionTypeName) =>
            $"Data/{collectionTypeName}/Collection";
        
        public static string GetInputDataPath(string inputTypeName) =>
            $"Data/InputData/{inputTypeName}";
    }
}