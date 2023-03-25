﻿namespace OKX.Api.Models.Market;

[JsonConverter(typeof(TypedDataConverter<OkxOracle>))]
public class OkxOracle
{
    [JsonProperty("messages")]
    public IEnumerable<string> Messages { get; set; }

    [JsonProperty("signatures")]
    public IEnumerable<string> Signatures { get; set; }

    [JsonProperty("timestamp"), JsonConverter(typeof(DateTimeConverter))]
    public DateTime Time { get; set; }

    [TypedData]
    // [JsonProperty("prices")]
    public Dictionary<string, decimal> Prices { get; set; } = new Dictionary<string, decimal>();
}
