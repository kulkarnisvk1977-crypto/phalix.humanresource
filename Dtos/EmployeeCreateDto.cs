namespace HumanResource.Dtos
{
    public class EmployeeCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required]
        public int Department { get; set; }
        [Required]
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
    }
}
