using Grpc.Core;
using System.Threading.Tasks;

namespace GrpcService
{
    public class NumService : Num.NumBase
    {
        public override async Task GetNums(UserNameRequest request,
            IServerStreamWriter<HelloNumReply> responseStream, ServerCallContext context)
        {
            for (int counter = 1; counter <= 20; counter++)
            {
                await Task.Delay(1000);
                HelloNumReply helloNumReply = new()
                {
                    Message = $"{request.FirstName} {request.LastName} {counter}"
                };
                await responseStream.WriteAsync(helloNumReply);
            }
        }
    }
}
