namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho một thành viên sinh viên trong hệ thống EduHub.
/// </summary>
public sealed class Member
{
    /// <summary>
    /// Mã định danh duy nhất của thành viên.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Họ tên thành viên.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Địa chỉ email của thành viên.
    /// </summary>
    public string Email { get; private set; }

    /// <summary>
    /// Mã số sinh viên.
    /// </summary>
    public string StudentCode { get; private set; }

    /// <summary>
    /// Thời điểm thành viên tham gia hệ thống.
    /// </summary>
    public DateTime JoinedAt { get; private set; }

    /// <summary>
    /// Cho biết tài khoản thành viên còn hoạt động hay không.
    /// </summary>
    public bool Active { get; private set; }

    private Member(
        Guid id,
        string name,
        string email,
        string studentCode,
        DateTime joinedAt)
    {
        Id = id;
        Name = name;
        Email = email;
        StudentCode = studentCode;
        JoinedAt = joinedAt;
        Active = true;
    }

    /// <summary>
    /// Tạo một thành viên mới sau khi kiểm tra dữ liệu đầu vào.
    /// </summary>
    public static Member Create(
        string name,
        string email,
        string studentCode,
        DateTime? joinedAt = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Tên thành viên không được để trống.",
                nameof(name));
        }

        if (string.IsNullOrWhiteSpace(email) ||
            !email.Contains('@'))
        {
            throw new ArgumentException(
                "Email không hợp lệ.",
                nameof(email));
        }

        if (string.IsNullOrWhiteSpace(studentCode))
        {
            throw new ArgumentException(
                "Mã sinh viên không được để trống.",
                nameof(studentCode));
        }

        DateTime actualJoinedAt = joinedAt ?? DateTime.Now;

        return new Member(
            Guid.NewGuid(),
            name.Trim(),
            email.Trim(),
            studentCode.Trim(),
            actualJoinedAt);
    }

    /// <summary>
    /// Kiểm tra thành viên có đang hoạt động hay không.
    /// </summary>
    public bool IsActive()
    {
        return Active;
    }

    /// <summary>
    /// Vô hiệu hóa thành viên.
    /// </summary>
    public void Deactivate()
    {
        Active = false;
    }
}