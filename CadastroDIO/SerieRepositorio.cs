using System;
using System.Collections.Generic;
using Cadastro_DIO.Interface;

namespace Cadastro_DIO
{
    public class SerieRepositorio : Repositorio<Series>
    {
        private List<Series> listaSeries = new List<Series>();

        public void Atualizar(int ID, Series entidade)
        {
            listaSeries[ID] = entidade;
        }

        public void Exclui(int ID)
        {
            listaSeries[ID].Excluir();
        }

        public void Insere(Series entidade)
        {
            listaSeries.Add(entidade);
        }

        public List<Series> Lista()
        {
            return listaSeries;
        }

        public int proximoID()
        {
            return listaSeries.Count;
        }

        public Series RetornarID(int ID)
        {
            return listaSeries[ID];
        }

    }
}
