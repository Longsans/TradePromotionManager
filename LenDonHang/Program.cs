﻿using LenDonHang.Models;

//DonHang dh = new DonHang();
//dh.gioHang.AddRange(new ItemGioHang[] 
//{
//    new ItemGioHang(
//        new MatHang()
//        {
//            tenMatHang = "rope",
//            donGia = 100000
//        }, 4),
//    new ItemGioHang(
//        new MatHang()
//        {
//            tenMatHang = "gasoline can",
//            donGia = 75000
//        }, 4),
//    new ItemGioHang(
//        new MatHang()
//        {
//            tenMatHang = "lighter",
//            donGia = 30000
//        }, 1)
//});

DonHang dh = new DonHang("{\"khachHang\":{\"idKhachHang\":12,\"tenKhachHang\":\"Long\",\"soDienThoai\":\"0901234567\"},\"gioHang\":[{\"matHang\":{\"idMatHang\":\"abcd\",\"tenMatHang\":\"rope\",\"donGia\":100000},\"soLuong\":4,\"thanhTien\":400000},{\"matHang\":{\"idMatHang\":\"defg\",\"tenMatHang\":\"gasoline can\",\"donGia\":75000},\"soLuong\":4,\"thanhTien\":300000},{\"matHang\":{\"idMatHang\":\"ghij\",\"tenMatHang\":\"lighter\",\"donGia\":30000},\"soLuong\":1,\"thanhTien\":30000}]}");

MatHang mh = new MatHang("{\"idMatHang\":\"mnop\",\"tenMatHang\":\"Áo thun\",\"donGia\":100000,\"dacDiem\":{ \"mauSac\":\"đỏ\",\"kichCo\":\"L\",\"gioiTinh\":\"unisex\"}}");

KhachHang kh = new KhachHang("{\"idKhachHang\":120,\"tenKhachHang\":\"Long\",\"soDienThoai\":\"0901234567\",\"diemTichLuy\":225}");

Console.WriteLine(kh.toJson());