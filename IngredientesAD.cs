using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace CapaAccesoDatos
{
    class IngredientesAD
    {
        /// <summary>
        /// Busca Ingredientes por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IngredientesEntidad BuscarPorId(int id)
        {
            IngredientesEntidad ingrediente = null;
            using (SqlConnection conn = new SqlConnection(ConexionSQL.ObtenerCadenaConexion()))
            {
                conn.Open();

                string sql = @"SELECT lIdIngrediente, lIdComida, sNombreIngr 
                                FROM tblIngredientes 
                                WHERE lIdIngrediente = @lIdIngrediente";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("lIdIngrediente", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ingrediente = CargarIngredientes(reader);
                }
            }

            return ingrediente;
        }

        /// <summary>
        /// Auxiliar
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private IngredientesEntidad CargarIngredientes(IDataReader reader)
        {
            IngredientesEntidad ingrediente = new IngredientesEntidad();

            ingrediente.lIdIngrediente = Convert.ToInt32(reader["lIdIngrediente"]);
            ingrediente.sNombreIngr = Convert.ToString(reader["sNombreIngr"]);
            ingrediente.lIdComida = Convert.ToInt32(reader["lIdComida"]);


            return ingrediente;
        }
    }
}