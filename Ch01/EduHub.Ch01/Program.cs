using EduHub.Ch01.Domain;

// =====================================================
// 1. TẠO CÂU LẠC BỘ
// =====================================================

Console.WriteLine("========================================");
Console.WriteLine("EDUHUB - CLUB AND EVENT MANAGEMENT");
Console.WriteLine("========================================");

Club club = Club.Create(
    "Tech Club",
    "Cau lac bo cong nghe va lap trinh.");

Console.WriteLine("\n[1] THONG TIN CAU LAC BO");
Console.WriteLine($"Ten CLB: {club.Name}");
Console.WriteLine($"Mo ta: {club.Description}");
Console.WriteLine($"Ma CLB: {club.Id}");

// =====================================================
// 2. TẠO VÀ THÊM 3 THÀNH VIÊN
// =====================================================

Member member1 = Member.Create(
    "Nguyen An",
    "an@example.com",
    "SV001");

Member member2 = Member.Create(
    "Tran Binh",
    "binh@example.com",
    "SV002");

Member member3 = Member.Create(
    "Le Chi",
    "chi@example.com",
    "SV003");

club.AddMember(member1);
club.AddMember(member2);
club.AddMember(member3);

Console.WriteLine("\n[2] DANH SACH THANH VIEN");

foreach (Member member in club.Members)
{
    Console.WriteLine(
        $"{member.StudentCode} - {member.Name} - {member.Email}");
}

Console.WriteLine($"Tong so thanh vien: {club.MemberCount()}");

// =====================================================
// 3. TẠO SỰ KIỆN
// =====================================================

Event clubEvent = Event.Create(
    club.Id,
    "Workshop AI",
    DateTime.Now.AddDays(7),
    50,
    false);

Console.WriteLine("\n[3] THONG TIN SU KIEN");
Console.WriteLine($"Ten su kien: {clubEvent.Title}");
Console.WriteLine($"Ngay to chuc: {clubEvent.Date:dd/MM/yyyy HH:mm}");
Console.WriteLine($"Suc chua: {clubEvent.Capacity}");
Console.WriteLine($"Hinh thuc: {(clubEvent.IsOnline ? "Online" : "Offline")}");

// =====================================================
// 4. HAI THÀNH VIÊN ĐĂNG KÝ VÀ XÁC NHẬN
// =====================================================

Registration registration1 = Registration.Create(
    member1.Id,
    clubEvent.Id);

Registration registration2 = Registration.Create(
    member2.Id,
    clubEvent.Id);

List<Registration> registrations = new()
{
    registration1,
    registration2
};

Console.WriteLine("\n[4] DANG KY THAM GIA SU KIEN");

foreach (Registration registration in registrations)
{
    Console.WriteLine(
        $"Phieu {registration.Id} - Trang thai ban dau: {registration.Status}");

    registration.Confirm();

    Console.WriteLine(
        $"Trang thai sau xac nhan: {registration.Status}");
}

// =====================================================
// 5. MỘT THÀNH VIÊN CHECK-IN
// =====================================================

CheckIn checkIn = CheckIn.Create(
    registration1,
    CheckInMethod.OnSite);

List<CheckIn> checkIns = new()
{
    checkIn
};

Console.WriteLine("\n[5] THONG TIN CHECK-IN");
Console.WriteLine(checkIn.Summary());

// =====================================================
// 6. BÁO CÁO THAM DỰ
// =====================================================

Console.WriteLine("\n========================================");
Console.WriteLine("BAO CAO THAM DU SU KIEN");
Console.WriteLine("========================================");

Console.WriteLine($"Cau lac bo: {club.Name}");
Console.WriteLine($"Su kien: {clubEvent.Title}");
Console.WriteLine($"Tong so dang ky: {registrations.Count}");
Console.WriteLine($"Tong so check-in: {checkIns.Count}");

Console.WriteLine("\nDanh sach nguoi dang ky:");

foreach (Registration registration in registrations)
{
    Member? member = club.Members.FirstOrDefault(
        item => item.Id == registration.MemberId);

    if (member is not null)
    {
        Console.WriteLine(
            $"- {member.Name} | Trang thai: {registration.Status}");
    }
}

Console.WriteLine("\nDanh sach nguoi da check-in:");

foreach (CheckIn record in checkIns)
{
    Registration? registration = registrations.FirstOrDefault(
        item => item.Id == record.RegistrationId);

    if (registration is not null)
    {
        Member? member = club.Members.FirstOrDefault(
            item => item.Id == registration.MemberId);

        if (member is not null)
        {
            Console.WriteLine($"- {member.Name}");
        }
    }
}

// =====================================================
// 7. KIỂM TRA QUY TẮC NGHIỆP VỤ
// =====================================================

Console.WriteLine("\n[6] KIEM TRA QUY TAC NGHIEP VU");

Registration cancelledRegistration = Registration.Create(
    member3.Id,
    clubEvent.Id);

cancelledRegistration.Cancel();

try
{
    cancelledRegistration.Confirm();
}
catch (InvalidOperationException exception)
{
    Console.WriteLine(
        $"Da chan thao tac khong hop le: {exception.Message}");
}

Console.WriteLine("\n========================================");
Console.WriteLine("CHUONG TRINH KET THUC");
Console.WriteLine("========================================");