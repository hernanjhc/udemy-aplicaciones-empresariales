using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Pacagroup.Eccomerce.Transversal.Common
{
    //response contiene info que expone los recursos de web api
    //por ejemplo en data, los metodos de capa dominio, respuestas de insert delete...
    //IsSuccess estado de la ejecución
    //Message info del tipo, operacion ejecutada ok o errores
    public class Response<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
