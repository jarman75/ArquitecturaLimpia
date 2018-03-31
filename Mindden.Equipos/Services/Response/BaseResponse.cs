namespace Mindden.Equipos.Services.Response
{
    public class BaseResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EquipoServiceResponse"/> class.
        /// </summary>
        public BaseResponse(StatusEnum status, string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.Status = status;
        }
        public BaseResponse(StatusEnum status)
        {
            this.ErrorMessage = string.Empty;
            this.Status = status;
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public StatusEnum Status { get; private set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; private set; }
    }
}