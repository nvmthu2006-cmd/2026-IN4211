# EduHub - Domain Class Diagram

```mermaid
classDiagram
    class Member {
        +Guid Id
        +string Name
        +string Email
        +string StudentCode
        +DateTime JoinedAt
        +bool Active
        +Create(name, email, studentCode) Member
        +IsActive() bool
        +Deactivate() void
    }

    class Club {
        +Guid Id
        +string Name
        +string Description
        +DateTime CreatedAt
        +Members IReadOnlyList~Member~
        +Create(name, description) Club
        +AddMember(member) void
        +MemberCount() int
    }

    class Event {
        +Guid Id
        +Guid ClubId
        +string Title
        +DateTime Date
        +int Capacity
        +bool IsOnline
        +Create(...) Event
        +HasCapacity(registeredCount) bool
    }

    class Registration {
        +Guid Id
        +Guid MemberId
        +Guid EventId
        +DateTime RegisteredAt
        +RegistrationStatus Status
        +Create(memberId, eventId) Registration
        +Confirm() void
        +Cancel() void
    }

    class CheckIn {
        +Guid Id
        +Guid RegistrationId
        +DateTime CheckedInAt
        +CheckInMethod Method
        +Create(registration, method) CheckIn
        +Summary() string
    }

    Club "1" o-- "*" Member : has members
    Club "1" --> "*" Event : organizes
    Member "1" --> "*" Registration : registers
    Event "1" --> "*" Registration : receives
    Registration "1" --> "0..1" CheckIn : attendance
    
**Quan trọng:** Khi lưu file Markdown, hãy giữ lại các dấu ba dấu huyền bao quanh `mermaid` để GitHub nhận diện sơ đồ.

Sơ đồ này thể hiện:

- Một câu lạc bộ có nhiều thành viên.
- Một câu lạc bộ có thể tổ chức nhiều sự kiện.
- Một thành viên có thể có nhiều phiếu đăng ký.
- Một sự kiện có thể có nhiều phiếu đăng ký.
- Mỗi phiếu đăng ký có tối đa một bản ghi check-in.

