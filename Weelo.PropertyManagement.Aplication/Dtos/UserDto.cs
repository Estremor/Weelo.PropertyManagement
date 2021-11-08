namespace Weelo.PropertyManagement.Aplication.Dtos
{
    /// <summary>
    /// Encapsula los UserName y token para poder realizar consumo de las apis
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Nombre de usuaio
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Token de autenticación
        /// </summary>
        public string Token { get; set; }
    }
}
