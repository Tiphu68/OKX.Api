﻿using OKX.Api.Trade.Enums;

namespace OKX.Api.Trade.Converters;

internal class OkxOrderTypeConverter : BaseConverter<OkxOrderType>
{
    public OkxOrderTypeConverter() : this(true) { }
    public OkxOrderTypeConverter(bool quotes) : base(quotes) { }

    protected override List<KeyValuePair<OkxOrderType, string>> Mapping => new List<KeyValuePair<OkxOrderType, string>>
    {
        new KeyValuePair<OkxOrderType, string>(OkxOrderType.MarketOrder, "market"),
        new KeyValuePair<OkxOrderType, string>(OkxOrderType.LimitOrder, "limit"),
        new KeyValuePair<OkxOrderType, string>(OkxOrderType.PostOnly, "post_only"),
        new KeyValuePair<OkxOrderType, string>(OkxOrderType.FillOrKill, "fok"),
        new KeyValuePair<OkxOrderType, string>(OkxOrderType.ImmediateOrCancel, "ioc"),
        new KeyValuePair<OkxOrderType, string>(OkxOrderType.OptimalLimitOrder, "optimal_limit_ioc"),
        new KeyValuePair<OkxOrderType, string>(OkxOrderType.MarketMakerProtection, "mmp"),
        new KeyValuePair<OkxOrderType, string>(OkxOrderType.MarektMakerProtectionAndPostOnly, "mmp_and_post_only"),
    };
}