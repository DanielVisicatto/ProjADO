namespace ProjADO.Models
{
    public class Engine
    {
        #region[Properties]
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion


        #region[Methods]
        public override string ToString()
        {
            return $"Descrição:     {Description}\n\n";
        }

        #endregion
    }
}
