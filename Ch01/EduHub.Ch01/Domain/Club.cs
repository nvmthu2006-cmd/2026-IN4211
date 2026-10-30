namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho một câu lạc bộ sinh viên.
/// </summary>
public sealed class Club
{
    private readonly List<Member> _members = new();

    /// <summary>
    /// Mã định danh của câu lạc bộ.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Tên câu lạc bộ.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Mô tả câu lạc bộ.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Thời điểm thành lập câu lạc bộ.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Danh sách thành viên của câu lạc bộ.
    /// </summary>
    public IReadOnlyList<Member> Members => _members.AsReadOnly();

    private Club(
        Guid id,
        string name,
        string description,
        DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
    }

    /// <summary>
    /// Tạo câu lạc bộ mới.
    /// </summary>
    public static Club Create(
        string name,
        string description,
        DateTime? createdAt = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Tên câu lạc bộ không được để trống.",
                nameof(name));
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException(
                "Mô tả câu lạc bộ không được để trống.",
                nameof(description));
        }

        return new Club(
            Guid.NewGuid(),
            name.Trim(),
            description.Trim(),
            createdAt ?? DateTime.Now);
    }

    /// <summary>
    /// Thêm một thành viên vào câu lạc bộ.
    /// </summary>
    public void AddMember(Member member)
    {
        ArgumentNullException.ThrowIfNull(member);

        if (!member.IsActive())
        {
            throw new InvalidOperationException(
                "Không thể thêm thành viên đã bị vô hiệu hóa.");
        }

        if (_members.Any(existing => existing.Id == member.Id))
        {
            throw new InvalidOperationException(
                "Thành viên đã tồn tại trong câu lạc bộ.");
        }

        _members.Add(member);
    }

    /// <summary>
    /// Trả về số lượng thành viên của câu lạc bộ.
    /// </summary>
    public int MemberCount()
    {
        return _members.Count;
    }
}