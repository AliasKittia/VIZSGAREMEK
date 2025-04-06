namespace tftwebapinew.DTO
{
    public class AnomaliaLekeresWithPermissionDTO
    {
        public class AnomaliaWPF
        {
            public required int AnomalyId { get; set; }
            public required string AnomalyName { get; set; }
            public required string AnomalyEffect { get; set; }

            // Felhasználó adatok
            public required int UserId { get; set; }
            public required string UserName { get; set; }
            public required int PermissionLevel { get; set; }
            public required string PermissionName { get; set; }

            // Kényelmi property a szerkeszthetőséghez
            public bool IsEditable => PermissionLevel == 2;
        }

    }
}
