using System.Net;

namespace Core.Models.Base
{
    public class CommonResponse<T>
    {
        public HttpStatusCode Status;

        public string Content;

        public T Body;
    }
}
