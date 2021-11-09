namespace Weelo.PropertyManagement.Domain.Base.Enum
{
    /// <summary>
    /// Tipo de provedores Sql soportados
    /// </summary>
    public enum SupportedProvider
    {
        /// <summary>
        /// Motor de bases de datos Microsoft Sql Server
        /// </summary>
        SqlServer,
    }

    public enum RequestResultType
    {
        ErrorResul = 1,
        SuccessResult = 2,
        AlreadyExistObjectResult = 3,
    }
}
