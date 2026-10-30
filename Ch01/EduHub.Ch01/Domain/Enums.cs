namespace EduHub.Ch01.Domain;

/// <summary>
/// Trạng thái của một phiếu đăng ký sự kiện.
/// </summary>
public enum RegistrationStatus
{
    Pending,
    Confirmed,
    Cancelled
}

/// <summary>
/// Hình thức thực hiện check-in.
/// </summary>
public enum CheckInMethod
{
    OnSite,
    Online
}