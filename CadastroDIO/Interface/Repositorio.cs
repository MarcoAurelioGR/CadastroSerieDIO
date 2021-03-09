using System.Collections.Generic;

namespace Cadastro_DIO.Interface
{
   public interface Repositorio<T>
    {

        List<T> Lista();
        T RetornarID(int ID);
        void Insere(T entidade);
        void Exclui(int ID);
        void Atualizar(int ID, T entidade);

        int proximoID(); 

    }
}
