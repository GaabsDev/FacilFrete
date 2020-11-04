using System.Net;

namespace EasyFreteApp.Presentation.UI.ViewModels
{
    public class ResponseViewModel
    {
        public ResponseViewModel()
        {
            HttpStatusCode = HttpStatusCode.OK;
        }

        public ResponseViewModel(object data) : this() => Data = data;

        public ResponseViewModel(object data, int count) : this(data) => Count = count;

        public ResponseViewModel(string errorMessage) => ErrorMessage = errorMessage;

        public ResponseViewModel(object data, HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
            Data = data;
        }

        public ResponseViewModel(object data, string errorMessage, HttpStatusCode httpStatusCode)
        {
            Data = data;
            ErrorMessage = errorMessage;
            HttpStatusCode = httpStatusCode;
        }

        public ResponseViewModel(string errorMessage, HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
            ErrorMessage = errorMessage;
        }

        public HttpStatusCode HttpStatusCode { get; set; }

        public object Data { get; set; }

        public int Count { get; set; }

        public string ErrorMessage { get; set; }

    }
}
