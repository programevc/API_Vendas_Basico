namespace ApiVendas.Responses
{
    public class ReturnResponse
    {
        public ReturnResponse()
        {
            Code = 200;
            Message = "Sucesso";
        }

        public ReturnResponse(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
