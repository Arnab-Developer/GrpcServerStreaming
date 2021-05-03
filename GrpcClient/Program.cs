using Grpc.Core;
using Grpc.Net.Client;
using GrpcService;
using System;

AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5002");
Num.NumClient client = new(channel);
UserNameRequest request = new()
{
    FirstName = "Jon",
    LastName = "Doe"
};
using AsyncServerStreamingCall<HelloNumReply> call = client.GetNums(request);
await foreach (HelloNumReply reply in call.ResponseStream.ReadAllAsync())
{
    Console.WriteLine(reply.Message);
}
Console.ReadKey(true);