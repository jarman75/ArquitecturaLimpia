namespace Mindden.Equipos.Application.Response
{
    public enum StatusEnum
    {
        /// <summary>
        /// The un known error
        /// </summary>
        UnKnownError = 0,
        
        /// <summary>
        /// The correct operation
        /// </summary>
        CorrectOperation = 1,
        
        /// <summary>
        /// The operation error
        /// </summary>
        OperationError = 2,
        
        /// <summary>
        /// The validation error
        /// </summary>
        ValidationError = 3,
        
        /// <summary>
        /// The not processed operation
        /// </summary>
        NotProcessedOperation = 4,

        /// <summary>
        /// The null excepcion
        /// </summary>
        NullExcepcion = 5,
        
    }
}