using LenDonHang.Models;


DonHang dh = new DonHang("{\"khachHang\":{\"idKhachHang\":12,\"tenKhachHang\":\"Long\",\"soDienThoai\":\"0901234567\"},\"gioHang\":[{\"matHang\":{\"idMatHang\":\"abcd\",\"tenMatHang\":\"rope\",\"donGia\":100000},\"soLuong\":4,\"thanhTien\":400000},{\"matHang\":{\"idMatHang\":\"defg\",\"tenMatHang\":\"gasoline can\",\"donGia\":75000},\"soLuong\":4,\"thanhTien\":300000},{\"matHang\":{\"idMatHang\":\"ghij\",\"tenMatHang\":\"lighter\",\"donGia\":30000},\"soLuong\":1,\"thanhTien\":30000}]}");

MatHang mh = new MatHang("{\"idMatHang\":\"mnop\",\"tenMatHang\":\"Áo thun\",\"donGia\":100000,\"dacDiem\":{ \"mauSac\":\"đỏ\",\"kichCo\":\"L\",\"gioiTinh\":\"unisex\"}}");

KhachHang kh = new KhachHang("{\"idKhachHang\":120,\"tenKhachHang\":\"Long\",\"soDienThoai\":\"0901234567\",\"diemTichLuy\":225}");

KhuyenMai km = new KhuyenMai()
{
    hinhThuc = "TPR",
    tenKhuyenMai = "Khuyen mai Tet 2022",
    thoiGianBatDau = new DateTime(2022, 2, 1),
    thoiGianKetThuc = new DateTime(2022, 2, 21),
    tieuChi = new TieuChiKhuyenMai()
    {
        tongTienDonHang = 2000000
    },
    giamGia = 0.15f,
};

LenDonHang.LenDonHangService.CreateDonHang(dh.toJson());