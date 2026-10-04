# QuanLyBanHang — Hệ thống Quản lý Bán hàng

<p>
  <img src="https://img.shields.io/badge/C%23-.NET-purple" alt="C#">
  <img src="https://img.shields.io/badge/UI-Windows%20Forms-blue" alt="Windows Forms">
  <img src="https://img.shields.io/badge/Architecture-N--Tier-orange" alt="N-Tier Architecture">
</p>

Ứng dụng desktop quản lý bán hàng, xây dựng bằng **C#** trên nền tảng **.NET (Windows Forms)**, tổ chức theo kiến trúc **3 lớp (N-Tier)**: DTO – DAL – BUS – UI.

---

## Giới thiệu (About)

Ứng dụng hỗ trợ quản lý hoạt động bán hàng: sản phẩm, nhân viên, và các nghiệp vụ liên quan. Dự án được tổ chức theo mô hình phân tầng rõ ràng, tách biệt logic nghiệp vụ (BUS), truy xuất dữ liệu (DAL) và đối tượng truyền dữ liệu (DTO) khỏi tầng giao diện — một pattern phổ biến trong các ứng dụng WinForms C#.

> Ghi chú: phần tính năng chi tiết bên dưới dựa theo tên các thư mục hiện có (`BUS`, `BUS_NhanVien`, `DAL`, `DTO`). Bạn bổ sung/chỉnh sửa lại cho khớp chính xác với nghiệp vụ thực tế trong code.

---

## Kiến trúc dự án

```
sales-management-winforms/
├── DTO/                  # Data Transfer Object — các lớp model truyền dữ liệu
├── DAL/                  # Data Access Layer — thao tác trực tiếp với database
├── BUS/                  # Business Logic Layer — xử lý nghiệp vụ chung
├── BUS_NhanVien/         # Business Logic riêng cho nghiệp vụ Nhân viên
├── QuanLyBanHang/         # Project giao diện (Windows Forms UI)
├── packages/                # Thư viện NuGet (nên loại khỏi Git — xem lưu ý bên dưới)
└── QuanLyBanHang.sln           # Visual Studio Solution file
```

**Luồng xử lý:** `UI (WinForms)` → `BUS (nghiệp vụ)` → `DAL (truy vấn DB)` → trả dữ liệu qua `DTO` → hiển thị lại trên `UI`.

---

## Tính năng chính (dự kiến — chỉnh lại theo thực tế)

- Quản lý sản phẩm/hàng hóa
- Quản lý nhân viên (`BUS_NhanVien`)
- Xử lý nghiệp vụ bán hàng (lập hóa đơn, bán hàng...)

---

## 🛠 Công nghệ sử dụng

| Thành phần | Công nghệ |
|---|---|
| Ngôn ngữ | C# |
| Nền tảng | .NET Framework (Windows Forms) |
| Kiến trúc | N-Tier: DTO – DAL – BUS – UI |
| Quản lý gói | NuGet |
| IDE | Visual Studio |

---

## Bắt đầu (Getting Started)

### Yêu cầu

- [Visual Studio](https://visualstudio.microsoft.com/) (2019 trở lên khuyến nghị)
- SQL Server (hoặc DB tương ứng project đang dùng)
- .NET Framework phù hợp với `QuanLyBanHang.sln`

### Cài đặt

```bash
git clone https://github.com/nhunguy-swe/sales-management-winforms.git
cd sales-management-winforms
```

1. Mở `QuanLyBanHang.sln` bằng Visual Studio.
2. Visual Studio sẽ tự khôi phục các gói NuGet (hoặc chạy **Restore NuGet Packages** thủ công).
3. Cập nhật **connection string** trỏ tới SQL Server của bạn (thường nằm trong file cấu hình của tầng DAL).

### Chạy ứng dụng

Đặt `QuanLyBanHang` (project UI) làm **Startup Project**, nhấn **F5** để build và chạy.

---

## Dọn dẹp repo (khuyến nghị)

Thêm vào `.gitignore`:
```
.vs/
packages/
bin/
obj/
```

Sau đó gỡ các thư mục này khỏi Git (vẫn giữ nguyên trên máy):
```bash
git rm -r --cached .vs packages
git add .gitignore
git commit -m "Remove .vs and packages from tracking"
git push
```

---

## Tác giả

- GitHub: [@nhunguy-swe](https://github.com/nhunguy-swe)

---

## Giấy phép

Dự án này được thực hiện cho mục đích học tập/đồ án cá nhân.
