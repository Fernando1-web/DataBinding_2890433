using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Specialized;

namespace DataBinding_2890433
{
    //La clase Alumnos hereda propiedades de INotifyPropertyChanged por medio del using System.ComponentModel
    public class Alumno : INotifyPropertyChanged
    {
        //Sin esta propiedad se da un error a menos que esta se implemente
        public event PropertyChangedEventHandler PropertyChanged;

        //La variable de tipo cadena "nombre" esta vacía por medio de la propiedad .Empty
        string nombre = string.Empty;

        //Esta se crea en forma de propiedad para que no de error
        //por ejemplo, dice codigo inaccesible en el apartado de nombre = value;
        //                                                       onPropertyChanged(nameof(Nombre));
        //                                                       onPropertyChanged(nameof(MostrarNombre));
        public string Nombre 
        {
            //El get se encarga de conseguir y almacenar el valor de la variable nombre
            get => nombre;

            //El set se encarga de colocarlo en el label en tiempo real
            set
            {
                if (nombre == value)
                    return;
                nombre = value;
                onPropertyChanged(nameof(Nombre));
                onPropertyChanged(nameof(MostrarNombre));
            }
        }

        //Esta es la propiedad que se inserta en el label que esta en la interfaz
        public string MostrarNombre => $"Nombre ingresado: {Nombre}";

        //Metodo vacío que permite llamar las propiedades Nombre y MostrarNombre con un parametro
        //de tipo cadena llamado nombre
        void onPropertyChanged(string nombre)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}
