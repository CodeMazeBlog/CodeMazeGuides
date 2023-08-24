using System.Diagnostics.Metrics;

namespace Metrics.NET;

public class ComputerComponentsMetrics
{
	private readonly Meter _meter;

	private Counter<int> TotalOrdersCounter { get; }
	private Histogram<decimal> OrdersPriceHistogram { get; }
	private ObservableGauge<int> TotalComputerComponents { get; }
	private int _totalComponents = 0;

	public ComputerComponentsMetrics()
	{
		_meter = new("ComputerComponents");

		TotalOrdersCounter = _meter.CreateCounter<int>("total-orders", "Orders");
		OrdersPriceHistogram = _meter.CreateHistogram<decimal>("orders-price", "Euros", "Distribution of orders price");
		TotalComputerComponents = _meter.CreateObservableGauge<int>("total-computer-components", () => new[] { new Measurement<int>(_totalComponents) } );
    }

	public void AddOrderComplete(int orderId) => TotalOrdersCounter.Add(1, KeyValuePair.Create<string, object?>("OrderId", orderId));

	public void RecordOrderPrice(decimal orderPrice) => OrdersPriceHistogram.Record(orderPrice);

	public void AddComputerComponet() => _totalComponents++;

}
