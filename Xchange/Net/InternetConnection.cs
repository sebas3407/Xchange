using System;
using System.Threading.Tasks;

namespace Xchange.Net
{
    public class InternetConnection
    {
        public async Task<Response> CheckConnection()
        {
            //if (!CrossConnectivity.Current.IsConnected)
            //{
            //    return new Response
            //    {
            //        IsSuccess = false,
            //        Message = "Please turn on your internet settings.",
            //    };
            //}

            //var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
            //    "google.com");
            //if (!isReachable)
            //{
            //    return new Response
            //    {
            //        IsSuccess = false,
            //        Message = "Check you internet connection.",
            //    };
            //}

            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
            };
        }
    }
}
