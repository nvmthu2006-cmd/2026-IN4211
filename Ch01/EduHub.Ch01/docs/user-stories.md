 ch01/0024416414
# EduHub - User Stories

## 1. Actor: Sinh viên

### US01 - Đăng ký tham gia câu lạc bộ

As a student, I want to register for a club,
so that I can participate in club activities.

Acceptance Criteria:

- Given a student has valid information,
  when the student submits a club registration,
  then the system records the registration.

- Given a student has already joined a club,
  when the student submits the same registration again,
  then the system prevents a duplicate membership.

### US02 - Đăng ký sự kiện

As a student, I want to register for an event,
so that I can participate in the event.

Acceptance Criteria:

- Given an event has available capacity,
  when a student registers,
  then the system creates a Pending registration.

- Given an event has reached its capacity,
  when another student registers,
  then the system rejects the registration.

### US03 - Check-in sự kiện

As a student, I want to check in at an event,
so that my attendance is recorded.

Acceptance Criteria:

- Given a registration is Confirmed,
  when the student checks in,
  then the system creates a CheckIn record.

- Given a registration is not Confirmed,
  when the student attempts to check in,
  then the system rejects the check-in.

## 2. Actor: Ban câu lạc bộ

### US04 - Tạo sự kiện

As a club manager, I want to create an event,
so that club members can participate in activities.

Acceptance Criteria:

- Given the event information is valid,
  when the manager creates an event,
  then the system saves the event.

- Given the event capacity is zero or negative,
  when the manager creates an event,
  then the system rejects the invalid capacity.

### US05 - Xem danh sách thành viên

As a club manager, I want to view club members,
so that I can manage club activities.

Acceptance Criteria:

- Given a club has members,
  when the manager views the member list,
  then the system displays the members.

- Given the manager views the club summary,
  when the member count is requested,
  then the system displays the correct count.

### US06 - Xuất báo cáo tham dự

As a club manager, I want to view attendance reports,
so that I can evaluate event participation.

Acceptance Criteria:

- Given registrations and check-ins exist,
  when the manager requests a report,
  then the system displays registration and check-in counts.

- Given a member has checked in,
  when the report is displayed,
  then the member appears in the checked-in list.

## 3. Actor: Admin

### US07 - Quản lý câu lạc bộ

As an administrator, I want to manage clubs,
so that club information remains accurate.

Acceptance Criteria:

- Given valid club information,
  when the administrator creates a club,
  then the system records the club.

- Given the club name is empty,
  when the administrator creates a club,
  then the system rejects the request.

### US08 - Phê duyệt thành viên

As an administrator, I want to review club membership requests,
so that only valid membership requests are approved.

Acceptance Criteria:

- Given a valid membership request exists,
  when the administrator approves it,
  then the membership request is recorded as approved.

- Given a membership request is invalid,
  when the administrator attempts to approve it,
  then the system rejects the request.

# User Stories

Tai lieu mo ta cac yeu cau cua nguoi dung trong he thong EduHub.
 main
