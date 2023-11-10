using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll() 
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.IespinozaLeenkenGroupContext context = new DL.IespinozaLeenkenGroupContext())
                {
                    var query = context.Empleados.FromSqlRaw($"EmpleadoGetAll").ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.IdEmpleado = item.IdEmpleado;
                            empleado.Nombre = item.Nombre;
                            empleado.ApellidoPaterno = item.ApellidoPaterno;
                            empleado.ApellidoMaterno = item.ApellidoMaterno;

                            //Inicializar propiedad de navegacion
                            empleado.Estado = new ML.Estado();
                            empleado.Estado.IdEstado = item.IdEstado.Value;
                            empleado.Estado.Nombre = item.EstadoNombre;

                            result.Objects.Add(empleado);
                        }

                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un erros al realizar la consulta "+ex.Message;
                throw;
            }
            return result;
        }

        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.IespinozaLeenkenGroupContext context = new DL.IespinozaLeenkenGroupContext())
                {
                    //context.Database.ExecuteSqlRaw = Add,Update,Delete
                    int query = context.Database.ExecuteSqlRaw($"EmpleadoAdd '{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}',{empleado.Estado.IdEstado}");

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Empleado insertado correctamente";
                    }

                        
                    
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un erros al realizar la consulta " + ex.Message;
                throw;
            }
            return result;
        }

    }
}