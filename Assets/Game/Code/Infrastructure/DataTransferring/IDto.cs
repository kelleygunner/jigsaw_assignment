namespace Infrastructure.DataTransferring
{
    // Система передачи данных между фичами, которые не знают друг о друге, еще сырая.
    // Я хотел избежать Message Bus, думаю, в продакшене можно придумать что-то более удобное
    public interface IDto
    {
    }
}