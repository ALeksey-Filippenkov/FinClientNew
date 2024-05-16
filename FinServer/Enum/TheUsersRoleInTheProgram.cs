namespace FinServer.Enum
{
    public enum TheUsersRoleInTheProgram
    {
        User = 0,
        Admin = 1,
        SuperAdmin = 2,
    }

    public static class RoleInTheProgram
    {
        public static string GetUsersRoleInTheProgram(TheUsersRoleInTheProgram type)
        {
            return type switch
            {
                TheUsersRoleInTheProgram.User => "Пользователь",
                TheUsersRoleInTheProgram.Admin => "Администратор",
                TheUsersRoleInTheProgram.SuperAdmin => "Супер адмнистратор",

                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}