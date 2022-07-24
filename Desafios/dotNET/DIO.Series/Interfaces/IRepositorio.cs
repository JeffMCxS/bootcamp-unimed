using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    //Essa interface exige que seja fornecida uma classe como parâmetro em T para que seja implementada
    {
        List<T> Lista(); //Método Lista que retorna uma lista de T
        T RetornaPorId(int id); //Método que retorna de T
        void Insere(T entidade); //Método que passa T como parâmetro
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}