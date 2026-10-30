namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho bản ghi điểm danh của một phiếu đăng ký.
/// </summary>
public sealed class CheckIn
{
    /// <summary>
    /// Mã định danh của bản ghi điểm danh.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Mã phiếu đăng ký được điểm danh.
    /// </summary>
    public Guid RegistrationId { get; private set; }

    /// <summary>
    /// Thời điểm thực hiện điểm danh.
    /// </summary>
    public DateTime CheckedInAt { get; private set; }

    /// <summary>
    /// Hình thức điểm danh.
    /// </summary>
    public CheckInMethod Method { get; private set; }

    private CheckIn(
        Guid id,
        Guid registrationId,
        DateTime checkedInAt,
        CheckInMethod method)
    {
        Id = id;
        RegistrationId = registrationId;
        CheckedInAt = checkedInAt;
        Method = method;
    }

    /// <summary>
    /// Tạo bản ghi điểm danh cho phiếu đăng ký đã được xác nhận.
    /// </summary>
    public static CheckIn Create(
        Registration registration,
        CheckInMethod method,
        DateTime? checkedInAt = null)
    {
        ArgumentNullException.ThrowIfNull(registration);

        if (registration.Status != RegistrationStatus.Confirmed)
        {
            throw new InvalidOperationException(
                "Chỉ phiếu đã xác nhận mới được điểm danh.");
        }

        return new CheckIn(
            Guid.NewGuid(),
            registration.Id,
            checkedInAt ?? DateTime.Now,
            method);
    }

    /// <summary>
    /// Trả về thông tin tóm tắt của bản ghi điểm danh.
    /// </summary>
    public string Summary()
    {
        return $"Check-in ID: {Id} | " +
               $"Registration ID: {RegistrationId} | " +
               $"Time: {CheckedInAt:dd/MM/yyyy HH:mm:ss} | " +
               $"Method: {Method}";
    }
}