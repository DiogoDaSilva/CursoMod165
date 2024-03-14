namespace CursoMod165.Models
{
    public class Staff
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string EmployeeNumber{ get; set; }
        public string Address { get;set; }
        public string NIF { get; set; }
        public string Email { get; set; }
        public string PhoneNumber {  get; set; }
        public DateOnly Birthday { get; set; }
        public decimal Salary { get; set; }

    }
}
