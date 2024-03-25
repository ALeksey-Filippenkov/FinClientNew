namespace FinServer.DbModels
{
    public class DbPerson
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Surname { get; set; }

        [MaxLength(200)]
        public int Age { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [MaxLength(20)]
        public int PhoneNumber { get; set; }

        [StringLength(100)]
        public string EmailAddress { get; set; }

        [StringLength(100)]
        public string Login { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public bool IsBanned { get; set; }

        public List<DbPersonMoney>? PersonMoneys { get; set; }

    }
}
