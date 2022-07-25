using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploConstrutores.Models
{
    public class Log
    {

        private static Log _log;

        public string PropriedadeLog { get; set; }


        //Construtores privados não podem ser instanciados
        private Log()
        {

        }

        //Então utiliza-se Get para retornar a instancia criada pela própria classe
        public static Log GetInstance()
        {
            if (_log == null)
            {
                _log = new Log();
            }
            return _log;
        }
    }
}