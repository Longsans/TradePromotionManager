using CacKhuyenMaiDangChay.Models;

KhuyenMai km = new KhuyenMai("{\"thoiGianBatDau\":\"12/12/2021\",\"thoiGianKetThuc\":\"2/2/2022\",\"soLuongHoaDon\":12,\"soLuongMucTieu\":200,\"von\":10000,\"tongThanhTien\":100000,\"laiSuatMucTieu\":50000}");

Console.WriteLine("[Cac Khuyen Mai Dang Chay]");
Console.WriteLine(km.toJson());
