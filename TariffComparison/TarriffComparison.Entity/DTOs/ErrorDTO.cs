namespace TarriffComparison.Entity.DTOs
{
    /// <summary>
    /// ErrorDTO useed for error handling
    /// </summary>
    public class ErrorDTO
    {
        public ErrorDTO(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }

        /// <summary>
        /// status code from http request
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// exception message
        /// </summary>
        public string Message { get; set; }
    }
}
