using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Colegio
{
   public class AlumnosBL
    {
       public BindingList<Alumno> ListaAlumnos { get; set; }
        public AlumnosBL()
        {
            ListaAlumnos = new BindingList<Alumno>();

            var alumno1 = new Alumno();
            alumno1.Id = 1;
            alumno1.Nombre = "Jose Perez";
            alumno1.Telefono = "99239382";
            alumno1.Direccion = "Col.Florencia";
            alumno1.Grado = "noveno";
            alumno1.Activo = true;

            ListaAlumnos.Add(alumno1);

            var alumno2 = new Alumno();
            alumno2.Id = 2;
            alumno2.Nombre = "Maria Juarez";
            alumno2.Telefono = "99394930";
            alumno2.Direccion = "Bo Barandillas";
            alumno2.Grado = "Octavo";
            alumno2.Activo = true;
            ListaAlumnos.Add(alumno2);

            var alumno3 = new Alumno();
            alumno3.Id = 3;
            alumno3.Nombre = "Lucas Leiva";
            alumno3.Telefono = "93249403";
            alumno3.Direccion = "Bo Guadalup";
            alumno3.Grado = "noveno";
            alumno3.Activo = true;
            ListaAlumnos.Add(alumno3);
        }
        public BindingList<Alumno> ObtenerAlumnos()
        {
            return ListaAlumnos;
        }
        public Resultado GuardarAlumno(Alumno alumno)
        {
            var resultado = Validar(alumno);
            if (resultado.Exitoso== false)
            {
                return resultado;
            }

            if(alumno.Id == 0)
            {
                alumno.Id = ListaAlumnos.Max(item => item.Id) + 1;
              
            }
            resultado.Exitoso = true;
            return resultado;  
        }
        public void AgregarAlumno ()
        {
            var nuevoAlumno = new Alumno();
            ListaAlumnos.Add(nuevoAlumno);
        }
        public bool EliminarAlumno(int id)
        {
            foreach (var alumno in ListaAlumnos)
            {
                if (alumno.Id == id)
                {
                    ListaAlumnos.Remove(alumno);
                    return true;
                }
            }
            return false;
        }

        private Resultado  Validar(Alumno alumno)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(alumno.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese un Nombre";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(alumno.Telefono) == true)
            {
                resultado.Mensaje = "Ingrese un Numero de Telefono";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(alumno.Direccion) == true)
            {
                resultado.Mensaje = "Ingrese una Direccion";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(alumno.Grado) == true)
            {
                resultado.Mensaje = "Ingrese el Grado";
                resultado.Exitoso = false;
            }

            return resultado;
        }
    }
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Grado { get; set; }
        public bool Activo { get; set; }
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }

    }
}
