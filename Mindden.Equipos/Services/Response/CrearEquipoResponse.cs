namespace Mindden.Equipos.Services.Response
{
    public class CrearEquipoResponse : BaseResponse
    {
        public CrearEquipoResponse(StatusEnum status) : base(status)
        {
            this.Id = 0;
        }

        public CrearEquipoResponse(StatusEnum status, string errorMessage) : base(status, errorMessage)
        {
            this.Id = 0;
        }

        public CrearEquipoResponse(StatusEnum status, int id) : base(status)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}