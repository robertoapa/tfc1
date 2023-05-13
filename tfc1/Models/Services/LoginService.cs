using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using tfc1.Models.Interfaces;
using tfc1.ViewModels;
namespace tfc1.Models.Services
{
    public class LoginService : ILoginService
    {

        public async Task<List<UsuariosVm>> GetUsuarios()
        {
            List<UsuariosVm> lista = new();
            string conexion = "Data Source= (description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1522)(host=adb.eu-amsterdam-1.oraclecloud.com))(connect_data=(service_name=g13748867b58ab7_tfc1_high.adb.oraclecloud.com))(security=(ssl_server_dn_match=yes)));User Id=ADMIN;Password=Ladrillo2rober;Connect Timeout=600;";
            try
            {

                using (OracleConnection connection = new OracleConnection(conexion))
                {
                    await connection.OpenAsync();
                    using (OracleCommand command = new OracleCommand("select * from usuarios", connection))
                    {
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new UsuariosVm
                                {
                                    IdUsuario = reader.GetInt32(0),
                                    NombreUsuario = reader.GetString(1),
                                    Nombre = reader.GetString(2),
                                    Apellidos = reader.GetString(3),
                                    CorreoElectronico = reader.GetString(4),
                                    contraseña = reader.GetString(5),
                                });
                            }
                        }
                        connection.Close();
                    }
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());  
            }
                return lista;


        }
    }
}
