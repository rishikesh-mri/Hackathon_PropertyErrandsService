using System.Text;
using System.Text.Json;
using DotPulsar;
using DotPulsar.Extensions;
using PropertyErrandsService.Services;

var client = PulsarClient.Builder().Build();

var propertyConsumer = client.NewConsumer().SubscriptionName("pes").Topic("persistent://pes/pes/request").Create();
var resultProducer = client.NewProducer().Topic("persistent://pes/pes/response").Create();

var propSvc = new PropertyService();

await foreach (var item in propertyConsumer.Messages())
{
    var propertyName = Encoding.ASCII.GetString(item.Data);

    var property = await propSvc.GetPropertyByNameAsync(propertyName);
    if (property == null) {
        await resultProducer.Send(Encoding.ASCII.GetBytes([]));
        await propertyConsumer.Acknowledge(item);
        continue;
    }
    var json = JsonSerializer.Serialize(property);
    await resultProducer.Send(Encoding.ASCII.GetBytes(json));

    await propertyConsumer.Acknowledge(item);
}

