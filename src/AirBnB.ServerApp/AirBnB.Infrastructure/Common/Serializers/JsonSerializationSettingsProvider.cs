using AirBnB.Application.Common.Serializers;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Force.DeepCloner;

namespace AirBnB.Infrastructure.Common.Serializers;

public class JsonSerializationSettingsProvider : IJsonSerializationSettingsProvider
{
    private readonly JsonSerializerSettings _jsonSerializerSettings = new()
    {
        Formatting = Formatting.Indented,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        NullValueHandling = NullValueHandling.Ignore
    };

    public JsonSerializerSettings Get(bool clone = false)
    {
        return clone ? _jsonSerializerSettings.DeepClone() : _jsonSerializerSettings;
    }
}