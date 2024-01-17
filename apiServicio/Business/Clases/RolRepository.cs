using apiServicio.Business.Contracts;
using Microsoft.Extensions.Configuration;
using apiServicio.Models;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiServicio.Business.Clases
{
    public class RolRepository: IRolRepository
    {
        private readonly string conect;

        public SqlDbType SqlDbtype { get; private set; }
        public ParameterDirection Direction { get; private set; }

        public RolRepository(IConfiguration _con)
        {
            conect = _con.GetConnectionString("conBase");
        }
        public async Task<List<Rol>> GetList()
        {
            List<Rol> list = new List<Rol>();
            Rol l;
            using (SqlConnection con=new SqlConnection(conect))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from Rol;", con);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        l=new Rol();
                        l.Id = Convert.ToInt32(reader["Id"]);
                        l.NombreRol = Convert.ToString(reader["NombreRol"]);
                        list.Add(l);
                    }
                }
            }
            return list;
        }
        public async Task<Rol> AgregarActualiza(Rol l, string t)
        {
            using (SqlConnection con= new SqlConnection (conect))
            {
                string cadena = " ";
                if (t== "c")
                {
                    cadena = "set @I= (select is null (max(Id),0)+1 from Rol" + "insert into Rol (NombreRol) values (@NombreRol)";
                    
                }   
                if (t== "u")
                {
                    cadena = "update Rol set NombreRol = @NombreRol where Id=@Id";

                }
                using (SqlCommand cmd = new SqlCommand (cadena, con))
                {
                    SqlParameter Result = new SqlParameter("@l", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(Result);
                    cmd.Parameters.AddWithValue("@Id", l.Id);
                    cmd.Parameters.AddWithValue ("@NombreRol", l.NombreRol);
                    await con.OpenAsync ();
                    await cmd.ExecuteNonQueryAsync();
                    if(t=="t")
                    {
                        l.Id = int.Parse(Result.Value.ToString());
                    }
                }
                return l;
            }
        }
    }
}
