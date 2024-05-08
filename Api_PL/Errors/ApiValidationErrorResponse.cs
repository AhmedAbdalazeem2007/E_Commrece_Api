namespace Api_PL.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; set; } 
        public ApiValidationErrorResponse() : base()
        {
            Errors = new List<string>();
        }
    }
}
