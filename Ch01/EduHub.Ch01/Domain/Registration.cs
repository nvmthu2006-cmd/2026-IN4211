namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho phiếu đăng ký tham dự sự kiện.
/// </summary>
public sealed class Registration
{
    /// <summary>
    /// Mã định danh của phiếu đăng ký.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Mã thành viên đăng ký.
    /// </summary>
    public Guid MemberId { get; private set; }

    /// <summary>
    /// Mã sự kiện được đăng ký.
    /// </summary>
    public Guid EventId { get; private set; }

    /// <summary>
    /// Thời điểm đăng ký.
    /// </summary>
    public DateTime RegisteredAt { get; private set; }

    /// <summary>
    /// Trạng thái hiện tại của phiếu đăng ký.
    /// </summary>
    public RegistrationStatus Status { get; private set; }

    private Registration(
        Guid id,
        Guid memberId,
        Guid eventId,
        DateTime registeredAt)
    {
        Id = id;
        MemberId = memberId;
        EventId = eventId;
        RegisteredAt = registeredAt;
        Status = RegistrationStatus.Pending;
    }

    /// <summary>
    /// Tạo phiếu đăng ký mới ở trạng thái chờ xác nhận.
    /// </summary>
    public static Registration Create(
        Guid memberId,
        Guid eventId,
        DateTime? registeredAt = null)
    {
        if (memberId == Guid.Empty)
        {
            throw new ArgumentException(
                "Mã thành viên không hợp lệ.",
                nameof(memberId));
        }

        if (eventId == Guid.Empty)
        {
            throw new ArgumentException(
                "Mã sự kiện không hợp lệ.",
                nameof(eventId));
        }

        return new Registration(
            Guid.NewGuid(),
            memberId,
            eventId,
            registeredAt ?? DateTime.Now);
    }

    /// <summary>
    /// Xác nhận phiếu đăng ký đang chờ xử lý.
    /// </summary>
    public void Confirm()
    {
        if (Status != RegistrationStatus.Pending)
        {
            throw new InvalidOperationException(
                "Chỉ có thể xác nhận phiếu đang chờ xử lý.");
        }

        Status = RegistrationStatus.Confirmed;
    }

    /// <summary>
    /// Hủy phiếu đăng ký đang chờ xử lý hoặc đã xác nhận.
    /// </summary>
    public void Cancel()
    {
        if (Status == RegistrationStatus.Cancelled)
        {
            throw new InvalidOperationException(
                "Phiếu đăng ký đã bị hủy trước đó.");
        }

        Status = RegistrationStatus.Cancelled;
    }
}