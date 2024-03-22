﻿# OKX.Api

A .Net wrapper for the OKX API as described on [OKX](https://www.okx.com/docs-v5/en/), including all features the API provides using clear and readable objects.

**If you think something is broken, something is missing or have any questions, please open an [Issue](https://github.com/burakoner/OKX.Api/issues)**

## Donations
Donations are greatly appreciated and a motivation to keep improving.

**BTC**:  33WbRKqt7wXARVdAJSu1G1x3QnbyPtZ2bH  
**ETH**:  0x65b02db9b67b73f5f1e983ae10796f91ded57b64  
**USDT (TRC-20)**:  TXwqoD7doMESgitfWa8B2gHL7HuweMmNBJ  


## Installation
![Nuget version](https://img.shields.io/nuget/v/OKX.Api.svg)  ![Nuget downloads](https://img.shields.io/nuget/dt/OKX.Api.svg)
Available on [Nuget](https://www.nuget.org/packages/OKX.Api).
```
PM> Install-Package OKX.Api
```
To get started with OKX.Api first you will need to get the library itself. The easiest way to do this is to install the package into your project using  [NuGet](https://www.nuget.org/packages/OKX.Api). Using Visual Studio this can be done in two ways.

### Using the package manager
In Visual Studio right click on your solution and select 'Manage NuGet Packages for solution...'. A screen will appear which initially shows the currently installed packages. In the top bit select 'Browse'. This will let you download net package from the NuGet server. In the search box type 'OKX.Api' and hit enter. The OKX.Api package should come up in the results. After selecting the package you can then on the right hand side select in which projects in your solution the package should install. After you've selected all project you wish to install and use OKX.Api in hit 'Install' and the package will be downloaded and added to you projects.

### Using the package manager console
In Visual Studio in the top menu select 'Tools' -> 'NuGet Package Manager' -> 'Package Manager Console'. This should open up a command line interface. On top of the interface there is a dropdown menu where you can select the Default Project. This is the project that OKX.Api will be installed in. After selecting the correct project type  `Install-Package OKX.Api`  in the command line interface. This should install the latest version of the package in your project.

After doing either of above steps you should now be ready to actually start using OKX.Api.

## Getting started
After installing it's time to actually use it. To get started we have to add the OKX.Api namespace:  `using OKX.Api;`.

OKX.Api provides two clients to interact with the OKX.Api. The  `OKXRestApiClient`  provides all rest API calls. The  `OKXStreamClient` provides functions to interact with the websocket provided by the OKX.Api. Both clients are disposable and as such can be used in a  `using`statement.

## Rest Api Examples

```csharp
var api = new OKXRestApiClient();
api.SetApiCredentials("XXXXXXXX-API-KEY-XXXXXXXX", "XXXXXXXX-API-SECRET-XXXXXXXX", "XXXXXXXX-API-PASSPHRASE-XXXXXXXX");

/* Trading Account Methods (Signed) */
var account_01 = await api.TradingAccount.GetAccountBalanceAsync();
var account_02 = await api.TradingAccount.GetAccountPositionsAsync();
var account_03 = await api.TradingAccount.GetAccountPositionsHistoryAsync();
var account_04 = await api.TradingAccount.GetAccountPositionRiskAsync();
var account_05 = await api.TradingAccount.GetBillHistoryAsync();
var account_06 = await api.TradingAccount.GetBillArchiveAsync();
var account_07 = await api.TradingAccount.GetAccountConfigurationAsync();
var account_08 = await api.TradingAccount.SetAccountPositionModeAsync(OkxPositionMode.LongShortMode);
var account_09 = await api.TradingAccount.GetAccountLeverageAsync("BTC-USD-211008", OkxMarginMode.Isolated);
var account_10 = await api.TradingAccount.SetAccountLeverageAsync(30, null, "BTC-USD-211008", OkxMarginMode.Isolated, OkxPositionSide.Long);
var account_11 = await api.TradingAccount.GetMaximumAmountAsync("BTC-USDT", OkxTradeMode.Isolated);
var account_12 = await api.TradingAccount.GetMaximumAvailableAmountAsync("BTC-USDT", OkxTradeMode.Isolated);
var account_13 = await api.TradingAccount.SetMarginAmountAsync("BTC-USDT", OkxPositionSide.Long, OkxMarginAddReduce.Add, 100.0m);
var account_14 = await api.TradingAccount.GetMaximumLoanAmountAsync("BTC-USDT", OkxMarginMode.Cross);
var account_15 = await api.TradingAccount.GetFeeRatesAsync(OkxInstrumentType.Spot);
var account_16 = await api.TradingAccount.GetFeeRatesAsync(OkxInstrumentType.Futures);
var account_17 = await api.TradingAccount.GetInterestAccruedAsync();
var account_18 = await api.TradingAccount.GetInterestRateAsync();
var account_19 = await api.TradingAccount.SetGreeksAsync(OkxGreeksType.GreeksInCoins);
var account_20 = await api.TradingAccount.GetMaximumWithdrawalsAsync();

/* OrderBookTrading.Trade Methods (Signed) */
var trade_01 = await api.OrderBookTrading.Trade.PlaceOrderAsync("BTC-USDT", OkxTradeMode.Cash, OkxOrderSide.Buy, OkxPositionSide.Long, OkxOrderType.MarketOrder, 0.1m);
var trade_02 = await api.OrderBookTrading.Trade.PlaceMultipleOrdersAsync(new List<OkxOrderPlaceRequest>());
var trade_03 = await api.OrderBookTrading.Trade.CancelOrderAsync("BTC-USDT");
var trade_04 = await api.OrderBookTrading.Trade.CancelMultipleOrdersAsync(new List<OkxOrderCancelRequest>());
var trade_05 = await api.OrderBookTrading.Trade.AmendOrderAsync("BTC-USDT");
var trade_06 = await api.OrderBookTrading.Trade.AmendMultipleOrdersAsync(new List<OkxOrderAmendRequest>());
var trade_07 = await api.OrderBookTrading.Trade.ClosePositionAsync("BTC-USDT", OkxMarginMode.Isolated);
var trade_08 = await api.OrderBookTrading.Trade.GetOrderDetailsAsync("BTC-USDT");
var trade_09 = await api.OrderBookTrading.Trade.GetOrderListAsync();
var trade_10 = await api.OrderBookTrading.Trade.GetOrderHistoryAsync(OkxInstrumentType.Swap);
var trade_11 = await api.OrderBookTrading.Trade.GetOrderArchiveAsync(OkxInstrumentType.Futures);
var trade_12 = await api.OrderBookTrading.Trade.GetTransactionHistoryAsync();
var trade_13 = await api.OrderBookTrading.Trade.GetTransactionArchiveAsync(OkxInstrumentType.Futures);

/* OrderBookTrading.AlgoTrading Methods (Signed) */
var algo_01 = await api.OrderBookTrading.AlgoTrading.PlaceAlgoOrderAsync("BTC-USDT", OkxTradeMode.Isolated, OkxOrderSide.Sell, OkxAlgoOrderType.Conditional);
var algo_02 = await api.OrderBookTrading.AlgoTrading.CancelAlgoOrderAsync(new List<OkxAlgoOrderRequest>());
var algo_03 = await api.OrderBookTrading.AlgoTrading.AmendAlgoOrderAsync("BTC-USDT");
var algo_04 = await api.OrderBookTrading.AlgoTrading.CancelAdvanceAlgoOrderAsync(new List<OkxAlgoOrderRequest>());
var algo_05 = await api.OrderBookTrading.AlgoTrading.GetAlgoOrderDetailsAsync(algoOrderId: 1_000_001);
var algo_06 = await api.OrderBookTrading.AlgoTrading.GetAlgoOrderListAsync(OkxAlgoOrderType.OCO);
var algo_07 = await api.OrderBookTrading.AlgoTrading.GetAlgoOrderHistoryAsync(OkxAlgoOrderType.Conditional);

/* OrderBookTrading.GridTrading Methods (Signed) */
var grid_01 = await api.OrderBookTrading.GridTrading.PlaceAlgoOrderAsync(new OkxGridPlaceOrderRequest
{
    Instrument = "BTC-USDT",
    AlgoOrderType = OkxGridAlgoOrderType.SpotGrid,
    MaximumPrice = 5000,
    MinimumPrice = 400,
    GridNumber = 10,
    GridRunType = OkxGridRunType.Arithmetic,
    QuoteSize = 25,
    TriggerParameters = new List<OkxGridPlaceTriggerParameters>
    {
        new OkxGridPlaceTriggerParameters
        {
            TriggerAction = OkxGridAlgoTriggerAction.Stop,
            TriggerStrategy =  OkxGridAlgoTriggerStrategy.Price,
            TriggerPrice = "1000"
        }
    }
});
var grid_02 = await api.OrderBookTrading.GridTrading.PlaceAlgoOrderAsync(
    instrumentId: "BTC-USDT-SWAP",
    algoOrderType: OkxGridAlgoOrderType.ContractGrid,
    maximumPrice: 5000,
    minimumPrice: 400,
    gridNumber: 10,
    gridRunType: OkxGridRunType.Arithmetic,
    size: 200,
    contractGridDirection: OkxGridContractDirection.Long,
    leverage: 2,
    triggerParameters: new List<OkxGridPlaceTriggerParameters>
    {
        new OkxGridPlaceTriggerParameters
        {
            TriggerAction = OkxGridAlgoTriggerAction.Start,
            TriggerStrategy =  OkxGridAlgoTriggerStrategy.Rsi,
            TimeFrame = OkxGridAlgoTimeFrame.ThirtyMinutes,
            Threshold = "10",
            TriggerCondition = OkxGridAlgoTriggerCondition.Cross,
            TimePeriod = "14"
        },
        new OkxGridPlaceTriggerParameters
        {
            TriggerAction = OkxGridAlgoTriggerAction.Stop,
            TriggerStrategy =  OkxGridAlgoTriggerStrategy.Price,
            TriggerPrice = "1000",
            ContractAlgoStopType = OkxGridContractAlgoStopType.KeepPositions,
        }
    }
);
var grid_03 = await api.OrderBookTrading.GridTrading.AmendAlgoOrderAsync(448965992920907776, "BTC-USDT-SWAP", 1200);
var grid_04 = await api.OrderBookTrading.GridTrading.StopAlgoOrderAsync(448965992920907776, "BTC-USDT", OkxGridAlgoOrderType.SpotGrid, OkxGridSpotAlgoStopType.SellBaseCurrency);
var grid_05 = await api.OrderBookTrading.GridTrading.CloseContractPositionAsync(448965992920907776, true);
var grid_06 = await api.OrderBookTrading.GridTrading.CancelCloseContractPositionAsync(448965992920907776, 570627699870375936);
var grid_07 = await api.OrderBookTrading.GridTrading.TriggerAlgoOrderAsync(448965992920907776);
var grid_08 = await api.OrderBookTrading.GridTrading.GetOpenAlgoOrdersAsync(OkxGridAlgoOrderType.SpotGrid);
var grid_09 = await api.OrderBookTrading.GridTrading.GetAlgoOrdersHistoryAsync(OkxGridAlgoOrderType.SpotGrid);
var grid_10 = await api.OrderBookTrading.GridTrading.GetAlgoOrderAsync(OkxGridAlgoOrderType.SpotGrid, 448965992920907776);
var grid_11 = await api.OrderBookTrading.GridTrading.GetAlgoSubOrdersAsync(OkxGridAlgoOrderType.SpotGrid, 448965992920907776, OkxGridAlgoSubOrderType.Live);
var grid_12 = await api.OrderBookTrading.GridTrading.GetAlgoPositionsAsync(OkxGridAlgoOrderType.ContractGrid, 448965992920907776);
var grid_13 = await api.OrderBookTrading.GridTrading.GetWithdrawIncomeAsync(448965992920907776);
var grid_14 = await api.OrderBookTrading.GridTrading.ComputeMarginBalanceAsync(448965992920907776, OkxMarginAddReduce.Add, 10.0m);
var grid_15 = await api.OrderBookTrading.GridTrading.AdjustMarginBalanceAsync(448965992920907776, OkxMarginAddReduce.Add, 10.0m);
var grid_16 = await api.OrderBookTrading.GridTrading.GetAiParameterAsync( OkxGridAlgoOrderType.SpotGrid, "BTC-USDT");
var grid_17 = await api.OrderBookTrading.GridTrading.ComputeMinimumInvestmentAsync("ETH-USDT",  OkxGridAlgoOrderType.SpotGrid, 5000, 3000, 50, OkxGridRunType.Arithmetic);
var grid_18 = await api.OrderBookTrading.GridTrading.RsiBackTestingAsync("BTC-USDT", OkxGridAlgoTimeFrame.ThreeMinutes, 30, 14);

/* TODO: OrderBookTrading.RecurringBuy Methods (Signed) */

/* OrderBookTrading.CopyTrading Methods (Signed) */
var copy_01 = await api.OrderBookTrading.CopyTrading.GetExistingLeadingPositionsAsync();
var copy_02 = await api.OrderBookTrading.CopyTrading.GetExistingLeadingPositionsHistoryAsync();
var copy_03 = await api.OrderBookTrading.CopyTrading.PlaceLeadingStopOrderAsync(leadingPositionId: 1_000_001);
var copy_04 = await api.OrderBookTrading.CopyTrading.CloseLeadingPositionAsync(leadingPositionId: 1_000_001);
var copy_05 = await api.OrderBookTrading.CopyTrading.GetLeadingInstrumentsAsync();
var copy_06 = await api.OrderBookTrading.CopyTrading.AmendLeadingInstrumentsAsync(new List<string> { "BTC-USDT", "ETH-USDT" });
var copy_07 = await api.OrderBookTrading.CopyTrading.GetProfitSharingDetailsAsync();
var copy_08 = await api.OrderBookTrading.CopyTrading.GetTotalProfitSharingAsync();
var copy_09 = await api.OrderBookTrading.CopyTrading.GetUnrealizedProfitSharingDetailsAsync();

/* OrderBookTrading.MarketData Methods (Unsigned) */
var market_01 = await api.OrderBookTrading.MarketData.GetTickersAsync(OkxInstrumentType.Spot);
var market_02 = await api.OrderBookTrading.MarketData.GetTickerAsync("BTC-USDT");
var market_04 = await api.OrderBookTrading.MarketData.GetOrderBookAsync("BTC-USDT", 40);
var market_05 = await api.OrderBookTrading.MarketData.GetCandlesticksAsync("BTC-USDT", OkxPeriod.OneHour);
var market_06 = await api.OrderBookTrading.MarketData.GetCandlesticksHistoryAsync("BTC-USDT", OkxPeriod.OneHour);
var market_09 = await api.OrderBookTrading.MarketData.GetTradesAsync("BTC-USDT");
var market_10 = await api.OrderBookTrading.MarketData.GetTradesHistoryAsync("BTC-USDT");
var market_11 = await api.OrderBookTrading.MarketData.Get24HourVolumeAsync();

/* BlockTrading Methods (Unsigned) */
var block_01 = await api.BlockTrading.GetBlockTickersAsync(OkxInstrumentType.Spot);
var block_02 = await api.BlockTrading.GetBlockTickersAsync(OkxInstrumentType.Futures);
var block_03 = await api.BlockTrading.GetBlockTickersAsync(OkxInstrumentType.Option);
var block_04 = await api.BlockTrading.GetBlockTickersAsync(OkxInstrumentType.Swap);
var block_05 = await api.BlockTrading.GetBlockTickerAsync("BTC-USDT");
var block_06 = await api.BlockTrading.GetBlockTradesAsync("BTC-USDT");

/* TODO: SpreadTrading Methods (Signed) */

/* PublicData Methods (Unsigned) */
var public_01 = await api.PublicData.GetInstrumentsAsync(OkxInstrumentType.Spot);
var public_02 = await api.PublicData.GetInstrumentsAsync(OkxInstrumentType.Margin);
var public_03 = await api.PublicData.GetInstrumentsAsync(OkxInstrumentType.Swap, instrumentId: "BTC-USDT-SWAP");
var public_04 = await api.PublicData.GetInstrumentsAsync(OkxInstrumentType.Futures);
var public_05 = await api.PublicData.GetInstrumentsAsync(OkxInstrumentType.Option, "USD");
var public_06 = await api.PublicData.GetInstrumentsAsync(OkxInstrumentType.Swap, instrumentId: "BTC-USDT-SWAP", signed: true);
var public_07 = await api.PublicData.GetDeliveryExerciseHistoryAsync(OkxInstrumentType.Futures, "BTC-USD");
var public_08 = await api.PublicData.GetDeliveryExerciseHistoryAsync(OkxInstrumentType.Option, "BTC-USD");
var public_09 = await api.PublicData.GetOpenInterestsAsync(OkxInstrumentType.Futures);
var public_10 = await api.PublicData.GetOpenInterestsAsync(OkxInstrumentType.Option, "BTC-USD");
var public_11 = await api.PublicData.GetOpenInterestsAsync(OkxInstrumentType.Swap, "BTC-USD");
var public_12 = await api.PublicData.GetFundingRatesAsync("BTC-USD-SWAP");
var public_13 = await api.PublicData.GetFundingRateHistoryAsync("BTC-USD-SWAP");
var public_14 = await api.PublicData.GetLimitPriceAsync("BTC-USD-SWAP");
var public_15 = await api.PublicData.GetOptionMarketDataAsync("BTC-USD");
var public_16 = await api.PublicData.GetEstimatedPriceAsync("BTC-USD-211004-41000-C");
var public_17 = await api.PublicData.GetDiscountInfoAsync();
var public_18 = await api.PublicData.GetServerTimeAsync();
var public_19 = await api.PublicData.GetMarkPricesAsync(OkxInstrumentType.Futures);
var public_20 = await api.PublicData.GetPositionTiersAsync(OkxInstrumentType.Futures, OkxMarginMode.Isolated, "BTC-USD");
var public_21 = await api.PublicData.GetInterestRatesAsync();
var public_22 = await api.PublicData.GetVIPInterestRatesAsync();
var public_23 = await api.PublicData.GetUnderlyingAsync(OkxInstrumentType.Futures);
var public_24 = await api.PublicData.GetUnderlyingAsync(OkxInstrumentType.Option);
var public_25 = await api.PublicData.GetUnderlyingAsync(OkxInstrumentType.Swap);
var public_26 = await api.PublicData.GetInsuranceFundAsync(OkxInstrumentType.Margin, currency: "BTC");
var public_27 = await api.PublicData.UnitConvertAsync("BTC-USD-SWAP", price: 35000, size: 0.888m);
var public_28 = await api.PublicData.GetIndexTickersAsync(instrumentId: "BTC-USDT");
var public_29 = await api.PublicData.GetIndexCandlesticksAsync("BTC-USDT", OkxPeriod.OneHour);
var public_30 = await api.PublicData.GetMarkPriceCandlesticksAsync("BTC-USDT", OkxPeriod.OneHour);
var public_31 = await api.PublicData.GetOracleAsync();
var public_32 = await api.PublicData.GetExchangeRatesAsync();
var public_33 = await api.PublicData.GetIndexComponentsAsync("BTC-USDT");

/* TradingStatistics Methods (Unsigned) */
var rubik_01 = await api.TradingStatistics.GetSupportCoinAsync();
var rubik_02 = await api.TradingStatistics.GetTakerVolumeAsync("BTC", OkxInstrumentType.Spot);
var rubik_03 = await api.TradingStatistics.GetMarginLendingRatioAsync("BTC", OkxPeriod.OneDay);
var rubik_04 = await api.TradingStatistics.GetLongShortRatioAsync("BTC", OkxPeriod.OneDay);
var rubik_05 = await api.TradingStatistics.GetContractSummaryAsync("BTC", OkxPeriod.OneDay);
var rubik_06 = await api.TradingStatistics.GetOptionsSummaryAsync("BTC", OkxPeriod.OneDay);
var rubik_07 = await api.TradingStatistics.GetPutCallRatioAsync("BTC", OkxPeriod.OneDay);
var rubik_08 = await api.TradingStatistics.GetInterestVolumeExpiryAsync("BTC", OkxPeriod.OneDay);
var rubik_09 = await api.TradingStatistics.GetInterestVolumeStrikeAsync("BTC", "20210623", OkxPeriod.OneDay);
var rubik_10 = await api.TradingStatistics.GetTakerFlowAsync("BTC", OkxPeriod.OneDay);

/* FundingAccount Methods (Signed) */
var funding_01 = await api.FundingAccount.GetCurrenciesAsync();
var funding_02 = await api.FundingAccount.GetFundingBalanceAsync();
var funding_03 = await api.FundingAccount.FundTransferAsync("BTC", 0.5m, OkxTransferType.TransferWithinAccount, OkxAccount.Funding, OkxAccount.Trading);
var funding_04 = await api.FundingAccount.GetFundingBillDetailsAsync("BTC");
var funding_05 = await api.FundingAccount.GetLightningDepositsAsync("BTC", 0.001m);
var funding_06 = await api.FundingAccount.GetDepositAddressAsync("BTC");
var funding_07 = await api.FundingAccount.GetDepositAddressAsync("USDT");
var funding_08 = await api.FundingAccount.GetDepositHistoryAsync("USDT");
var funding_09 = await api.FundingAccount.WithdrawAsync("USDT", 100.0m, OkxWithdrawalDestination.DigitalCurrencyAddress, "toAddress", 1.0m, "USDT-TRC20");
var funding_10 = await api.FundingAccount.GetLightningWithdrawalsAsync("BTC", "invoice", "password");
var funding_11 = await api.FundingAccount.CancelWithdrawalAsync(1_000_001);
var funding_12 = await api.FundingAccount.GetWithdrawalHistoryAsync("USDT");

/* SubAccount Methods (Signed) */
var subaccount_01 = await api.SubAccount.GetSubAccountsAsync();
var subaccount_02 = await api.SubAccount.ResetSubAccountApiKeyAsync("subAccountName", "apiKey", "apiLabel", true, true, "");
var subaccount_03 = await api.SubAccount.GetSubAccountTradingBalancesAsync("subAccountName");
var subaccount_04 = await api.SubAccount.GetSubAccountFundingBalancesAsync("subAccountName");
var subaccount_05 = await api.SubAccount.GetSubAccountBillsAsync();
var subaccount_06 = await api.SubAccount.TransferBetweenSubAccountsAsync("BTC", 0.5m, OkxAccount.Funding, OkxAccount.Trading, "fromSubAccountName", "toSubAccountName");

/* TODO: FinancialProduct.Earn Methods (Signed) */
/* TODO: FinancialProduct.Savings Methods (Signed) */
```
            
## Websocket Api Examples
The OKX.Api socket client provides several socket endpoint to which can be subscribed.

```csharp
/* OKX Socket Client */
var ws = new OKXWebSocketApiClient();
ws.SetApiCredentials("XXXXXXXX-API-KEY-XXXXXXXX", "XXXXXXXX-API-SECRET-XXXXXXXX", "XXXXXXXX-API-PASSPHRASE-XXXXXXXX");

/* TradingAccount Updates (Private) */
await ws.TradingAccount.SubscribeToAccountUpdatesAsync((data) =>
{
    if (data != null)
    {
        // ... Your logic here
    }
});
await ws.TradingAccount.SubscribeToPositionUpdatesAsync((data) =>
{
    if (data != null)
    {
        // ... Your logic here
    }
}, OkxInstrumentType.Futures, "INSTRUMENT-FAMILY", "INSTRUMENT-ID");
await ws.TradingAccount.SubscribeToBalanceAndPositionUpdatesAsync((data) =>
{
    if (data != null)
    {
        // ... Your logic here
    }
});

/* OrderBookTrading.Trade Updates (Private) */
await ws.OrderBookTrading.Trade.SubscribeToOrderUpdatesAsync((data) =>
{
    if (data != null)
    {
        // ... Your logic here
    }
}, OkxInstrumentType.Futures, "INSTRUMENT-FAMILY", "INSTRUMENT-ID");

/* OrderBookTrading.AlgoTrading Updates (Private) */
await ws.OrderBookTrading.AlgoTrading.SubscribeToAlgoOrderUpdatesAsync((data) =>
{
    if (data != null)
    {
        // ... Your logic here
    }
}, OkxInstrumentType.Futures, "INSTRUMENT-FAMILY", "INSTRUMENT-ID");
await ws.OrderBookTrading.AlgoTrading.SubscribeToAdvanceAlgoOrderUpdatesAsync((data) =>
{
    if (data != null)
    {
        // ... Your logic here
    }
}, OkxInstrumentType.Futures, "INSTRUMENT-FAMILY", "INSTRUMENT-ID");

/* OrderBookTrading.MarketData Updates (Public) */
var sample_pairs = new List<string> { "BTC-USDT", "LTC-USDT", "ETH-USDT", "XRP-USDT", "BCH-USDT", "EOS-USDT", "OKB-USDT", "ETC-USDT", "TRX-USDT", "BSV-USDT", "DASH-USDT", "NEO-USDT", "QTUM-USDT", "XLM-USDT", "ADA-USDT", "AE-USDT", "BLOC-USDT", "EGT-USDT", "IOTA-USDT", "SC-USDT", "WXT-USDT", "ZEC-USDT", };
var subs = new List<WebSocketUpdateSubscription>();
foreach (var pair in sample_pairs)
{
    var subscription = await ws.OrderBookTrading.MarketData.SubscribeToTickersAsync((data) =>
    {
        if (data != null)
        {
            // ... Your logic here
            Console.WriteLine($"Ticker {data.Instrument} Ask:{data.AskPrice} Bid:{data.BidPrice}");
        }
    }, pair);
    subs.Add(subscription.Data);
}
foreach (var pair in sample_pairs)
{
    await ws.OrderBookTrading.MarketData.SubscribeToCandlesticksAsync((data) =>
    {
        if (data != null)
        {
            // ... Your logic here
        }
    }, pair, OkxPeriod.FiveMinutes);
}
foreach (var pair in sample_pairs)
{
    await ws.OrderBookTrading.MarketData.SubscribeToTradesAsync((data) =>
    {
        if (data != null)
        {
            // ... Your logic here
        }
    }, pair);
}
foreach (var pair in sample_pairs)
{
    await ws.OrderBookTrading.MarketData.SubscribeToOrderBookAsync((data) =>
    {
        if (data != null && data.Asks != null && data.Asks.Count() > 0 && data.Bids != null && data.Bids.Count() > 0)
        {
            // ... Your logic here
        }
    }, pair, OkxOrderBookType.OrderBook);
}

/* Unsubscribe */
foreach (var sub in subs)
{
    _ = ws.UnsubscribeAsync(sub);
}

/* TODO: BlockTrading Updates (Private) */
/* TODO: SpreadTrading Updates (Private) */

/* PublicData Updates (Public) */
await ws.PublicData.SubscribeToInstrumentsAsync((data) =>
{
    if (data != null)
    {
        // ... Your logic here
        Console.WriteLine($"Instrument {data.Instrument} BaseCurrency:{data.BaseCurrency}");
    }
}, OkxInstrumentType.Spot);
foreach (var pair in sample_pairs)
{
    await ws.PublicData.SubscribeToOpenInterestsAsync((data) =>
    {
        if (data != null)
        {
            // ... Your logic here
        }
    }, pair);
}
foreach (var pair in sample_pairs)
{
    await ws.PublicData.SubscribeToFundingRatesAsync((data) =>
    {
        if (data != null)
        {
            // ... Your logic here
        }
    }, pair);
}
foreach (var pair in sample_pairs)
{
    await ws.PublicData.SubscribeToPriceLimitAsync((data) =>
    {
        if (data != null)
        {
            // ... Your logic here
        }
    }, pair);
}
await ws.PublicData.SubscribeToOptionSummaryAsync((data) =>
{
    if (data != null)
    {
        // ... Your logic here
    }
}, "USD");
foreach (var pair in sample_pairs)
{
    await ws.PublicData.SubscribeToEstimatedPriceAsync((data) =>
    {
        if (data != null)
        {
            // ... Your logic here
        }
    }, OkxInstrumentType.Option);
}
foreach (var pair in sample_pairs)
{
    await ws.PublicData.SubscribeToMarkPriceAsync((data) =>
    {
        if (data != null)
        {
            // ... Your logic here
        }
    }, pair);
}
foreach (var pair in sample_pairs)
{
    await ws.PublicData.SubscribeToIndexTickersAsync((data) =>
    {
        if (data != null)
        {
            // ... Your logic here
        }
    }, pair);
}
foreach (var pair in sample_pairs)
{
    await ws.PublicData.SubscribeToMarkPriceCandlesticksAsync((data) =>
    {
        if (data != null)
        {
            // ... Your logic here
        }
    }, pair, OkxPeriod.FiveMinutes);
}
foreach (var pair in sample_pairs)
{
    await ws.PublicData.SubscribeToIndexCandlesticksAsync((data) =>
    {
        if (data != null)
        {
            // ... Your logic here
        }
    }, pair, OkxPeriod.FiveMinutes);
}

/* TODO: TradingStatistics Updates (Private) */
/* TODO: FundingAccount Updates (Private) */
/* TODO: SubAccount Updates (Private) */
/* TODO: FinancialProduct.Earn (Private) */
/* TODO: FinancialProduct.Savings (Private) */
            
/* Status Updates (Public) */
await ws.Status.SubscribeToSystemStatusAsync((data) =>
{
    if (data != null)
    {
        // ... Your logic here
    }
});
```

## Release Notes
* Version 1.3.0 - 06 Aug 2023
    * ApiSharp version updated to 1.5.0
    * Both Rest and Websocket Api client hierarchies synced with OKX Api Documentation
    * OKXStreamClient renamed to OKXWebSocketApiClient and methods moved to seperate clients according to OKX Api Documentation
    * Some method and parameter names changed
    * Timestamp conversion algorithm changed. You can now reach both timestamp and time properties
    * Added Copy Trading Section
    * Added OrderBookTrading.AlgoTrading.AmendAlgoOrderAsync (api/v5/trade/amend-algos)
    * Added OrderBookTrading.AlgoTrading.GetAlgoOrderDetailsAsync (api/v5/trade/order-algo)
    * Moved some MarketData methods to PublicData section: GetIndexCandlesticksAsync, GetMarkPriceCandlesticksAsync, GetIndexTickersAsync, GetOracleAsync, GetIndexComponentsAsync
    * Moved some MarketData methods to BlockTrading section: GetBlockTickersAsync, GetBlockTickerAsync, GetBlockTradesAsync
    * Removed some Funding methods: GetSavingBalancesAsync, SavingPurchaseRedemptionAsync
    * Fixed issue https://github.com/burakoner/OKX.Api/issues/20
    * Fixed issue https://github.com/burakoner/OKX.Api/issues/29
    * Fixed issue https://github.com/burakoner/OKX.Api/issues/34

* Version 1.2.4 - 05 Aug 2023
    * Multiple subscription to index candle instrument name issue solved
    as described at https://github.com/burakoner/OKX.Api/issues/30 and solved at https://github.com/burakoner/OKX.Api/pull/31

* Version 1.2.3 - 03 Aug 2023
    * ApiSharp version updated to 1.4.1

* Version 1.2.2 - 28 Jul 2023
    * Merged pull request https://github.com/burakoner/OKX.Api/pull/28

* Version 1.2.1 - 28 Jul 2023
    * Synced with OKX Api 2023-07-26 version
    * Added some other missing documentation symbols
    * Merged pull request https://github.com/burakoner/OKX.Api/pull/25
    * Merged pull request https://github.com/burakoner/OKX.Api/pull/26
    * Merged pull request https://github.com/burakoner/OKX.Api/pull/27

* Version 1.2.0 - 27 Jul 2023
    * Added documentation symbols
    * Synced with OKX Api 2023-06-28 version
    * Fixed issue at https://github.com/burakoner/OKX.Api/issues/21
    * Fixed issue at https://github.com/burakoner/OKX.Api/issues/21
    * Merged pull request https://github.com/burakoner/OKX.Api/pull/23
    * Merged pull request https://github.com/burakoner/OKX.Api/pull/24

* Version 1.1.7 - 26 Jun 2023
    * It's possible to subscribe multiple symbols at once on WebSocket
    * Fixed issue at https://github.com/burakoner/OKX.Api/issues/16

* Version 1.1.6 - 26 Jun 2023
    * Updated All Methods and Models, synced with OKX Api 2023-06-20 version
    * OKXStreamClient has some parameter and parameter order changes
    * Fixed issue at https://github.com/burakoner/OKX.Api/issues/18
    * Fixed some typos

* Version 1.1.5 - 25 Jun 2023
    * Added Grid Trading section endpoints
    * ApiSharp updated to v1.3.6
    * Fixed issue at https://github.com/burakoner/OKX.Api/issues/11

* Version 1.1.0 - 07 May 2023
    * Updated All Methods and Models, synced with OKX Api 2023-04-27 version

* Version 1.0.6 - 06 May 2023
    * Updated WithdrawAsync Method (https://github.com/burakoner/OKEx.Net/issues/97)
    * Updated GetInstrumentsAsync Method (https://github.com/burakoner/OKX.Api/issues/7)

* Version 1.0.0 - 25 Mar 2023
	* First Release
