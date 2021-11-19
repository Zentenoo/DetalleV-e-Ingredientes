using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    class DetalleVentaAD
    {
        public void CrearDetalleVenta (DetalleVentaEntidad detalleVenta)
        {
            using (SqlConnection conn = new SqlConnection(ConexionSQL.ObtenerCadenaConexion()))
            {
                conn.Open();

                string sqlDetalleV = @"INSERT INTO tblDetalleVenta(lIdVenta,lCantidad_Platos2,
                                         lPrecio_Subtotal, lPrecio_Total, 
                                         sDescripcionV) VALUES (@lIdVenta, @)lDescuento, 
                                         @lCantidad_Platos2, @lPrecio_Subtotal, @lPrecio_Total
                                         @sDescripcionV) SELECT SCOPE_IDENTITY()";

                using (SqlCommand cmd= new SqlCommand(sqlDetalleV,conn))
                {
                    cmd.Parameters.AddWithValue("@lIdVenta", detalleVenta.lIdVenta);
                    cmd.Parameters.AddWithValue("@lCantidad_Platos2", detalleVenta.lCantidad_Platos2 );
                    cmd.Parameters.AddWithValue("@lPrecio_Subtotal", detalleVenta.lPrecio_Subtotal);
                    cmd.Parameters.AddWithValue("@lPrecio_Total",detalleVenta.lPrecio_Total);
                    cmd.Parameters.AddWithValue("@sDescripcionV",detalleVenta.sDescripcionV);

                    detalleVenta.lIdVenta = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string sqlLineaDetalle = @"INSERT INTO "
            }
        }
    }
}
