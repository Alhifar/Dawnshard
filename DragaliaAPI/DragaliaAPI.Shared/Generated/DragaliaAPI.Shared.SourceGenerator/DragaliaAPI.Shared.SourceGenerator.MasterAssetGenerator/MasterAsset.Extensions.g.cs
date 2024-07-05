﻿// <auto-generated/>

#nullable enable

namespace DragaliaAPI.Shared.MasterAsset;

public static partial class MasterAsset
{
    private static async Task<List<TItem>> LoadFile<TItem>(string msgpackPath)
    {
        string path = Path.Join(
           global::System.IO.Path.GetDirectoryName(global::System.Reflection.Assembly.GetExecutingAssembly().Location),
            "Resources",
            msgpackPath
        );
    
        await using FileStream fs = File.OpenRead(path);
    
        return await global::MessagePack.MessagePackSerializer.DeserializeAsync<List<TItem>>(
            fs,
            MasterAssetMessagePackOptions.Instance
        ) ?? throw new global::MessagePack.MessagePackSerializationException($"Deserialized MasterAsset extension for {path} was null");
    }
    
    public static async global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::DragaliaAPI.Shared.MasterAsset.Models.Event.EventData>> LoadEventDataExtension(global::Microsoft.FeatureManagement.IFeatureManager featureManager)
    {
        global::System.Collections.Generic.List<global::DragaliaAPI.Shared.MasterAsset.Models.Event.EventData> extendedData = [];
        
        extendedData.AddRange(await LoadFile<global::DragaliaAPI.Shared.MasterAsset.Models.Event.EventData>("Event/EventData.fixes.msgpack"));

        return extendedData;
    }
}
