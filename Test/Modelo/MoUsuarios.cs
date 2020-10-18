using System;

namespace Test.Modelo
{
    public class MoUsuarios
    {
        public string Id { set; get; } = string.Empty;
        public string Email { set; get; } = string.Empty;
        public string Contrasenia { set; get; } = string.Empty;
        public string Nombre { set; get; } = string.Empty;
        public string Apellido { set; get; } = string.Empty;
        public decimal Saldo { set; get; } = 0;
        public string NumeroTelefono { set; get; } = string.Empty;
        public int Tipo { set; get; } = 0;
        public bool Estatus { set; get; } = false;
        public DateTime UltInicioSesion { set; get; } = new DateTime(1900, 01, 01);
        public int Idioma { set; get; } = 0;
        public string IdEmpresa { set; get; } = string.Empty;
        public string CtrlIdUsuario { set; get; } = string.Empty;
        public string CtrlDireccionIp { set; get; } = string.Empty;
        public string CtrlDireccionWeb { set; get; } = string.Empty;
        public DateTime CtrlCreado { set; get; } = new DateTime(1900, 01, 01);
        public DateTime CtrlModificado { set; get; } = new DateTime(1900, 01, 01);
    }
}
