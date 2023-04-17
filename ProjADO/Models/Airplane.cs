using ProjADO.Models;

namespace ProjADO.Model
{
    public class Airplane
    {
        #region[Properties]
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumbOfPassengers { get; set; }
        public string Descripition { get; set; }
        public Engine Engine { get; set; }
        #endregion

        public override string ToString()
        {
            return $"ID:                 {Id}\n" +
                   $"Nome do avião:      {Name}\n" +
                   $"Qte Passageiros:    {NumbOfPassengers}\n" +
                   $"Descrição:          {Descripition}\n" +
                   $"Motor:              {Engine}";
        }
    }
}
