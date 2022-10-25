namespace Core
{
    public class OperationType : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsIncome { get; set; }
    }
}
